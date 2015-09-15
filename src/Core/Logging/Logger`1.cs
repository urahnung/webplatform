using System;
using WebPlatform.Core.Composition;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Logging
{
   /// <summary>
   ///   Provides a logger implementation.
   /// </summary>
   /// <typeparam name="TModule">The type of the module the logger belongs to.</typeparam>
   [Service(Lifetime = Lifetime.Transient)]
   public class Logger<TModule> :
      Service<LoggingModule>,
      ILogger<TModule>
      where TModule : IModule
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="Logger" /> class.
      /// </summary>
      /// <param name="module">The module. Must not be <see langword="null" />.</param>
      /// <param name="owner">The owner.</param>
      public Logger([NotNull]LoggingModule module, [NotNull] TModule owner) : base(module)
      {
         this.Owner = owner;
      }

      /// <inheritdoc/>
      public TModule Owner
      {
         get;
         private set;
      }
   }
}