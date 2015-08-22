using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebApiCircularSerialization.Models;
using WebApiCircularSerialization.Resolvers;

namespace WebApiCircularSerialization.Tests.Resolvers
{
    [TestClass]
    public class UserContractResolverTest
    {
        [TestMethod]
        public void Resolver_UserContractResolver()
        {
            var prgs = new List<Program>
            {
                new Program
                {
                    Id = 1,
                    Name = "P1"
                },
                new Program
                {
                    Id = 2,
                    Name = "P2"
                }
            };
            var usrs = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "U1"
                },
                new User
                {
                    Id = 2,
                    Name = "U2"
                }
            };
            prgs.ForEach(x => x.Users = usrs);
            usrs.ForEach(x => x.Programs = prgs);
            var settings = new JsonSerializerSettings { ContractResolver = new UserContractResolver() };
            var result = JsonConvert.SerializeObject(usrs, Formatting.None, settings);
            Assert.IsNotNull(result);
            var expected = "[{\"Id\":1,\"Name\":\"U1\",\"Programs\":[{\"Id\":1,\"Name\":\"P1\"},{\"Id\":2,\"Name\":\"P2\"}]}," +
                "{\"Id\":2,\"Name\":\"U2\",\"Programs\":[{\"Id\":1,\"Name\":\"P1\"},{\"Id\":2,\"Name\":\"P2\"}]}]";
            Assert.AreEqual<string>(expected, result);
        }
    }
}
