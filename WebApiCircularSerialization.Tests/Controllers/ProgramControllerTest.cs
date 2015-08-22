using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCircularSerialization.Controllers;
using WebApiCircularSerialization.Models;
using WebApiCircularSerialization.Models.Repositories;

namespace WebApiCircularSerialization.Tests.Controllers
{
    [TestClass]
    public class ProgramControllerTest
    {
        [TestMethod]
        public async Task Controller_ProgramGet()
        {
            var prgs = new List<Program>();
            var mock = new Mock<IProgramRepository>();
            mock.Setup(m => m.AllAsync()).ReturnsAsync(prgs);
            var target = new ProgramController(mock.Object);
            var result = await target.Get() as IEnumerable<Program>;
            mock.Verify(m => m.AllAsync(), Times.Once);
            Assert.IsNotNull(result);
        }
    }
}
