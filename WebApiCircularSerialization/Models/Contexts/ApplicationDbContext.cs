using System.Data.Entity;

namespace WebApiCircularSerialization.Models.Contexts
{
    public class ApplicationDbContext : DbContext, IContext
    {
        public ApplicationDbContext()
            : base(@"Data Source=(LocalDb)\v11.0;
                AttachDbFilename=C:\Dev\Publish\WebApiCircularSerialization\WebApiCircularSerialization\App_Data\WebApiCircularSerializationDb.mdf;
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
