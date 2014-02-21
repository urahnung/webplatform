using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPlatform.Core.Services;

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
         using (var runtime = Runtime.With(TypeCatalog.With(ModuleType.For<TestModule>())))
         {
            // tries to resolve the test module
            TestModule testModule;
            Assert.IsTrue(runtime.TryGet("TestModule", out testModule));
            Assert.IsTrue(testModule.IsInitialized);

            // tries to resolve test service
            var testService = runtime.Locator.Resolve<ITestService>();
         }
      }
   }
}
