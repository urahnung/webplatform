
namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Provides the service base implementation.
   /// </summary>
   /// <typeparam name="TModule">The type of the module.</typeparam>
   public abstract class Service<TModule> : IService
      where TModule : IModule
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Service{TModule}"/> class.
      /// </summary>
      /// <param name="module">The module.</param>
      public Service(TModule module)
      {
         this.Module = module;
         this.Initialize();
      }

      /// <summary>
      ///   Initializes the service.
      /// </summary>
      protected virtual void Initialize()
      {
      }

      /// <summary>
      ///   Gets the module.
      /// </summary>
      public TModule Module
      {
         get;
         private set;
      }
   }
}
