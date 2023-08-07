using CloudAppi.Models;
using CloudAppi.Models.DTO;

namespace CloudAppi.Service
{
    public interface ICountriesService
    {
        void DeleteCountry(string name);
        bool ExistCountry(string name);
        List<Country> GetAllCountries();
        public Country GetCountryByName(string name);
        void SaveCountry(Country country);
        void UpdateCountry(Country country);
    }
}