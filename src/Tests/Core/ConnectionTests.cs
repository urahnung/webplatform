using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPlatform.Core.Data;
using WebPlatform.Core.Composition;

namespace WebPlatform.Tests.Core
{
   /// <summary>
   ///   Test the connection service.
   /// </summary>
   [TestClass]
   public class ConnectionTests
   {
      /// <summary>
      ///   Tests to create a connection.
      /// </summary>
      [TestMethod]
      public void TestCreateConnection()
      {
         var moduleTypes = TypeCatalog.With(ModuleType.For<DataModule>());
         using (var runtime = Runtime.With(moduleTypes))
         {
            using (var scope = runtime.Scope())
            {
               var connection = runtime.Locator.Resolve<IConnection>();
            }
         }
      }
   }
}