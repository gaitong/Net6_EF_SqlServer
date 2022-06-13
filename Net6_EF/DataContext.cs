using Microsoft.EntityFrameworkCore;

namespace Net6_EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        public DbSet<Crypto> Crytos { get; set; }
    }
}
