using System;
using System.Collections.Generic;
using System.Reflection;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Composition
{
   /// <summary>
   ///   Defines a dependency attribute.
   /// </summary>
   [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
   public class DependsOnAttribute : Attribute
   {
      /// <summary>
      ///   Gets or sets the application setting's name the parameter depends on.
      /// </summary>
      public string AppSetting { get; set; }

      /// <summary>
      ///   Gets a parameter dependecy.
      /// </summary>
      /// <param name="parameterInfo">The parameter information. Must not be <see langword="null" />.</param>
      /// <param name="dependency">The dependency. <see langword="null"/>, if no dependency exists.</param>
      /// <returns>
      ///   <see langword="true" />, if a dependeny exists; otherwise <see langword="false" />.
      /// </returns>
      public static bool TryGetDependecy([NotNull] ParameterInfo parameterInfo, out KeyValuePair<string, string> dependency)
      {
         return parameterInfo.TryGetAttributeValue<DependsOnAttribute, KeyValuePair<string, string>>(attribute => new KeyValuePair<string, string>(parameterInfo.Name, attribute.AppSetting), out dependency);
      }
   }
}
