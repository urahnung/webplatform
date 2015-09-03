namespace WebPlatform.Core.Composition
{
   /// <summary>
   ///   Defines the service locator interface.
   /// </summary>
   public interface ILocator : IService
   {
      /// <summary>
      ///   Resolves a <typeparamref name="TService"/> with the specified name.
      /// </summary>
      /// <typeparam name="TService">The type of the service.</typeparam>
      /// <param name="name">The name.</param>
      /// <returns>The service.</returns>
      TService Resolve<TService>(string name);

      /// <summary>
      ///   Resolves a <typeparamref name="TService"/>.
      /// </summary>
      /// <typeparam name="TService">The type of the service.</typeparam>
      /// <returns>The service.</returns>
      TService Resolve<TService>();
   }
}