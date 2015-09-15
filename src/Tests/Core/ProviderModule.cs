using WebPlatform.Core.Composition;
using WebPlatform.Core.Validation;

namespace WebPlatform.Tests.Core
{
   /// <summary>
   ///   Provides a module implementation for tests.
   /// </summary>
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
         registrar.Register<ITestService, TestService>();
      }

      /// <inheritdoc />
      public override void Prepare(ILocator locator)
      {
         base.Prepare(locator);
      }
   }
}