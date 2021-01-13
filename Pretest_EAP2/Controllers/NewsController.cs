using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pretest_EAP2.Models;
using Pretest_EAP2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretest_EAP2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsServices services = new NewsServices();

        [HttpPost]
        public IActionResult Create([FromBody] News news)
        {
            return Ok(services.PostNews(news));
        }

        [HttpDelete("{newsId}")]
        public IActionResult Delete([FromRoute] string newsId)
        {
            return Ok(services.DeleteNews(newsId));
        }
    }
}
