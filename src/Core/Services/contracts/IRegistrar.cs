using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Defines the service registrar interface.
   /// </summary>
   public interface IRegistrar : IService
   {
      /// <summary>
      ///   Registers the <typeparamref name="TClass" /> as service class for <typeparamref name="TService" />.
      /// </summary>
      /// <typeparam name="TService">The type of the service.</typeparam>
      /// <typeparam name="TClass">The type of the class.</typeparam>
      /// <param name="lifetime">The lifetime.</param>
      /// <returns>
      ///   The service registrar for fluent use.
      /// </returns>
      [NotNull]
      IRegistrar Register<TService, TClass>([NotNull] ILifetime lifetime)
         where TService : IService
         where TClass : TService;

      /// <summary>
      ///   Registers the specified service.
      /// </summary>
      /// <typeparam name="TService">The type of the service.</typeparam>
      /// <param name="service">The service. Must not be <see langword="null" />.</param>
      /// <returns>
      ///   The service registrar for fluent use.
      /// </returns>
      [NotNull]
      IRegistrar RegisterInstance<TService>([NotNull] TService service)
         where TService : IService;
   }
}