namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Provides a base class implementation for entities.
   /// </summary>
   public abstract class Entity : IEntity<int>
   {
      /// <summary>
      ///   Gets or sets the identifier.
      /// </summary>
      public virtual int Id { get; protected set; }
   }
}