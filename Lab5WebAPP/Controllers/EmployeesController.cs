using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Lab5WebAPP.Models;

namespace Lab5WebAPP.Controllers
{
    public class EmployeesController : Controller
    {
        private const string uri = "http://localhost:53508/api/Employees/";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<Employee>>(httpClient.GetStringAsync(uri).Result);
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync(uri, employee).Result;
                if(model.IsSuccessStatusCode && ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.Msg = "Error!";
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Employee employee)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<Employee>(httpClient.GetStringAsync($"{uri}{employee.Code}/{employee.Password}").Result);

                if(model != null)
                {
                    if(model.Role)
                    {
                        return RedirectToAction("Index");
                    }

                    return RedirectToAction("Details", new { code = model.Code });
                }

                ViewBag.Msg = "Error!";
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }

        public IActionResult Details(string code)
        {
            var model = JsonConvert.DeserializeObject<Employee>(httpClient.GetStringAsync($"{uri}{code}").Result);
            return View(model);
        }
    }
}
