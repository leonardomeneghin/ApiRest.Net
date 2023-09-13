using Microsoft.EntityFrameworkCore;

namespace ApiRest.Net.Model.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext() { }
        public SQLServerContext(DbContextOptions<SQLServerContext> options) :base(options)
        {

        }
        //Lista tudo o que pode ser recuperado ou persistido (get; set;) no banco
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<PlayerData> PlayerData { get; set; }
    }
}
