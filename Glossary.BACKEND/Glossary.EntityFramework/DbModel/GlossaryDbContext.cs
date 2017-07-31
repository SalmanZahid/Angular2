using Glossary.EntityFramework.DbModel;
using System;
using System.Data.Entity;
using Glossary.Common.Entities;


namespace Glossary.EntityFramework
{
    public class GlossaryDbContext : DbContext, IDisposable
    {
        public GlossaryDbContext()
            : base("GlossaryDbContext")
        {
            Database.SetInitializer(new GlossaryDBInitializer());
        }

        public DbSet<GlossaryTerm> GlossaryTerms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
