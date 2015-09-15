using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPlatform.Core.Composition;
using WebPlatform.Core.Logging;

namespace WebPlatform.Tests.Core
{
   /// <summary>
   ///   Tests the logging service.
   /// </summary>
   [TestClass]
   public class LoggingTests
   {
      /// <summary>
      ///   Tests to resove a logger.
      /// </summary>
      [TestMethod]
      public void TestResolveLogger()
      {
         using (var runtime = Runtime.Default())
         {
            using (var scope = runtime.Scope())
            {
               var logger = runtime.Logger();
               Assert.IsNotNull(logger);
               Assert.AreSame(runtime, logger.Owner);
            }
         }
      }
   }
}