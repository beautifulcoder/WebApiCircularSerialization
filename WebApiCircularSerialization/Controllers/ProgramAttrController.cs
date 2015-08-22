using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiCircularSerialization.Models;
using WebApiCircularSerialization.Models.Contexts;
using WebApiCircularSerialization.Models.Repositories;

namespace WebApiCircularSerialization.Controllers
{
    public class ProgramAttrController : ApiController
    {
        private readonly IProgramAttrRepository repo;

        public ProgramAttrController()
        {
            repo = new ProgramAttrRepository(new ApplicationDbContext());
        }

        public ProgramAttrController(IProgramAttrRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<ProgramAttr>> Get()
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
