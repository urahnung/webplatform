using WebPlatform.Core.Composition;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Logging
{
   /// <summary>
   ///   Provides logging services.
   /// </summary>
   public class LoggingModule : Module
   {
      /// <summary>
      ///    Initializes a new instance of the <see cref="LoggingModule"/> class.
      /// </summary>
      /// <param name="registrar">The service registrar. Must not be <see langword="null" />.</param>
      public LoggingModule([NotNull] IRegistrar registrar) :
         base(registrar)
      {
         registrar.Register(typeof(ILogger<>), typeof(Logger<>));
      }
   }
}