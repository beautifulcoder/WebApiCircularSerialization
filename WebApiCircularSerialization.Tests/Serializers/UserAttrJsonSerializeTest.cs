using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebApiCircularSerialization.Models;

namespace WebApiCircularSerialization.Tests.Serializers
{
    [TestClass]
    public class UserAttrJsonSerializeTest
    {
        [TestMethod]
        public void Serializer_UserAttrJsonSerlialize()
        {
            var prgs = new List<ProgramAttr>
            {
                new ProgramAttr
                {
                    Id = 1,
                    Name = "P1"
                },
                new ProgramAttr
                {
                    Id = 2,
                    Name = "P2"
                }
            };
            var usrs = new List<UserAttr>
            {
                new UserAttr
                {
                    Id = 1,
                    Name = "U1"
                },
                new UserAttr
                {
                    Id = 2,
                    Name = "U2"
                }
            };
            prgs.ForEach(x => x.UserAttrs = usrs);
            usrs.ForEach(x => x.ProgramAttrs = prgs);
            string result = JsonConvert.SerializeObject(usrs);
            var expected = "[{\"Id\":1,\"Name\":\"U1\",\"ProgramAttrs\":[{\"Id\":1,\"Name\":\"P1\"},{\"Id\":2,\"Name\":\"P2\"}]}," +
                "{\"Id\":2,\"Name\":\"U2\",\"ProgramAttrs\":[{\"Id\":1,\"Name\":\"P1\"},{\"Id\":2,\"Name\":\"P2\"}]}]";
            Assert.AreEqual<string>(expected, result);
        }
    }
}
