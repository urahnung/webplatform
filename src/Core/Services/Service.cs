using WebPlatform.Core.Validation;
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
      ///   Contains the module.
      /// </summary>
      private readonly TModule module;

      /// <summary>
      ///   Initializes a new instance of the <see cref="Service{TModule}" /> class.
      /// </summary>
      /// <param name="module">The module. Must not be <see langword="null"/>.</param>
      public Service([NotNull] TModule module)
      {
         this.module = module;
         this.Initialize();
      }

      /// <summary>
      ///   Gets or sets the module.
      /// </summary>
      public TModule Module
      {
         get
         {
            return this.module;
         }
      }

      /// <summary>
      ///   Initializes the service.
      /// </summary>
      protected virtual void Initialize()
      {
      }

      /// <inheritdoc />
      IModule IService.Module
      {
         [return: NotNull]
         get
         {
            return this.Module;
         }
      }
   }
}