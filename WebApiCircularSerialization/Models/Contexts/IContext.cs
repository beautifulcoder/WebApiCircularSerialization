using System;
using System.Data.Entity;

namespace WebApiCircularSerialization.Models.Contexts
{
    public interface IContext : IDisposable
    {
        DbSet<UserAttr> UserAttrs { get; set; }
        DbSet<ProgramAttr> ProgramAttrs { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Program> Programs { get; set; }
    }
}
