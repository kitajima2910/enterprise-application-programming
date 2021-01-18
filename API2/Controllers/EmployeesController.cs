using API2.Models;
using API2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IRemoteEmployeeService service = new RemoteEmployeeService();

        [HttpPost]
        public IActionResult PostEmployee([FromBody] Employee employee)
        {
            return Ok(service.PostEmployee(employee));
        }

        [HttpGet]
        public IActionResult GetEmployeeList()
        {
            return Ok(service.GetEmployeeList());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee([FromRoute] int id)
        {
            return Ok(service.GetEmployee(id));
        }

        [HttpPut]
        public IActionResult PutEmployee([FromBody] Employee employee)
        {
            return Ok(service.PutEmployee(employee));
        }
    }
}
