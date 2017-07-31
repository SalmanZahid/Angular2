using Glossary.Common.Entities;
using Glossary.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Glossary.Tests
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void RowsShouldBeGreaterThanZero()
        {
            GlossaryDbContext dbContext = new GlossaryDbContext();
            int rows = dbContext.GlossaryTerms.Count();
            Assert.IsTrue(rows > 0, "Database is not empty");
        }
    }
}
