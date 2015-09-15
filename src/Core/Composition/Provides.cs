namespace WebPlatform.Core.Composition
{
   /// <summary>
   ///   Defines the service provider interface.
   /// </summary>
   /// <typeparam name="TService">The type of the service.</typeparam>
   public interface Provides<TService>
      where TService : IService
   {
   }
}
