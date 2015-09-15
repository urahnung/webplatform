using System;
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
      public virtual void Initialize()
      {
         if (this.IsInitialized || this.IsTerminated)
            throw new InvalidOperationException();

         this.IsInitialized = true;
      }

      /// <inheritdoc />
      public virtual void Prepare(ILocator locator)
      {
         if (!this.IsInitialized || this.IsPrepared)
            throw new InvalidOperationException();
         this.IsPrepared = true;
      }

      /// <inheritdoc />
      public virtual void Terminate(IRegistrar registrar)
      {
         if (!this.IsInitialized)
            throw new InvalidOperationException();

         this.IsInitialized = false;
         this.IsPrepared = false;
         this.IsTerminated = true;
      }
   }
}