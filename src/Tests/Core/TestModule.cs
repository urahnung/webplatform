using WebPlatform.Core.Services;

namespace WebPlatform.Tests.Core
{
   /// <summary>
   ///   Provides a module implementation for tests.
   /// </summary>
   public class TestModule : Module
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="TestModule" /> class.
      /// </summary>
      /// <param name="registrar">The service registrar.</param>
      public TestModule(IRegistrar registrar)
         : base(registrar)
      {
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

         registrar.Register<ITestService, TestService>(null);
      }
   }
}