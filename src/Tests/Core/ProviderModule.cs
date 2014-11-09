using WebPlatform.Core.Services;
using WebPlatform.Core.Validation;

namespace WebPlatform.Tests.Core
{
   /// <summary>
   ///   Provides a module implementation for tests.
   /// </summary>
   [Provides(typeof(ITestService))]
   public class ProviderModule :
      Module
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="ProviderModule" /> class.
      /// </summary>
      /// <param name="registrar">The service registrar. Must not be <see langword="null"/>.</param>
      public ProviderModule([NotNull] IRegistrar registrar)
         : base(registrar)
      {
         registrar.RegisterSingleton<ITestService, TestService>();
      }

      /// <inheritdoc />
      public override void Prepare(ILocator locator)
      {
         base.Prepare(locator);
      }

      /// <inheritdoc />
      protected override void Initialize(IRegistrar registrar)
      {
         base.Initialize(registrar);
      }
   }
}