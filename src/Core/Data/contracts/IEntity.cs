namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Defines the entity interface.
   /// </summary>
   /// <typeparam name="T">The identification type.</typeparam>
   public interface IEntity<T>
   {
      /// <summary>
      ///    Gets the identifier.
      /// </summary>
      T Id { get; }
   }
}
