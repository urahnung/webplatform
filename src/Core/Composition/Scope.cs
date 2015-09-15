using Castle.MicroKernel.Lifestyle.Scoped;
using System;
using Castle.MicroKernel.Context;

namespace WebPlatform.Core.Composition
{
   /// <summary>
   ///   Implements a service scope.
   /// </summary>
   public class Scope : IScopeAccessor
   {
      public void Dispose()
      {
         throw new NotImplementedException();
      }

      public ILifetimeScope GetScope(CreationContext context)
      {
         throw new NotImplementedException();
      }
   }
}
