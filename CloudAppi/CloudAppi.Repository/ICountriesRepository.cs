using CloudAppi.Models;

namespace CloudAppi.Repository
{
    public interface ICountriesRepository
    {
        public List<Country> GetAll();
        public Country? GetCountry(string name);
        public void UpdateCountry(Country country);
        public void SaveCountry(Country country);
        public void DeleteCountry(string name);
        public bool CountryExists(string name);
    }
}