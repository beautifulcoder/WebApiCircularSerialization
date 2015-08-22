using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiCircularSerialization.Models;
using WebApiCircularSerialization.Models.Contexts;
using WebApiCircularSerialization.Models.Repositories;
using WebApiCircularSerialization.Resolvers;

namespace WebApiCircularSerialization.Controllers
{
    public class ProgramController : ApiController
    {
        private readonly IProgramRepository repo;

        public ProgramController()
        {
            repo = new ProgramRepository(new ApplicationDbContext());
        }

        public ProgramController(IProgramRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Program>> Get()
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new ProgramContractResolver();
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
