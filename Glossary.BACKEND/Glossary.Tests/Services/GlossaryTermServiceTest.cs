using Glossary.BLL.DTOs;
using Glossary.BLL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Glossary.Tests.Services
{
    [TestClass]
    public class GlossaryTermServiceTest
    {
        private readonly GlossaryItemService service = new GlossaryItemService();

        [TestMethod]
        public void GetAllByService()
        {
            var result = service.GetAll();
            Assert.IsNotNull(result, "Database has records " + result.Count());
        }

        [TestMethod]
        public void FindById()
        {
            var result1 = service.FindById(1);
            Assert.IsNotNull(result1, "Record found");

            var result2 = service.FindById(2987);
            Assert.IsNull(result2, "Record not found");
        }

        [TestMethod]
        public void AddNewGlossaryTermRecord()
        {
            GlossaryTermDTO term = new GlossaryTermDTO()
             {
                 term = "diviness",
                 definition = "Eternal, holy, or otherwise godlike"
             };

            service.Add(term);
            Assert.IsTrue(term.Id > 0, "New glossary term added");

        }

        [TestMethod]
        public void UpdateGlossaryTermRecord()
        {
            int id = 2;
            GlossaryTermDTO newGlossaryTerm = new GlossaryTermDTO()
            {
                Id = id,
                term = "divine",
                definition = "Eternal, holy, or otherwise godlike"
            };
            service.Update(newGlossaryTerm);
            GlossaryTermDTO getUpdatedRecord = service.FindById(id);
            Assert.AreEqual(newGlossaryTerm.term, getUpdatedRecord.term, "Updated Successfully");

        }

        [TestMethod]
        public void RemoveGlossaryTermRecord()
        {
            int id = 1;
            bool removed = service.Delete(id);
            Assert.IsTrue(removed, "Succesfully deleted");
        }
    }
}
