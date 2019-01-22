using Microsoft.EntityFrameworkCore;
using SingleDDD.Core.Domain.Entities;
using SingleDDD.Core.Domain.Interfaces.Infrastructures.Contexts;
using System.Threading.Tasks;

namespace SingleDDD.Core.Infrastructures.Data.Contexts
{
    public class SingleDDDContext : DbContext, ISingleDDDContext
    {
        protected SingleDDDContext()
        {
            base.Database.EnsureCreated();
        }

        public SingleDDDContext(DbContextOptions options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
