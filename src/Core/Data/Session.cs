using WebPlatform.Core.Composition;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Provides a session.
   /// </summary>
   public class Session :
      Service<DataModule>,
      ISession
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="Session" /> class.
      /// </summary>
      /// <param name="module">The module. Must not be <see langword="null"/>.</param>
      public Session([NotNull] DataModule module)
         : base(module)
      {
      }

      /// <inheritdoc />
      public IUnitOfWork BeginWork()
      {
         return null;
      }
   }
}
