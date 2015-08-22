using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiCircularSerialization.Models.Repositories
{
    public interface IProgramRepository : IDisposable
    {
        Task<IEnumerable<Program>> AllAsync();
    }
}
