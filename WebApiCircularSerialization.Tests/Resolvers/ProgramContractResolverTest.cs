using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebApiCircularSerialization.Models;
using WebApiCircularSerialization.Resolvers;

namespace WebApiCircularSerialization.Tests.Resolvers
{
    [TestClass]
    public class ProgramContractResolverTest
    {
        [TestMethod]
        public void Resolver_ProgramContractResolver()
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
            var settings = new JsonSerializerSettings { ContractResolver = new ProgramContractResolver() };
            var result = JsonConvert.SerializeObject(prgs, Formatting.None, settings);
            Assert.IsNotNull(result);
            var expected = "[{\"Id\":1,\"Name\":\"P1\",\"Users\":[{\"Id\":1,\"Name\":\"U1\"},{\"Id\":2,\"Name\":\"U2\"}]}," +
                "{\"Id\":2,\"Name\":\"P2\",\"Users\":[{\"Id\":1,\"Name\":\"U1\"},{\"Id\":2,\"Name\":\"U2\"}]}]";
            Assert.AreEqual<string>(expected, result);
        }
    }
}
