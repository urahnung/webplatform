using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Composition
{
   /// <summary>
   ///   Provides a base class implementation for service modules.
   /// </summary>
   public abstract class Module : IModule
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="Module"/> class.
      /// </summary>
      protected Module()
      {
      }

      /// <summary>
      ///   Initializes a new instance of the <see cref="Module" /> class.
      /// </summary>
      /// <param name="registrar">The service registrar. Must not be <see langword="null"/>.</param>
      public Module([NotNull] IRegistrar registrar)
      {
         this.Initialize(registrar);
      }

      /// <inheritdoc />
      public bool IsInitialized
      {
         get;
         private set;
      }

      /// <inheritdoc />
      public bool IsPrepared
      {
         get;
         private set;
      }

      /// <inheritdoc />
      public bool IsTerminated
      {
         get;
         private set;
      }

      /// <inheritdoc />
      public virtual string Name
      {
         get
         {
            return this.GetType().Name;
         }
      }

      /// <inheritdoc />
      public virtual void Prepare(ILocator locator)
      {
         this.IsPrepared = true;
      }

      /// <inheritdoc />
      public virtual void Terminate(IRegistrar registrar)
      {
         this.IsInitialized = false;
         this.IsPrepared = false;
         this.IsTerminated = true;
      }

      /// <summary>
      ///   Registers the services.
      /// </summary>
      /// <typeparam name="TModule">The type of the module.</typeparam>
      /// <param name="registrar">The registrar. Must not be <see langword="null" />.</param>
      protected virtual void Initialize([NotNull] IRegistrar registrar)
      {
         this.IsInitialized = true;
      }
   }
}