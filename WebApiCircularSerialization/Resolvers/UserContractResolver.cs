using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace WebApiCircularSerialization.Resolvers
{
    public class UserContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property =  base.CreateProperty(member, memberSerialization);
            if (property.PropertyName == "Users")
            {
                property.ShouldSerialize = i => false;
            }
            return property;
        }
    }
}
