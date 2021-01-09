using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pretest_EAPWebAPP.Models;

namespace Pretest_EAPWebAPP.Controllers
{
    public class EmployeesController : Controller
    {
        private string uri = "http://localhost:64657/api/Employees";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Index(string empID)
        {
            ViewBag.EmpID = empID;
            return View();
        }

        public IActionResult Search(double? min = null, double? max = null)
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<Employee>>(httpClient.GetStringAsync($"{uri}").Result);
            if(min != null && max != null)
            {
                models = JsonConvert.DeserializeObject<IEnumerable<Employee>>(httpClient.GetStringAsync($"{uri}?min={min}&max={max}").Result);
            }

            return View(models);
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
                var model = JsonConvert.DeserializeObject<bool>(httpClient.GetStringAsync($"{uri}/{employee.EmpID}/{employee.Password}").Result);
                if(model)
                {
                    return RedirectToAction("Index", new { empID = employee.EmpID });
                }

                ViewBag.Msg = "Invalid Login!!";
            }
            catch (Exception)
            {
                ViewBag.Msg = "Invalid Login!!";
            }
            return View();
        }

        public IActionResult Update(string empID)
        {
            var model = JsonConvert.DeserializeObject<Employee>(httpClient.GetStringAsync($"{uri}/{empID}").Result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Employee employee)
        {
            try
            {
                var model = httpClient.PutAsJsonAsync($"{uri}/{employee.EmpID}/{employee.Salary}", employee).Result;
                if (model.IsSuccessStatusCode)
                {
                    ViewBag.Msg = "Successfuly!";
                }
                else
                {
                    ViewBag.Msg = "Fail!!";
                }
            }
            catch (Exception)
            {
                ViewBag.Msg = "Fail!!";
            }
            return View();
        }
    }
}
