using CloudAppi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAppi.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly CountriesContext countriesContext;

        public CountriesRepository(CountriesContext countriesContext)
        {
            this.countriesContext = countriesContext;
        }

        public List<Country> GetAll()
        {
            return countriesContext.Countries.ToList();
        }

        public Country? GetCountry(string name)
        {
            return countriesContext.Countries.FirstOrDefault(x => x.Name == name);
        }


        public void UpdateCountry(Country country)
        {
            if (CountryExists(country.Name))
            {
                countriesContext.Countries.Update(country);
                countriesContext.SaveChanges();
            }
        }

        public void SaveCountry(Country country)
        {
            if (!CountryExists(country.Name))
            {
                countriesContext.Countries.Add(country);
                countriesContext.SaveChanges();
            }
        }

        public void DeleteCountry(string name)
        {
            Country? country = countriesContext.Countries.Find(name);
            if (country != null)
            {
                countriesContext.Countries.Remove(country);
                countriesContext.SaveChanges();
            }
        }

        public bool CountryExists(string name)
        {
            return (countriesContext.Countries?.Any(x => x.Name == name)).GetValueOrDefault();
        }
    }
}
