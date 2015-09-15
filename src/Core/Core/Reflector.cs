using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core
{
   /// <summary>
   ///   Provides reflection extensions.
   /// </summary>
   public static class Reflector
   {
      /// <summary>
      ///   Defines a forwarding delegate.
      /// </summary>
      /// <typeparam name="TResult">The type of the result.</typeparam>
      /// <param name="arguments">The method arguments. Must not be <see langword="null"/>.</param>
      /// <returns>The method result. May be <see langword="null"/>.</returns>
      public delegate TResult Forwarding<TResult>([NotNull] params object[] arguments);

      /// <summary>
      ///   Tries to get an attribute value.
      /// </summary>
      /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
      /// <typeparam name="TValue">The type of the value.</typeparam>
      /// <param name="attributeProvider">The attribute provider to get the attribute value for. Must not be <see langword="null"/>.</param>
      /// <param name="selector">The selector. Must not be <see langword="null"/>.</param>
      /// <param name="value">The value.</param>
      /// <returns><see langword="true"/>, if the a attribute value exists; otherwise <see langword="false"/>.</returns>
      public static bool TryGetAttributeValue<TAttribute, TValue>([NotNull] this ICustomAttributeProvider attributeProvider, [NotNull] Func<TAttribute, TValue> selector, out TValue value)
         where TAttribute : Attribute
      {
         var attribute = attributeProvider.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
         if (attribute != null)
         {
            value = selector(attribute);
            return true;
         }
         value = default(TValue);
         return false;
      }

      /// <summary>
      ///   Gets a method info the lambda expression selects.
      /// </summary>
      /// <typeparam name="TSource">The type of the source.</typeparam>
      /// <typeparam name="TResult">The type of the result.</typeparam>
      /// <param name="lambda">The lambda expression. Must not be <see langword="null" />.</param>
      /// <returns>
      ///   The method info. Never <see langword="null" />.
      /// </returns>
      [return: NotNull]
      public static MethodInfo GetMethod<TSource, TResult>([NotNull] Expression<Func<TSource, TResult>> lambda)
      {
         var call = lambda.Body as MethodCallExpression;
         if (call == null)
            return null;

         var method = call.Method;
         if (method.IsGenericMethod)
            method = method.GetGenericMethodDefinition();

         return method;
      }

      /// <summary>
      ///   Forwards a call to the specified method on the specified object .
      /// </summary>
      /// <typeparam name="TResult">The type of the result.</typeparam>
      /// <param name="source">The source object. Must not be <see langword="null"/>.</param>
      /// <param name="methodInfo">The method information. Must not be <see langword="null"/>.</param>
      /// <param name="typeArguments">The type arguments. Must not be <see langword="null"/>.</param>
      /// <returns>The call delegate. Never <see langword="null"/>.</returns>
      [return: NotNull]
      public static Forwarding<TResult> ForwardTo<TResult>([NotNull] this object source, [NotNull] MethodInfo methodInfo, [NotNull] params Type[] typeArguments)
      {
         if (typeArguments.Length > 0)
            methodInfo = methodInfo.MakeGenericMethod(typeArguments);

         return (object[] arguments) => (TResult)methodInfo.Invoke(source, arguments);
      }
   }
}