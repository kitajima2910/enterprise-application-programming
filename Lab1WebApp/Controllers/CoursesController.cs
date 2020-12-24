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
        private string url = "http://localhost:53168/api/courses/";
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
                var model = httpClient.PostAsJsonAsync<Course>(url, course).Result;
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
    }
}
