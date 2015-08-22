using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiCircularSerialization.Models;
using WebApiCircularSerialization.Models.Contexts;
using WebApiCircularSerialization.Models.Repositories;
using WebApiCircularSerialization.Resolvers;

namespace WebApiCircularSerialization.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepository repo;

        public UserController()
        {
            repo = new UserRepository(new ApplicationDbContext());
        }

        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<User>> Get()
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new UserContractResolver();
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
