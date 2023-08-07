using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAppi.Repository
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<CountriesContext>
    {
        public CountriesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CountriesContext>();
            optionsBuilder.UseInMemoryDatabase("CountriesContext");

            return new CountriesContext(optionsBuilder.Options);
        }
    }
}
