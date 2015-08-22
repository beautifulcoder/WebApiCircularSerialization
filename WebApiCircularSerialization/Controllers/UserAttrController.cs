using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiCircularSerialization.Models;
using WebApiCircularSerialization.Models.Contexts;
using WebApiCircularSerialization.Models.Repositories;

namespace WebApiCircularSerialization.Controllers
{
    public class UserAttrController : ApiController
    {
        private readonly IUserAttrRepository repo;

        public UserAttrController()
        {
            repo = new UserAttrRepository(new ApplicationDbContext());
        }

        public UserAttrController(IUserAttrRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<UserAttr>> Get()
        {
            return await repo.AllAsync();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
