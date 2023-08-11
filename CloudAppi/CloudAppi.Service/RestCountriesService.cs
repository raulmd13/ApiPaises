using AutoMapper;
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
    public class RestCountriesService : IRestCountriesService
    {
        private readonly string UrlBaseCountriesRest;
        private readonly string EndpointCountryByNameCountriesRest;
        private readonly string EndpointAllCountriesCountriesRest;
        private readonly string EndpointFlagsCountriesRest;
        private readonly HttpClient HttpClient;
        private readonly ICountriesRepository CountriesRepository;
        public readonly IMapper Mapper;

        public RestCountriesService(ExternalServices externalServices, ICountriesRepository countriesRepository, IMapper mapper)
        {
            UrlBaseCountriesRest = externalServices.UrlBaseCountriesRest;
            EndpointAllCountriesCountriesRest = externalServices.EndpointAllCountriesCountriesRest;
            EndpointCountryByNameCountriesRest = externalServices.EndpointCountryByNameCountriesRest;
            EndpointFlagsCountriesRest = externalServices.EndpointFlagsCountriesRest;

            this.CountriesRepository = countriesRepository;

            this.Mapper = mapper;
            this.HttpClient = new HttpClient();
        }

        public List<CountryApiDTO> GetAllCountries()
        {
            var responce = HttpClient.GetStringAsync((UrlBaseCountriesRest + EndpointAllCountriesCountriesRest)).Result;
            return JsonSerializer.Deserialize<List<CountryApiDTO>>(responce.ToString());
        }

        public virtual CountryApiDTO GetCountryByName(string name)
        {
            var responce = HttpClient.GetStringAsync((UrlBaseCountriesRest + EndpointCountryByNameCountriesRest).Replace("{name}", name)).Result;
            return JsonSerializer.Deserialize<List<CountryApiDTO>>(responce.ToString()).FirstOrDefault();
        }

        public string GetFlagOf(string name)
        {
            CountryApiDTO country = GetCountryByName(name);
            string FlagUrl = country.flags.svg;

            if (!string.IsNullOrEmpty(FlagUrl))
            {
                return GetSvgAsBase64FromUrl(FlagUrl);
            }

            return null;
        }

        public Country SaveRestCountry(string name)
        {
            CountryApiDTO countryApiDTO = GetCountryByName(name);
            Country country = Mapper.Map<Country>(countryApiDTO);
            CountriesRepository.SaveCountry(country);

            return country;
        }

        private string GetSvgAsBase64FromUrl(string url)
        {
            var imageBytes = HttpClient.GetByteArrayAsync(url).Result;
            return Convert.ToBase64String(imageBytes);
        }
    }
}
