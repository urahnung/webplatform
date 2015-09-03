using System.Collections.Generic;
using System.Linq;

namespace WebPlatform.Core.Composition
{
   /// <summary>
   ///   Provides a type catalog for modules providing services.
   /// </summary>
   public class TypeCatalog : Catalog
   {
      /// <summary>
      ///   Contains the list of module types.
      /// </summary>
      private readonly IList<ModuleType> modules;

      /// <summary>
      ///   Prevents a default instance of the <see cref="TypeCatalog" /> class from being created.
      /// </summary>
      /// <param name="modules">The modules.</param>
      private TypeCatalog(IEnumerable<ModuleType> modules)
      {
         this.modules = modules.ToList();
      }

      /// <summary>
      ///   Creates a type catalog including the specified modules.
      /// </summary>
      /// <param name="modules">The module types to include.</param>
      /// <returns>The type catalog for fluent use.</returns>
      public static TypeCatalog With(params ModuleType[] modules)
      {
         return new TypeCatalog(modules);
      }

      /// <summary>
      ///   Adds the specified modules to the catalog.
      /// </summary>
      /// <param name="modules">The module types to add.</param>
      /// <returns>The type catalog for fluent use.</returns>
      public TypeCatalog And(params ModuleType[] modules)
      {
         foreach (var module in modules)
         {
            this.modules.Add(module);
         }

         return this;
      }

      /// <inheritdoc />
      protected override IEnumerator<ModuleType> GetEnumerator()
      {
         return this.modules.GetEnumerator();
      }
   }
}