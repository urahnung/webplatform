using System;
using WebPlatform.Core.Composition;
using WebPlatform.Core.Validation;

namespace WebPlatform.Tests.Core
{
   /// <summary>
   ///   Provides a consumer module implementation for tests.
   /// </summary>
   public class ConsumerModule :
      Module
   {
      /// <summary>
      ///   Contains a lazy test service.
      /// </summary>
      private Lazy<ITestService> testService;

      /// <summary>
      ///   Initializes a new instance of the <see cref="ConsumerModule" /> class.
      /// </summary>
      /// <param name="registrar">The service registrar. Must not be <see langword="null">.</param>
      public ConsumerModule([NotNull] IRegistrar registrar, [NotNull] Lazy<ITestService> testService)
         : base(registrar)
      {
         this.testService = testService;
      }

      /// <inheritdoc />
      public override void Prepare(ILocator locator)
      {
         base.Prepare(locator);
         this.TestService = this.testService.Value;
      }

      /// <summary>
      ///   Gets or sets the locator.
      /// </summary>
      public ITestService TestService
      {
         get;
         private set;
      }
   }
}