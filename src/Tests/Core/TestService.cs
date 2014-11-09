using WebPlatform.Core.Services;
using WebPlatform.Core.Validation;

namespace WebPlatform.Tests.Core
{
   /// <summary>
   ///   Provides a test service implementation.
   /// </summary>
   public class TestService :
      Service<ProviderModule>,
      ITestService
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="TestService" /> class.
      /// </summary>
      /// <param name="module">The module. Must not be <see langword="null"/>.</param>
      public TestService([NotNull] ProviderModule module)
         : base(module)
      {
      }
   }
}