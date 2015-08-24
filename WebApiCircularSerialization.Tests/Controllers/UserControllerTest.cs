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
    public class UserControllerTest
    {
        [TestMethod]
        public async Task Controller_UserGet()
        {
            var usrs = new List<User>();
            var mock = new Mock<IUserRepository>();
            mock.Setup(m => m.AllAsync()).ReturnsAsync(usrs);
            var target = new UserController(mock.Object);
            var result = await target.Get() as IEnumerable<User>;
            mock.Verify(m => m.AllAsync(), Times.Once);
            Assert.IsNotNull(result);
        }
    }
}
