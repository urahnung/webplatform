using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Defines the service interface.
   /// </summary>
   public interface IService
   {
      /// <summary>
      ///   Gets the module. Must not be <see langword="null"/>.
      /// </summary>
      IModule Module { [NotNull] get; }
   }
}