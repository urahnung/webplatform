/// @file   Data\Entity.cs
///
/// @brief  Implements the entity class.

namespace WebPlatform.Core.Data
{
   /// @class  Entity
   ///
   /// @brief  The base class for all entities.
   ///
   /// @author uh
   /// @date   10.02.2014
   public abstract class Entity
   {
      /// @property  public virtual int Id
      ///
      /// @brief  Gets or sets the id.
      ///
      /// @return The identifier.
      public virtual int Id { get; protected set; }
   }
}
