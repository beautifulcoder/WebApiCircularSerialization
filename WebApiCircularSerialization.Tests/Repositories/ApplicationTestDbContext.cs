using System.Data.Entity;
using WebApiCircularSerialization.Models;
using WebApiCircularSerialization.Models.Contexts;

namespace WebApiCircularSerialization.Tests.Repositories
{
    public class ApplicationTestDbContext : DbContext, IContext
    {
        public ApplicationTestDbContext()
            : base(@"Data Source=(LocalDb)\v11.0;
                AttachDbFilename=C:\Dev\Publish\WebApiCircularSerialization\WebApiCircularSerialization.Tests\App_Data\WebApiCircularSerializationTestDb.mdf;
                Integrated Security=True;
                Connect Timeout=30")
        {
        }

        public DbSet<UserAttr> UserAttrs { get; set; }
        public DbSet<ProgramAttr> ProgramAttrs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Program> Programs { get; set; }
    }
}
