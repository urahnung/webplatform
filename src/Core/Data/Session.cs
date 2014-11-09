using WebPlatform.Core.Services;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Provides a session.
   /// </summary>
   public class Session :
      Service<RepositoryModule>,
      ISession
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="Session" /> class.
      /// </summary>
      /// <param name="module">The module. Must not be <see langword="null"/>.</param>
      public Session([NotNull] RepositoryModule module)
         : base(module)
      {
      }

      /// <inheritdoc />
      public IUnitOfWork BeginWork()
      {
         throw new System.NotImplementedException();
      }
   }
}
