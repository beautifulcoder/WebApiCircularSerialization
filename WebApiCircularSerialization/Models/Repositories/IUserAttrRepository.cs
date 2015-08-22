using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiCircularSerialization.Models.Repositories
{
    public interface IUserAttrRepository : IDisposable
    {
        Task<IEnumerable<UserAttr>> AllAsync();
    }
}
