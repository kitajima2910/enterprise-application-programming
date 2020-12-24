using Lab1WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = CourseContext.courses.ToList();

            return Ok(courses);
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourse(string courseId)
        {
            var course = CourseContext.courses.SingleOrDefault(m => m.CourseId.Equals(courseId));

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> GetCourse(Course postCourse)
        {
            var course = CourseContext.courses.SingleOrDefault(m => m.CourseId.Equals(postCourse.CourseId));

            if(course == null)
            {
                CourseContext.courses.Add(postCourse);
                return Ok();
            }

            return BadRequest();
        }
    }
}
