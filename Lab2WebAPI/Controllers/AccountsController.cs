using Lab2WebAPI.Models;
using Lab2WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountServices services;

        public AccountsController(IAccountServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            return Ok(await services.GetAccounts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount([FromRoute] string id)
        {
            return Ok(await services.GetAccount(id));
        }

        [HttpGet("{code}/{pin}")]
        public async Task<IActionResult> Login([FromRoute] string code, [FromRoute] string pin)
        {
            return Ok(await services.GetAccount(code, pin));
        }

        [HttpPost]
        public async Task<IActionResult> PostAccount([FromBody] Account account)
        {
            return Ok(await services.AddAccount(account));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] string id)
        {
            return Ok(await services.DeleteAccount(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount([FromRoute] string id, [FromBody] Account account)
        {
            return Ok(await services.EditAccount(account));
        }

    }
}
