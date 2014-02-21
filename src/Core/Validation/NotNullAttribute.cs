using System;

namespace WebPlatform.Core.Validation
{
   /// <summary>
   ///   Provides an attribute to ensure that arguments or return values of methods are not null.
   /// </summary>
   [AttributeUsage(AttributeTargets.Method | AttributeTargets.ReturnValue | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
   public class NotNullAttribute : Attribute
   {
   }
}
