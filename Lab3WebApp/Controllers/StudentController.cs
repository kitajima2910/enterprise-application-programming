using Lab3WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Lab3WebApp.Controllers
{
    public class StudentController : Controller
    {
        private string uri = "http://localhost:51404/api/Student/";
        private HttpClient httpClient = new HttpClient();

        [HttpGet]
        public IActionResult Index(string keyword)
        {
            var res = JsonConvert.DeserializeObject<IEnumerable<Student>>(httpClient.GetStringAsync(uri).Result);

            if (!string.IsNullOrEmpty(keyword))
            {
                res = JsonConvert.DeserializeObject<IEnumerable<Student>>(httpClient.GetStringAsync(uri + "?gender=" + keyword).Result);
            }
            

            return View(res);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync(uri, student).Result;
                if(model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Student");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            try
            {
                var model = httpClient.PutAsXmlAsync(uri + student.StudentId, student).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Student");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }
    }
}
