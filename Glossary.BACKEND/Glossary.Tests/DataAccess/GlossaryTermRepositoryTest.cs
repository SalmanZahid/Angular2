using Microsoft.VisualStudio.TestTools.UnitTesting;
using Glossary.DAL.Repository;
using System.Linq;
using Glossary.Common.Entities;

namespace Glossary.Tests.DataAccess
{
    [TestClass]
    public class GlossaryTermRepositoryTest
    {
        private readonly GlossaryTermRepository repository = new GlossaryTermRepository();

        [TestMethod]
        public void GetAllByrepositoryWithRepository()
        {
            var result = repository.GetAll();
            Assert.IsNotNull(result, "Database has records " + result.Count());
        }

        [TestMethod]
        public void FindByIdWithRepository()
        {
            var result1 = repository.FindById(1);
            Assert.IsNotNull(result1, "Record found");

            var result2 = repository.FindById(2987);
            Assert.IsNull(result2, "Record not found");
        }

        [TestMethod]
        public void AddNewGlossaryTermRecordWithRepository()
        {
            GlossaryTerm newTerm = new GlossaryTerm()
            {
                term = "flawless",
                definition = "Without any imperfections or defects; perfect."
            };

            repository.Add(newTerm);
            Assert.IsTrue(newTerm.Id > 0, "New glossary term added");

        }

        [TestMethod]
        public void UpdateGlossaryTermRecordWithRepository()
        {
            int id = 5;
            GlossaryTerm updatedTerm = new GlossaryTerm()
            {
                Id = id,
                term = "Aalenian",
                definition = "A stage at the lowest level of the Middle Jurassic, lying next below the Bajocian; the geological age corresponding to this stage."
            };
            repository.Update(updatedTerm);
            GlossaryTerm getUpdatedRecord = repository.FindById(id);
            Assert.AreEqual(updatedTerm.term, getUpdatedRecord.term, "Updated Successfully");

        }

        [TestMethod]
        public void RemoveGlossaryTermRecordWithRepository()
        {
            int id = 3;
            bool removed = repository.Delete(id);
            Assert.IsTrue(removed, "Succesfully deleted");
        }
    }
}
