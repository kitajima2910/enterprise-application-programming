using Lab1WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab1WebApp.Controllers
{
    public class CoursesController : Controller
    {
        private const string url = "http://localhost:53168/api/courses/";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            var res = JsonConvert.DeserializeObject<IEnumerable<Course>>(httpClient.GetStringAsync(url).Result);

            return View(res);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync(url, course).Result;
                if(model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Courses");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        public IActionResult Delete(string id)
        {
            var courses = JsonConvert.DeserializeObject<Course>(httpClient.GetStringAsync(url + id).Result);

            return View(courses);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult PostDelete(string courseId)
        {
            try
            {
                var model = httpClient.DeleteAsync(url + courseId).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Courses");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        public IActionResult Details(string id)
        {
            var courses = JsonConvert.DeserializeObject<Course>(httpClient.GetStringAsync(url + id).Result);

            return View(courses);
        }

        public IActionResult Edit(string id)
        {
            var courses = JsonConvert.DeserializeObject<Course>(httpClient.GetStringAsync(url + id).Result);

            return View(courses);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            try
            {
                var model = httpClient.PutAsJsonAsync(url + course.CourseId, course).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Courses");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }
    }
}
