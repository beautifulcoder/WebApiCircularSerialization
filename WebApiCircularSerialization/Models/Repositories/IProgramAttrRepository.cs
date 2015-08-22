using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiCircularSerialization.Models.Repositories
{
    public interface IProgramAttrRepository : IDisposable
    {
        Task<IEnumerable<ProgramAttr>> AllAsync();
    }
}
