namespace WebPlatform.Core.Composition
{
   /// <summary>
   ///   Defines the service lifetimes.
   /// </summary>
   public enum Lifetime
   {
      /// <summary>
      ///   The scope lifetime.
      /// </summary>
      Scope,

      /// <summary>
      ///   The singleton lifetime.
      /// </summary>
      Singleton,

      /// <summary>
      ///   The transient lifetime.
      /// </summary>
      Transient
   }
}
