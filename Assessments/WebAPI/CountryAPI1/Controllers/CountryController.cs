using CountryAPI1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CountryAPI1.Models;

namespace CountryAPI1.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> countries = new List<Country>()
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "USA", Capital = "Washington DC" }
        };

        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            return Ok(countries);
        }

        [HttpGet]
        public IHttpActionResult GetCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }

        [HttpPost]
        public IHttpActionResult AddCountry(Country country)
        {
            if (country == null)
                return BadRequest();

            countries.Add(country);

            return Ok("Country Added Successfully");
        }

        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, Country country)
        {
            var existingCountry =
                countries.FirstOrDefault(c => c.ID == id);

            if (existingCountry == null)
                return NotFound();

            existingCountry.CountryName = country.CountryName;
            existingCountry.Capital = country.Capital;

            return Ok("Country Updated Successfully");
        }

        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country =
                countries.FirstOrDefault(c => c.ID == id);

            if (country == null)
                return NotFound();

            countries.Remove(country);

            return Ok("Country Deleted Successfully");
        }
    }
}