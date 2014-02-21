using WebPlatform.Core.Services;

namespace WebPlatform.Tests.Core
{
   /// <summary>
   ///   Provides a test service implementation.
   /// </summary>
   public class TestService :
      Service<TestModule>,
      ITestService
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="TestService"/> class.
      /// </summary>
      ///   <param name="module">The test module.</param>
      public TestService(TestModule module)
         : base(module)
      {
      }
   }
}
