using System.Data.Entity;
using WebPlatform.Core.Composition;
using WebPlatform.Core.Validation;

namespace WebPlatform.Core.Data
{
   /// <summary>
   ///   Provides a connection implementation.
   /// </summary>
   [Service(Lifetime = Lifetime.Scope)]
   public class Connection :
      DbContext,
      IConnection
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Connection" /> class.
      /// </summary>
      /// <param name="module">The module. Must not be <see langword="null" />.</param>
      /// <param name="connectionName">The connection name. Must not be <see langword="null"/> or white-space.</param>
      public Connection([NotNull] DataModule module, [NotNull] [DependsOn(AppSetting = "data.connect")] string connectionName)
         : base(connectionName)
      {
         this.Module = module;
      }

      /// <summary>
      ///   Gets the module. Must not be <see langword="null" />.
      /// </summary>
      IModule IService.Module
      {
         get
         {
            return this.Module;
         }
      }

      /// <summary>
      ///   Gets the module. Never <see langword="null" />.
      /// </summary>
      public DataModule Module
      {
         [return: NotNull]
         get;
         private set;
      }

      /// <inheritdoc />
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
      }
   }
}
