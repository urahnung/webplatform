using System;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Composition
{
   /// <summary>
   ///   Defines a service attribute attribute.
   /// </summary>
   [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
   public class ServiceAttribute : Attribute
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="ServiceAttribute" /> class.
      /// </summary>
      public ServiceAttribute()
      {
         this.Lifetime = Lifetime.Transient;
      }

      /// <summary>
      ///   Gets or sets the service lifetime.
      /// </summary>
      public Lifetime Lifetime
      {
         get;
         set;
      }

      /// <summary>
      ///   Gets the lifetime.
      /// </summary>
      /// <param name="type">The type. Must not be <see langword="null"/>.</param>
      /// <returns>The lifetime.</returns>
      public static Lifetime GetLifetime([NotNull] Type type)
      {
         Lifetime lifetime;
         if (type.TryGetAttributeValue<ServiceAttribute, Lifetime>(attribute => attribute.Lifetime, out lifetime))
            return lifetime;

         return Lifetime.Transient;
      }
   }
}
