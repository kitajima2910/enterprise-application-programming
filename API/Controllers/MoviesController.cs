using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieServices services = new MovieServicesImpl();

        [HttpPost]
        public IActionResult PostMovie([FromBody] Movie movie)
        {
            return Ok(services.PostMovie(movie));
        }

        [HttpGet]
        public IActionResult GetMoviesList()
        {
            return Ok(services.GetMoviesList());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            return Ok(services.DeleteMovie(id));
        }
    }
}
