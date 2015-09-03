using System.Data.Entity;
using WebPlatform.Core.Composition;

namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Implements the <see cref="IUnitOfWork"/> interface using the <see cref="DbContext"/>.
   /// </summary>
   public class UnitOfWork : Service<DataModule>, IUnitOfWork
   {
      /// <summary>
      ///   Contains the DB context.
      /// </summary>
      private DbContext context = null;

      /// <summary>
      ///   Initializes a new instance of the <see cref="UnitOfWork"/> class.
      /// </summary>
      /// <param name="module">The module.</param>
      public UnitOfWork(DataModule module, ISession session)
         : base(module)
      {
      }

      /// <inheritdoc/>
      public IRepository<TEntity> Cast<TEntity>()
         where TEntity : Entity
      {
         var set = this.context.Set<TEntity>();
         return null;
      }
   }
}
