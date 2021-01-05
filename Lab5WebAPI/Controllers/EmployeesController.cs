using Lab5WebAPI.Models;
using Lab5WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeServices services;

        public EmployeesController(IEmployeeServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employees = await services.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetEmployeeAsync([FromRoute] string code)
        {
            var employee = await services.GetEmployee(code);
            return Ok(employee);
        }

        [HttpGet("{code}/{pass}")]
        public async Task<IActionResult> GetEmployeeAsync([FromRoute] string code, [FromRoute] string pass)
        {
            var employee = await services.CheckLogin(code, pass);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Employee employee)
        {
            return Ok(await services.Create(employee));
        }
    }
}
