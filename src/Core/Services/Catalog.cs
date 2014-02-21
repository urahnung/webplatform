using System.Collections;
using System.Collections.Generic;

namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Provides a base class implementation for module type catalogs.
   /// </summary>
   public abstract class Catalog : ICatalog
   {
      /// <summary>
      ///   Gets the enumerator to iterate through the module types.
      /// </summary>
      /// <returns>The enumerator.</returns>
      protected abstract IEnumerator<ModuleType> GetEnumerator();

      /// <inheritdoc />
      IEnumerator<ModuleType> IEnumerable<ModuleType>.GetEnumerator()
      {
         return this.GetEnumerator();
      }

      /// <inheritdoc />
      IEnumerator IEnumerable.GetEnumerator()
      {
         return this.GetEnumerator();
      }
   }
}
