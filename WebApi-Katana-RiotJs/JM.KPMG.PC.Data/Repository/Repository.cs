using JM.KPMG.PC.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.KPMG.PC.Data.Core.Repository
{
    public class Repository : PCDBContext
    {
        public Repository() : base(nameOrConnectionString: "PCDbConnection")
        {
            Database.SetInitializer<Repository>(new DropCreateDatabaseIfModelChanges<Repository>());
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

    }
}
