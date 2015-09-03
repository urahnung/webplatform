using WebPlatform.Core.Composition;
namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Defines a unit of work according to Martin Fowler. <seealso="http://martinfowler.com/eaaCatalog/unitOfWork.html"/>
   /// </summary>
   public interface IUnitOfWork : IService
   {
      /// <summary>
      ///   Gets a repository for the specified entity type.
      /// </summary>
      /// <typeparam name="TEntity">The entity type.</typeparam>
      /// <returns>The repository. Never <see langword="null"/>.</returns>
      IRepository<TEntity> Cast<TEntity>()
         where TEntity : Entity;
   }
}
