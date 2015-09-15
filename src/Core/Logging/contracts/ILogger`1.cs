using WebPlatform.Core.Composition;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Logging
{
   /// <summary>
   ///   Allows logging messages.
   /// </summary>
   /// <typeparam name="TModule">The type of the module the logger belongs to.</typeparam>
   public interface ILogger<TModule> : IService
      where TModule : IModule
   {
      /// <summary>
      /// Gets the module the logger belongs to.
      /// </summary>
      TModule Owner {[return: NotNull] get; }
   }
}