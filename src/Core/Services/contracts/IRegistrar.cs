using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Defines the service registrar interface.
   /// </summary>
   /// <typeparam name="TService">The type of the service.</typeparam>
   public interface IRegistrar : IService
   {
      /// <summary>
      ///   Registers the specified service.
      /// </summary>
      /// <typeparam name="TService">The type of the service.</typeparam>
      /// <param name="service">The service. Must not be <see langword="null" />.</param>
      void RegisterInstance<TService>([NotNull] TService service)
         where TService : class, IService;

      /// <summary>
      ///   Registers the <typeparamref name="TClass" /> as service class for <typeparamref name="TService" />.
      /// </summary>
      /// <typeparam name="TService">The type of the service.</typeparam>
      /// <typeparam name="TClass">The type of the class.</typeparam>
      void RegisterSingleton<TService, TClass>()
         where TService : class, IService
         where TClass : TService;

      /// <summary>
      ///   Releases the specified service.
      /// </summary>
      /// <param name="service">The service. Must not be <see langword="null"/>.</param>
      void ReleaseService(IService service);
   }
}