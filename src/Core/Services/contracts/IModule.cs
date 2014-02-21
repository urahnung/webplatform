using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Defines a service module interface.
   /// </summary>
   public interface IModule
   {
      /// <summary>
      ///   Gets a value indicating whether the module is initialized.
      /// </summary>
      bool IsInitialized { get; }

      /// <summary>
      ///   Gets the module name.
      /// </summary>
      string Name { [return: NotNull] get; }

      /// <summary>
      ///   Prepares the module.
      /// </summary>
      /// <param name="locator">The service locator.</param>
      void Prepare(ILocator locator);

      /// <summary>
      ///   Terminates the module.
      /// </summary>
      void Terminate();
   }
}