using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Composition
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
      ///   Gets a value indicating whether the module is prepared.
      /// </summary>
      bool IsPrepared { get; }

      /// <summary>
      ///   Gets a value indicating whether the module is terminated.
      /// </summary>
      bool IsTerminated { get; }

      /// <summary>
      ///   Gets the module name. Never <see langword="null"/>.
      /// </summary>
      string Name {[return: NotNull] get; }

      /// <summary>
      ///   Iniializes the module.
      /// </summary>
      void Initialize();

      /// <summary>
      ///   Prepares the module.
      /// </summary>
      /// <param name="locator">The service locator. Must not be <see langword="null"/>.</param>
      void Prepare([NotNull] ILocator locator);

      /// <summary>
      ///   Terminates the module.
      /// </summary>
      /// <param name="registrar">The service registrar. Must not be <see langword="null"/>.</param>
      void Terminate([NotNull] IRegistrar registrar);
   }
}