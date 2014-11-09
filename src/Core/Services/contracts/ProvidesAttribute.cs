using System;
using System.Collections.Generic;
using System.Linq;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Services
{
   /// <summary>
   ///   Marks a module to be a service provider for a service.
   /// </summary>
   [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
   public class ProvidesAttribute : Attribute
   {
      /// <summary>
      ///   Initializes a new instance of the <see cref="ProvidesAttribute"/> class.
      /// </summary>
      /// <param name="serviceType">The service type provided. Must not be <see langword="null" />.</param>
      public ProvidesAttribute([NotNull] Type serviceType)
      {
         this.ServiceType = serviceType;
      }

      /// <summary>
      ///   Gets the type of the service.
      /// </summary>
      public Type ServiceType
      {
         get;
         private set;
      }

      /// <summary>
      ///   Gets all services provided.
      /// </summary>
      /// <param name="type">The type which provides services.</param>
      /// <returns>The services types provided.</returns>
      public static IEnumerable<Type> GetServices(Type type)
      {
         return Attribute.GetCustomAttributes(type, typeof(ProvidesAttribute)).Cast<ProvidesAttribute>().Select(attribute => attribute.ServiceType);
      }
   }
}
