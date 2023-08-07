using CloudAppi.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudAppi.Repository
{
    public class CountriesContext : DbContext
    {
        public CountriesContext(DbContextOptions<CountriesContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
    }
}
