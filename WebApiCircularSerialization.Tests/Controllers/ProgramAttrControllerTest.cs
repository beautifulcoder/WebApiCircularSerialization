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
    public class ProgramAttrControllerTest
    {
        [TestMethod]
        public async Task Controller_ProgramAttrGet()
        {
            var prgs = new List<ProgramAttr>();
            var mock = new Mock<IProgramAttrRepository>();
            mock.Setup(m => m.AllAsync()).ReturnsAsync(prgs);
            var target = new ProgramAttrController(mock.Object);
            var result = await target.Get() as IEnumerable<ProgramAttr>;
            mock.Verify(m => m.AllAsync(), Times.Once);
            Assert.IsNotNull(result);
        }
    }
}
