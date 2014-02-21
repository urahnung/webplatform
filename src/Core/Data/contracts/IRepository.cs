/// @file   Data\IRepository.cs
///
/// @brief  Declares the IRepository interface.
namespace WebPlatform.Core.Data
{
   /// @interface IRepository<TEntity>
   ///
   /// @brief  Interface for repository.  
   ///
   /// @author uh
   /// @date   10.02.2014
   ///
   /// @tparam TEntity  Type of the entity.
   public interface IRepository<TEntity>
      where TEntity : Entity
   {
   }
}
