using Lab3WebAPI.Models;
using Lab3WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentServices services;

        public StudentController(IStudentServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<IActionResult> Gets([FromQuery] string gender)
        {
            var list = services.FindAll();

            if (!string.IsNullOrEmpty(gender))
            {
                list = services.FindAll(gender);
            }
            
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var std = services.FindById(id);
            return Ok(std);
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            try
            {
                services.Create(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Student student)
        {
            try
            {
                services.Update(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


    }
}
