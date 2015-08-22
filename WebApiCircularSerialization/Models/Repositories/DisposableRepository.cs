using System;
using WebApiCircularSerialization.Models.Contexts;

namespace WebApiCircularSerialization.Models.Repositories
{
    public abstract class DisposableRepository
    {
        protected readonly IContext context;

        public DisposableRepository()
        {
            context = new ApplicationDbContext();
        }

        public DisposableRepository(IContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}
