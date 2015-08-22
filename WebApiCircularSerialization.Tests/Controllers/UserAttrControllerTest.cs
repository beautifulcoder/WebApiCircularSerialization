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
    public class UserAttrControllerTest
    {
        [TestMethod]
        public async Task Controller_UserAttrGet()
        {
            var usrs = new List<UserAttr>();
            var mock = new Mock<IUserAttrRepository>();
            mock.Setup(m => m.AllAsync()).ReturnsAsync(usrs);
            var target = new UserAttrController(mock.Object);
            var result = await target.Get() as IEnumerable<UserAttr>;
            mock.Verify(m => m.AllAsync(), Times.Once);
            Assert.IsNotNull(result);
        }
    }
}
