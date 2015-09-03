using System;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Composition
{
   /// <summary>
   ///   Defines the service registrar interface.
   /// </summary>
   public interface IRegistrar : IService
   {
      /// <summary>
      ///   Registers the specified service.
      /// </summary>
      /// <typeparam name="TService">The type of the service.</typeparam>
      /// <param name="service">The service. Must not be <see langword="null" />.</param>
      /// <returns>The registrar. Never <see langword="null"/>.</returns>
      [return: NotNull]
      IRegistrar Register<TService>([NotNull] TService service)
         where TService : class, IService;

      /// <summary>
      ///   Registers the <typeparamref name="TClass" /> as service class for <typeparamref name="TService" />.
      /// </summary>
      /// <typeparam name="TService">The type of the service.</typeparam>
      /// <typeparam name="TClass">The type of the class.</typeparam>
      /// <returns>The registrar. Never <see langword="null"/>.</returns>
      [return: NotNull]
      IRegistrar Register<TService, TClass>()
         where TService : class, IService
         where TClass : TService;

      /// <summary>
      ///   Registers the <typeparamref name="TClass" /> as service class for <typeparamref name="TService" />.
      /// </summary>
      /// <param name="serviceType">The service's type. Must not be <see langword="null"/>.</param>
      /// <param name="classType">The service's implementation. Must not be <see langword="null"/>.</param>
      /// <returns>
      ///   The registrar. Never <see langword="null" />.
      /// </returns>
      [return: NotNull]
      IRegistrar Register([NotNull] Type serviceType, [NotNull] Type classType);

      /// <summary>
      ///   Releases the specified service.
      /// </summary>
      /// <param name="service">The service. Must not be <see langword="null"/>.</param>
      void ReleaseService([NotNull] IService service);
   }
}