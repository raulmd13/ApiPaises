using CloudAppi.Models;
using CloudAppi.Models.DTO;

namespace CloudAppi.Service
{
    public interface IRestCountriesService
    {
        List<CountryApiDTO> GetAllCountries();
        CountryApiDTO GetCountryByName(string name);
        string GetFlagOf(string name);
        Country SaveRestCountry(string name);
    }
}