using WebPlatform.Core.Services;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Provides a connection implementation.
   /// </summary>
   public class Connection :
      Service<RepositoryModule>,
      IConnection
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="Connection" /> class.
      /// </summary>
      /// <param name="module">The module. Must not be <see langword="null"/>.</param>
      public Connection([NotNull] RepositoryModule module)
         : base(module)
      {
      }
   }
}
