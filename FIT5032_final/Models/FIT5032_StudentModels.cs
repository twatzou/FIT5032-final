using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FIT5032_final.Models
{
    public partial class FIT5032_StudentModels : DbContext
    {
        public FIT5032_StudentModels()
            : base("name=FIT5032_StudentModels")
        {
        }

        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Units> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>()
                .HasMany(e => e.Units)
                .WithRequired(e => e.Students)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<FIT5032_final.Models.Route> Routes { get; set; }

        public System.Data.Entity.DbSet<FIT5032_final.Models.Heritage> Heritages { get; set; }
    }
}
