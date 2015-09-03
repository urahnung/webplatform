using WebPlatform.Core.Composition;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Defines a session.
   /// </summary>
   public interface ISession : IService
   {
      /// <summary>
      ///   Start a unit of work.
      /// </summary>
      /// <returns>The unit of work. Never <see langword="null"/>.</returns>
      [NotNull]
      IUnitOfWork BeginWork();
   }
}
