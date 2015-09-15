using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPlatform.Core.Composition;

namespace WebPlatform.Tests.Core
{
   /// <summary>
   ///   Test the service runtime.
   /// </summary>
   [TestClass]
   public class RuntimeTests
   {
      /// <summary>
      ///   Tests the runtime creation.
      /// </summary>
      [TestMethod]
      public void TestRuntimeCreation()
      {
         var moduleTypes = TypeCatalog.With
         (
            ModuleType.For<ConsumerModule>(),
            ModuleType.For<ProviderModule>()
         );
         using (var runtime = Runtime.With(moduleTypes))
         {
            // tries to resolve the test module
            ProviderModule providerModule;
            Assert.IsTrue(runtime.TryGet("ProviderModule", out providerModule));
            ConsumerModule consumerModule;
            Assert.IsTrue(runtime.TryGet("ConsumerModule", out consumerModule));
            Assert.IsTrue(consumerModule.IsInitialized);

            Assert.IsNotNull(consumerModule.TestService);
            Assert.AreSame(runtime.Locator.Resolve<ITestService>(), consumerModule.TestService);
         }
      }
   }
}