using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApiCircularSerialization.Models.Contexts;

namespace WebApiCircularSerialization.Models.Repositories
{
    public class ProgramAttrRepository : DisposableRepository, IProgramAttrRepository
    {
        public ProgramAttrRepository(IContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProgramAttr>> AllAsync()
        {
            return await context.ProgramAttrs.ToListAsync();
        }
    }
}
