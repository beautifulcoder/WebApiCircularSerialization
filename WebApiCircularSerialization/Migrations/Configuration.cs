using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using WebApiCircularSerialization.Models;
using WebApiCircularSerialization.Models.Contexts;

namespace WebApiCircularSerialization.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(
                new User
                {
                    Id = 1,
                    Name = "User 1",
                    Programs = new List<Program>()
                },
                new User
                {
                    Id = 2,
                    Name = "User 2",
                    Programs = new List<Program>()
                });
            context.Programs.AddOrUpdate(
                new Program
                {
                    Id = 1,
                    Name = "Program 1",
                    Users = new List<User>()
                },
                new Program
                {
                    Id = 2,
                    Name = "Program 2",
                    Users = new List<User>()
                });
            context.UserAttrs.AddOrUpdate(
                new UserAttr
                {
                    Id = 1,
                    Name = "UserAttr 1",
                    ProgramAttrs = new List<ProgramAttr>()
                },
                new UserAttr
                {
                    Id = 2,
                    Name = "UserAttr 2",
                    ProgramAttrs = new List<ProgramAttr>()
                });
            context.ProgramAttrs.AddOrUpdate(
                new ProgramAttr
                {
                    Id = 1,
                    Name = "ProgramAttr 1",
                    UserAttrs = new List<UserAttr>()
                },
                new ProgramAttr
                {
                    Id = 2,
                    Name = "ProgramAttr 2",
                    UserAttrs = new List<UserAttr>()
                });
            context.SaveChanges();
            if (context.Users.First().Programs.Count() == 0 && context.Programs.First().Users.Count() == 0)
            {
                var user1 = context.Users.First(x => x.Id == 1);
                var user2 = context.Users.First(x => x.Id == 2);
                var prg1 = context.Programs.First(x => x.Id == 1);
                var prg2 = context.Programs.First(x => x.Id == 2);
                foreach (var u in context.Users)
                {
                    u.Programs.Add(prg1);
                    u.Programs.Add(prg2);
                }
                foreach (var p in context.Programs)
                {
                    p.Users.Add(user1);
                    p.Users.Add(user2);
                }
                context.SaveChanges();
            }
            if (context.UserAttrs.First().ProgramAttrs.Count() == 0 && context.ProgramAttrs.First().UserAttrs.Count() == 0)
            {
                var userAttr1 = context.UserAttrs.First(x => x.Id == 1);
                var userAttr2 = context.UserAttrs.First(x => x.Id == 2);
                var prgAttr1 = context.ProgramAttrs.First(x => x.Id == 1);
                var prgAttr2 = context.ProgramAttrs.First(x => x.Id == 2);
                foreach (var u in context.UserAttrs)
                {
                    u.ProgramAttrs.Add(prgAttr1);
                    u.ProgramAttrs.Add(prgAttr2);
                }
                foreach (var p in context.ProgramAttrs)
                {
                    p.UserAttrs.Add(userAttr1);
                    p.UserAttrs.Add(userAttr2);
                }
                context.SaveChanges();
            }
        }
    }
}
