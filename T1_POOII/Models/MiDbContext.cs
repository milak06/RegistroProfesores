using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace T1_POOII.Models
{
    public class MiDbContext : DbContext
    {
        public MiDbContext() : base("MiConexion")
        {
        }

        public DbSet<Profesor> Profesores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profesor>().ToTable("Profesores");
            base.OnModelCreating(modelBuilder);
        }
    }
}
