using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.MicroKernel.Registration;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Composition
{
   /// <summary>
   ///   Provides functionality to build a runtime using module services.
   /// </summary>
   public partial class Runtime :
      IRegistrar
   {
      /// <summary>
      ///   Contains the register method.
      /// </summary>
      private static MethodInfo RegisterMethod = Reflector.GetMethod((IRegistrar registrar) => registrar.Register<IService, IService>());

      /// <inheritdoc />
      IRegistrar IRegistrar.Register<TService>(TService service)
      {
         this.container.Register(Component.For<TService>().Instance(service).Named(typeof(TService).Name));
         return this;
      }

      /// <inheritdoc />
      IRegistrar IRegistrar.Register<TService, TClass>()
      {
         return ((IRegistrar)this).Register(typeof(TService), typeof(TClass));
      }

      /// <summary>
      ///   Registers the specified registration for the specified service type.
      /// </summary>
      /// <param name="registration">The registration. Must not be <see langword="null"/>.</param>
      /// <param name="serviceType">Type of the service. Must not be <see langword="null"/>.</param>
      private void Register([NotNull] ComponentRegistration<object> registration, [NotNull] Type serviceType)
      {
         switch (ServiceAttribute.GetLifetime(registration.Implementation))
         {
            case Lifetime.Scope:
               registration = registration.LifeStyle.Scoped();
               break;

            case Lifetime.Singleton:
               registration = registration.LifeStyle.Singleton;
               break;

            default:
               registration = registration.LifeStyle.Transient;
               break;
         }
         this.container.Register(this.InjectDependency(serviceType, registration.Implementation, registration));
      }

      /// <inheritdoc />
      IRegistrar IRegistrar.Register(Type serviceType, Type classType)
      {
         if (!typeof(IService).IsAssignableFrom(serviceType))
            throw new InvalidArgumentException();

         this.Register(Component.For(serviceType).ImplementedBy(classType), serviceType);
         return this;
      }

      /// <inheritdoc/>
      void IRegistrar.ReleaseService(IService service)
      {
         this.container.Release(service);
      }

      /// <summary>
      ///   Injects dependencies.
      /// </summary>
      /// <param name="serviceType">The service type. Must not be <see langword="null"/>.</param>
      /// <param name="classType">The class type. Must not be <see langword="null"/>.</param>
      /// <param name="registration">The registration. Must not be <see langword="null"/>.</param>
      /// <returns>
      ///   The registration. Never <see langword="null"/>.
      /// </returns>
      private ComponentRegistration<object> InjectDependency(Type serviceType, Type classType, ComponentRegistration<object> registration)
      {
         foreach (var constructor in classType.GetConstructors())
         {
            foreach (var parameter in constructor.GetParameters())
            {
               KeyValuePair<string, string> dependency;
               if (DependsOnAttribute.TryGetDependecy(parameter, out dependency))
                  registration = registration.DependsOn(Dependency.OnAppSettingsValue(dependency.Key, dependency.Value));
            }
         }

         return registration;
      }
   }
}