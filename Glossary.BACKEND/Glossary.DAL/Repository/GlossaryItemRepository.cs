using Glossary.EntityFramework;
using Glossary.Data.Interfaces;
using System.Linq;
using Glossary.Common.Entities;
using System.Collections.Generic;
using System;

namespace Glossary.DAL.Repository
{
    public sealed class GlossaryTermRepository : IBaseRepository<GlossaryTerm>
    {
        /// <summary>
        /// Get all glossary terms
        /// </summary>
        /// <returns>IEnumerable<GlossaryTerm></returns>
        public IEnumerable<GlossaryTerm> GetAll()
        {
            using (GlossaryDbContext dbContext = new GlossaryDbContext())
            {
                return dbContext.GlossaryTerms.ToList();
            }
        }

        /// <summary>
        /// Find glossary term by id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>GlossaryTerm</returns>
        public GlossaryTerm FindById(int Id)
        {
            using (GlossaryDbContext dbContext = new GlossaryDbContext())
            {
                return dbContext.GlossaryTerms.Find(Id);
            }
        }

        /// <summary>
        /// Add new term in data store
        /// </summary>
        /// <param name="entity">GlossaryTerm</param>
        public void Add(GlossaryTerm entity)
        {
            using (GlossaryDbContext dbContext = new GlossaryDbContext())
            {
                dbContext.GlossaryTerms.Add(entity);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Remove term from data store
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Boolean</returns>
        public bool Delete(int id)
        {
            try
            {
                using (GlossaryDbContext dbContext = new GlossaryDbContext())
                {
                    var entity = dbContext.GlossaryTerms.Find(id);
                    dbContext.GlossaryTerms.Remove(entity);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Update term in data store
        /// </summary>
        /// <param name="entity">GlossaryTerm</param>
        public void Update(GlossaryTerm entity)
        {
            using (GlossaryDbContext dbContext = new GlossaryDbContext())
            {
                dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

    }
}
