using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApiCircularSerialization.Models.Contexts;

namespace WebApiCircularSerialization.Models.Repositories
{
    public class UserRepository : DisposableRepository, IUserRepository
    {
        public UserRepository(IContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> AllAsync()
        {
            return await context.Users.ToListAsync();
        }
    }
}
