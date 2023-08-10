using Microsoft.EntityFrameworkCore;
using WebAPI_MINIMAL.Models;

namespace WebAPI_MINIMAL.Context
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<Car> Car { get; set; }

    }
}
