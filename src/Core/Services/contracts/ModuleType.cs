using System;
using System.Collections.Generic;

namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Represents a module type.
   /// </summary>
   public class ModuleType
   {
      /// <summary>
      ///   Prevents a default instance of the <see cref="ModuleType"/> class from being created.
      /// </summary>
      private ModuleType()
      {
      }

      /// <summary>
      ///   Gets the name.
      /// </summary>
      public string Name
      {
         get;
         private set;
      }

      /// <summary>
      ///   Gets the type.
      /// </summary>
      public Type Type
      {
         get;
         private set;
      }

      /// <summary>
      ///   Gets the module type for <typeparamref name="TModule"/>.
      /// </summary>
      /// <typeparam name="TModule">The type of the module.</typeparam>
      /// <returns>The module type. Never <see langword="null"/>.</returns>
      public static ModuleType For<TModule>()
         where TModule : IModule
      {
         return new ModuleType { Type = typeof(TModule), Name = typeof(TModule).Name };
      }

      /// <ineritdoc />
      public override bool Equals(object value)
      {
         ModuleType moduleType = value as ModuleType;

         if (moduleType == null)
            return false;

         return EqualityComparer<Type>.Default.Equals(this.Type, moduleType.Type);
      }

      /// <ineritdoc />
      public override int GetHashCode()
      {
         return EqualityComparer<Type>.Default.GetHashCode(this.Type);
      }
   }
}