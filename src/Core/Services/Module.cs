namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Provides a base class implementation for service modules.
   /// </summary>
   public abstract class Module : IModule
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="Module" /> class.
      /// </summary>
      /// <param name="registrar">The service registrar.</param>
      public Module(IRegistrar registrar)
      {
         this.Initialize(registrar);
      }

      /// <summary>
      ///   Initializes a new instance of the <see cref="Module"/> class.
      /// </summary>
      protected Module()
      {
      }
      /// <inheritdoc />
      public bool IsInitialized
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
      }

      /// <inheritdoc />
      public virtual void Terminate()
      {
         this.IsInitialized = false;
      }

      /// <summary>
      ///   Registers the services.
      /// </summary>
      /// <param name="registrar">The registrar.</param>
      protected virtual void Initialize(IRegistrar registrar)
      {
         this.IsInitialized = true;
      }
   }
}

