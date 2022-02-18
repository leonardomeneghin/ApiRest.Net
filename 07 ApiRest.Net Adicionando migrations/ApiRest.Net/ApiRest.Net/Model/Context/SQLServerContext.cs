using Microsoft.EntityFrameworkCore;

namespace ApiRest.Net.Model.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext() { }
        public SQLServerContext(DbContextOptions<SQLServerContext> options) :base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}
