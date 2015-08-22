using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApiCircularSerialization.Models.Repositories;

namespace WebApiCircularSerialization.Tests.Repositories
{
    [TestClass]
    public class ProgramAttrRepositoryTest
    {
        [TestMethod]
        public async Task Repository_ProgramAttrAllAsync()
        {
            Database.SetInitializer(new ApplicationTestDatabaseInitialize());
            var context = new ApplicationTestDbContext();
            context.Database.Log = s => Debug.WriteLine(s);
            var repo = new ProgramAttrRepository(context);
            var result = await repo.AllAsync();
            Assert.AreEqual<int>(2, result.Count());
            Assert.AreEqual<int>(2, result.First().UserAttrs.Count());
        }
    }
}
