using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApiCircularSerialization.Models.Contexts;

namespace WebApiCircularSerialization.Models.Repositories
{
    public class ProgramRepository : DisposableRepository, IProgramRepository
    {
        public ProgramRepository(IContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Program>> AllAsync()
        {
            return await context.Programs.ToListAsync();
        }
    }
}
