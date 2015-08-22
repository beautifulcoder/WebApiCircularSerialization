using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApiCircularSerialization.Models.Contexts;

namespace WebApiCircularSerialization.Models.Repositories
{
    public class UserAttrRepository : DisposableRepository, IUserAttrRepository
    {
        public UserAttrRepository(IContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserAttr>> AllAsync()
        {
            return await context.UserAttrs.ToListAsync();
        }
    }
}
