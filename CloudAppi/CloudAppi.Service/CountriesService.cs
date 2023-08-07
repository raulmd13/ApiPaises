using CloudAppi.Models;
using CloudAppi.Models.DTO;
using CloudAppi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudAppi.Service
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepository CountriesRepository;
        public CountriesService(ICountriesRepository countriesRepository)
        {
            this.CountriesRepository = countriesRepository;
        }

        public void DeleteCountry(string name)
        {
            CountriesRepository.DeleteCountry(name);
        }

        public bool ExistCountry(string name)
        {
            return CountriesRepository.CountryExists(name);
        }

        public List<Country> GetAllCountries()
        {
            return CountriesRepository.GetAll();
        }

        public Country GetCountryByName(string name)
        {
            return CountriesRepository.GetCountry(name);
        }

        public void SaveCountry(Country country)
        {
            CountriesRepository.SaveCountry(country);
        }

        public void UpdateCountry(Country country)
        {
            CountriesRepository.UpdateCountry(country);
        }

    }
}
