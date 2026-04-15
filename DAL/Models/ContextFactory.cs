using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Models
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=VirtualEventSystem;Integrated Security=true"
            );

            return new Context(optionsBuilder.Options);
        }
    }
}