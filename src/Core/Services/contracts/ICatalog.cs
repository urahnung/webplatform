using System.Collections.Generic;

namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Defines a catalog interface for modules.
   /// </summary>
   public interface ICatalog : IEnumerable<ModuleType>
   {
   }
}