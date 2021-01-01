using HBNYAPI.Models;
using HBNYAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBNYAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsServices services;

        public NewsController(INewsServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string keyword)
        {
            if(string.IsNullOrEmpty(keyword))
            {
                return Ok(await services.GetAll());
            }

            return Ok(await services.GetAll(keyword));
        }

        [HttpGet("{newsId}")]
        public async Task<IActionResult> Get([FromRoute] string newsId) => Ok(await services.Get(newsId));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] News postNews) => Ok(await services.Create(postNews));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] News putNews) => Ok(await services.Update(putNews));

        [HttpDelete("{newsId}")]
        public async Task<IActionResult> Delete([FromRoute] string newsId) => Ok(await services.Delete(newsId));
    }
}
