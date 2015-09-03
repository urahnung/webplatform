using WebPlatform.Core.Composition;

namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Provides repository services.
   /// </summary>
   public class DataModule : Module
   {
      /// <summary>
      ///    Initializes a new instance of the <see cref="DataModule"/> class.
      /// </summary>
      /// <param name="registrar">The service registrar. Must not be <see langword="null" />.</param>
      public DataModule(IRegistrar registrar) :
         base(registrar)
      {
         registrar.Register<IConnection, Connection>();
      }
   }
}
