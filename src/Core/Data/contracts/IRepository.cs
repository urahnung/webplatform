using WebPlatform.Core.Composition;
namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Defines the repository service interface.
   /// </summary>
   /// <typeparam name="TEntity">The type of the entity.</typeparam>
   public interface IRepository<TEntity> :
      IService
      where TEntity : Entity
   {
   }
}