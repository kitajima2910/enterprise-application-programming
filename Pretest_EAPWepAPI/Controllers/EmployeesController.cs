using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pretest_EAPWepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretest_EAPWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private EmployeeServices services = new EmployeeServices();

        public async Task<IActionResult> FindAll([FromQuery] double? min = null, [FromQuery] double? max = null)
        {

            if(min != null && max != null)
            {
                return Ok(await services.findAll(min, max));
            }
            return Ok(await services.findAll());
        }

        [HttpGet("{empID}")]
        public async Task<IActionResult> CheckLogin([FromRoute] string empID)
        {
            return Ok(await services.findOne(empID));
        }

        [HttpGet("{empID}/{password}")]
        public async Task<IActionResult> CheckLogin([FromRoute] string empID, [FromRoute] string password)
        {
            return Ok(await services.checkLogin(empID, password));
        }

        [HttpPut("{empId}/{salary}")]
        public async Task<IActionResult> UpdateSalary([FromRoute] string empId, [FromRoute] double salary)
        {
            return Ok(await services.updateSalary(empId, salary));
        }
    }
}
