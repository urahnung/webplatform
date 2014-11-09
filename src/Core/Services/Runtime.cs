﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers;
using Castle.Windsor;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Provides functionality to build a runtime using module services.
   /// </summary>
   [Provides(typeof(ILocator))]
   [Provides(typeof(IRegistrar))]
   public class Runtime :
      Module,
      IDisposable,
      IEnumerable<IModule>,
      ILocator,
      IRegistrar
   {
      /// <summary>
      ///   Contains the DI container.
      /// </summary>
      private WindsorContainer container;

      /// <summary>
      ///   Initializes a new instance of the <see cref="Runtime"/> class.
      /// </summary>
      protected Runtime()
      {
         // creates the windsor DI container
         this.container = new WindsorContainer();
         this.container.Register(Component.For<ILazyComponentLoader>().ImplementedBy<LazyOfTComponentLoader>());


         // registers the runtime services
         this.Initialize(this);
      }

      /// <summary>
      ///   Initializes a new instance of the <see cref="Runtime"/> class.
      /// </summary>
      /// <param name="moduleTypes">The module types. Must not be <see langword="null" />.</param>
      protected Runtime([NotNull] IEnumerable<ModuleType> moduleTypes)
         : this()
      {
         // registers the modules
         foreach (var moduleType in moduleTypes)
            this.RegisterModule(moduleType);

         // binds the services
         this.Bind();
      }

      /// <inheritdoc />
      IModule IService.Module
      {
         get
         {
            return this;
         }
      }

      /// <summary>
      ///   Gets the service locator.
      /// </summary>
      public ILocator Locator
      {
         [return: NotNull]
         get
         {
            return this;
         }
      }

      /// <summary>
      ///   Gets the service registrar.
      /// </summary>
      public IRegistrar Registrar
      {
         [return: NotNull]
         get
         {
            return this;
         }
      }

      /// <summary>
      ///   Creates a runtime, binding the services provided through the modules in the specified catalog.
      /// </summary>
      /// <param name="catalog">The module catalog. Must not be <see langword="null"/>.</param>
      /// <returns>The runtime. Never <see langword="null"/>.</returns>
      public static Runtime With([NotNull] ICatalog catalog)
      {
         return new Runtime(catalog);
      }

      /// <inheritdoc />
      public void Dispose()
      {
         var container = this.container;

         if (container != null)
         {
            // terminates the modules
            foreach (var module in this)
            {
               module.Terminate(this);
            }

            // disposes all services
            this.container = null;
            container.Dispose();
         }
      }

      /// <inheritdoc />
      public IEnumerator<IModule> GetEnumerator()
      {
         return this.container.ResolveAll<IModule>().AsEnumerable().GetEnumerator();
      }

      /// <inheritdoc />
      IEnumerator IEnumerable.GetEnumerator()
      {
         return this.GetEnumerator();
      }

      /// <inheritdoc />
      TService ILocator.Resolve<TService>(string name)
      {
         return this.container.Resolve<TService>(name);
      }

      /// <inheritdoc />
      TService ILocator.Resolve<TService>()
      {
         return this.container.Resolve<TService>();
      }

      /// <inheritdoc />
      void IRegistrar.RegisterInstance<TService>(TService service)
      {
         this.container.Register(Component.For<TService>().Instance(service).Named(typeof(TService).Name));
      }

      /// <inheritdoc />
      void IRegistrar.RegisterSingleton<TService, TClass>()
      {
         this.container.Register(Component.For<TService>().ImplementedBy<TClass>().LifestyleSingleton());
      }

      /// <inheritdoc/>
      void IRegistrar.ReleaseService(IService service)
      {
         this.container.Release(service);
      }

      /// <summary>
      ///   Tries to get a module with the specified name.
      /// </summary>
      /// <typeparam name="TModule">The type of the module.</typeparam>
      /// <param name="name">The name.</param>
      /// <param name="module">The module.</param>
      /// <returns><see langword="true"/>, if the module is returned; otherwise, <see langword="false"/>.</returns>
      public bool TryGet<TModule>(string name, out TModule module)
         where TModule : IModule
      {
         module = (TModule)this.Locator.Resolve<IModule>(name);
         return module != null;
      }

      /// <inheritdoc />
      protected override void Initialize(IRegistrar registrar)
      {
         // registers the runtime as service registrar and service locator
         registrar.RegisterInstance<IRegistrar>(this);
         registrar.RegisterInstance<ILocator>(this);

         base.Initialize(registrar);
      }

      /// <summary>
      ///   Performs the module binding.
      /// </summary>
      private void Bind()
      {
         // prepares all modules
         foreach (var module in this)
         {
            module.Prepare(this);
         }

         // ensure that all abstract services are bound
         foreach (var handler in container.Kernel.GetAssignableHandlers(typeof(IService)))
         {
            if (handler.ComponentModel.LifestyleType == LifestyleType.Undefined)
               this.container.Resolve(handler.ComponentModel.Services.First());
         }
      }

      /// <summary>
      ///   Registers the specified module.
      /// </summary>
      /// <param name="moduleType">The module type. Must not be <see langword="null"/>.</param>
      private void RegisterModule([NotNull] ModuleType moduleType)
      {
         this.container.Register(Component.For(typeof(IModule), moduleType.Type).ImplementedBy(moduleType.Type).Named(moduleType.Name).LifestyleSingleton());

         var serviceTypes = ProvidesAttribute.GetServices(moduleType.Type);
         if (serviceTypes.Any())
            this.container.Register(Component.For(serviceTypes).IsFallback());
      }
   }
}