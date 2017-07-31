using Glossary.Common.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Glossary.EntityFramework.DbModel
{
    class GlossaryDBInitializer : CreateDatabaseIfNotExists<GlossaryDbContext>
    {
        protected override void Seed(GlossaryDbContext context)
        {
            // Seed Default Terms
            IList<GlossaryTerm> defaults = new List<GlossaryTerm>();
            defaults.Add(new GlossaryTerm() { term = "Abyssal plain", definition = "The ocean floor offshore from the continental margin, usually very flat with a slight slope." });
            defaults.Add(new GlossaryTerm() { term = "Accrete", definition = "To add terranes (small land masses or pieces of crust) to another, usually larger, land mass." });
            defaults.Add(new GlossaryTerm() { term = "Alkaline", definition = "Term pertaining to a highly basic, as opposed to acidic, subtance. For example, hydroxide or carbonate of sodium or potassium." });

            // Add to term DbSet
            foreach (GlossaryTerm glossary in defaults)
                context.GlossaryTerms.Add(glossary);
            
            // Perform Seed
            base.Seed(context);
        }
    }

}
