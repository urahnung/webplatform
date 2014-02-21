using Microsoft.Practices.Unity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Provides functionality to build a runtime using module services.
   /// </summary>
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
      private UnityContainer container;

      /// <summary>
      ///   Initializes a new instance of the <see cref="Runtime"/> class.
      /// </summary>
      protected Runtime()
      {
         // creates the unity DI container
         this.container = new UnityContainer();

         // registers the runtime services
         this.Initialize(this);
      }

      /// <summary>
      ///   Initializes a new instance of the <see cref="Runtime"/> class.
      /// </summary>
      /// <param name="moduleTypes">The module types. Must not be <see langword="null" />.</param>
      protected Runtime(IEnumerable<ModuleType> moduleTypes)
         : this()
      {
         // registers the modules
         foreach (var moduleType in moduleTypes)
         {
            this.container.RegisterType(typeof(IModule), moduleType.Type, moduleType.Name, new ContainerControlledLifetimeManager(), new InjectionMember[0]);
         }

         // ensures that the dependencies could be resolved
         this.Bind();
      }

      /// <summary>
      ///   Gets the service locator.
      /// </summary>
      public ILocator Locator
      {
         get
         {
            return this;
         }
      }

      /// <summary>
      ///   Gets the registrar service.
      /// </summary>
      public IRegistrar Registrar
      {
         get
         {
            return this;
         }
      }
      /// <summary>
      ///   Creates a runtime binding the services of the modules in the specified catalog.
      /// </summary>
      /// <param name="catalog">The module catalog. Must not be <see langword="null"/>.</param>
      /// <returns>The runtime. Never <see langword="null"/>.</returns>
      public static Runtime With(ICatalog catalog)
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
               module.Terminate();
            }

            // disposes all services
            this.container = null;
            container.Dispose();
         }
      }

      /// <inheritdoc />
      public IEnumerator<IModule> GetEnumerator()
      {
         return this.container.ResolveAll<IModule>().GetEnumerator();
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
      IRegistrar IRegistrar.Register<TService, TClass>(ILifetime lifetime)
      {
         this.container.RegisterType<TService, TClass>();
         return this;
      }

      /// <inheritdoc />
      IRegistrar IRegistrar.RegisterInstance<TService>(TService service)
      {
         this.container.RegisterInstance<TService>(service);
         return this;
      }

      /// <inheritdoc />
      protected override void Initialize(IRegistrar registrar)
      {
         // registers the runtime as service registrar and service locator
         registrar.RegisterInstance<IRegistrar>(this);
         registrar.RegisterInstance<ILocator>(this);
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
         module = this.Locator.Resolve<TModule>(name);
         return module != null;
      }

      /// <summary>
      ///   Performs the module binding.
      /// </summary>
      private IEnumerable<IModule> Bind()
      {
         foreach (var module in this)
         {
            module.Prepare(this);
         }
         return this;
      }
   }
}
