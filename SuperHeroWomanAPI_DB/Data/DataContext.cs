using Microsoft.EntityFrameworkCore;

namespace SuperHeroWomanAPI_DB.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) { }

        public DbSet<SuperHeroWoman> SuperHeroes { get; set; }
    }
}
