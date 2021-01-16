using Lab9API.Services;
using Lab9DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab9API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private IServices services = new ServicesImpl();

        [HttpGet]
        public IActionResult GetCountries() => Ok(services.GetCountries());

        [HttpGet("{id}")]
        public IActionResult GetCountry(int id) => Ok(services.GetCountry(id));

        [HttpPost]
        public IActionResult Create(Country country) => Ok(services.Create(country));

        [HttpPut]
        public IActionResult Update(Country country) => Ok(services.Update(country));

        [HttpDelete]
        public IActionResult Delete(int id) => Ok(services.Delete(id));
    }
}
