using CloudAppi.Models;
using CloudAppi.Service;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;

namespace CloudAppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService countriesService;
        private readonly NLog.Logger logger;

        public CountriesController(ILogger<CountriesController> logger, ICountriesService countriesService)
        {
            this.logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            this.countriesService = countriesService;
        }

        // GET: api/Countries
        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetAllCountries()
        {
            try
            {
                List<Country> countries = countriesService.GetAllCountries();
                if (countries == null)
                {
                    return NotFound();
                }
                return countries;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500);
            }
        }

        // GET: api/Countries/spain
        [HttpGet("{name}")]
        public ActionResult<Country> GetCountry(string name)
        {
            try
            {
                Country country = countriesService.GetCountryByName(name);

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

        // PUT: api/Countries/5
        [HttpPut("{name}")]
        public IActionResult PutCountry(string name, Country country)
        {
            try
            {
                if (name != country.Name)
                {
                    return BadRequest($"Name:{name} doesn't match the Country name:{country.Name}");
                }

                if (!countriesService.ExistCountry(name))
                {
                    return NotFound($"Country with Name:{name} not found");
                }

                countriesService.UpdateCountry(country);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500);
            }
        }

        // POST: api/Countries
        [HttpPost]
        public ActionResult<Country> PostCountry(Country country)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(country.Name))
                {
                    return BadRequest("Country name shouldn't be null or empty");
                }

                if (countriesService.ExistCountry(country.Name))
                {
                    return BadRequest($"Country with Name:{country.Name} already exists");
                }

                countriesService.SaveCountry(country);

                return CreatedAtAction(nameof(GetCountry), new { name = country.Name }, country);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500);
            }
        }

        // DELETE: api/Countries/Spain
        [HttpDelete("{name}")]
        public IActionResult DeleteCountry(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Country name shouldn't be null or empty");
                }

                if (!countriesService.ExistCountry(name))
                {
                    return NotFound($"Country with Name:{name} not found");
                }
                countriesService.DeleteCountry(name);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode(500);
            }
        }
    }
}
