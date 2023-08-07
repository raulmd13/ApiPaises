using CloudAppi.Models;
using CloudAppi.Models.DTO;
using CloudAppi.Service;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;

namespace CloudAppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestCountriesController : Controller
    {
        private readonly ICountriesService countriesService;
        private readonly IRestCountriesService restCountriesService;
        private readonly NLog.Logger logger;

        public RestCountriesController(ILogger<RestCountriesController> logger, IRestCountriesService restCountriesService, ICountriesService countriesService)
        {
            this.logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            this.restCountriesService = restCountriesService;
            this.countriesService = countriesService;
        }

        // GET: api/RestCountries/GetAllRestCountries
        [HttpGet]
        public ActionResult<IEnumerable<CountryApiDTO>> GetAllRestCountries()
        {
            try
            {
                List<CountryApiDTO> countries = restCountriesService.GetAllCountries();
                if (countries == null)
                {
                    return NotFound("Please try again later");
                }
                return countries;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500);
            }
        }

        // GET: api/RestCountries/spain
        [HttpGet("{name}")]
        public ActionResult<CountryApiDTO> GetRestCountry(string name)
        {
            try
            {
                CountryApiDTO country = restCountriesService.GetCountryByName(name);

                if (country == null)
                {
                    return NotFound($"Country with Name:{name} not found");
                }

                return country;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500);
            }
        }


        // GET: api/RestCountries/flag/spain
        [HttpGet("flag/{name}")]
        public ActionResult<string> GetFlag(string name)
        {
            try
            {
                string flag = restCountriesService.GetFlagOf(name);

                if (flag == null)
                {
                    return NotFound($"Flag of country with Name:{name} not found");
                }

                return flag;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500);
            }
        }

        // POST: api/RestCountries/spain
        [HttpPost]
        public ActionResult<Country> SaveRestCountry(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Country name shouldn't be null or empty");
                }

                if (countriesService.ExistCountry(name))
                {
                    return BadRequest($"Country with Name:{name} already exists");
                }

                Country country = restCountriesService.SaveRestCountry(name);

                return CreatedAtAction(nameof(SaveRestCountry), new { name = country.Name }, country);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500);
            }
        }

    }
}
