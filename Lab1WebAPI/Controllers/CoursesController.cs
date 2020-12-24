using Lab1WebAPI.Contracts;
using Lab1WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1WebAPI.Controllers
{
    [ApiController]
    public class CoursesController : ControllerBase
    {
        [HttpGet(ApiRoutes.Course.GetAll)]
        public IActionResult GetAll()
        {
            var courses = CourseContext.courses.ToList();

            return Ok(courses);
        }

        [HttpGet(ApiRoutes.Course.Get)]
        public IActionResult Get(string courseId)
        {
            var course = CourseContext.courses.SingleOrDefault(m => m.CourseId.Equals(courseId));

            return Ok(course);
        }

        [HttpPost(ApiRoutes.Course.Create)]
        public IActionResult Create(Course postCourse)
        {
            var course = CourseContext.courses.SingleOrDefault(m => m.CourseId.Equals(postCourse.CourseId));

            if(course == null)
            {
                CourseContext.courses.Add(postCourse);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete(ApiRoutes.Course.Delete)]
        public IActionResult Delete(string courseId)
        {
            var course = CourseContext.courses.SingleOrDefault(m => m.CourseId.Equals(courseId));

            if (course == null) 
            {
                return BadRequest();
            }

            CourseContext.courses.Remove(course);

            return Ok();
        }

        [HttpPut(ApiRoutes.Course.Update)]
        public IActionResult Update([FromRoute] string courseId, [FromBody] Course putCourse)
        {
            var course = CourseContext.courses.SingleOrDefault(m => m.CourseId.Equals(courseId)) != null;

            if (!course)
            {
                return BadRequest();
            }

            var index = CourseContext.courses.FindIndex(m => m.CourseId.Equals(courseId));
            CourseContext.courses[index] = putCourse;

            return Ok();
        }
    }
}
