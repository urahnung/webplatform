using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlatform.Core.Composition;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Logging
{
   /// <summary>
   ///   Provides logging extensions.
   /// </summary>
   public static class Logging
   {
      /// <summary>
      ///   Resolves a logger for the specified module.
      /// </summary>
      /// <typeparam name="TModule">The type of the module.</typeparam>
      /// <param name="module">The module. Must not be <see langword="null"/>.</param>
      /// <returns>The logger. Never <see langword="null"/>.</returns>
      [return: NotNull]
      public static ILogger<TModule> Logger<TModule>([NotNull] this TModule module)
         where TModule : class, IModule
      {
         return module.Locator.Resolve<ILogger<TModule>>();
      }
   }
}