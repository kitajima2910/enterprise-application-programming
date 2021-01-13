using Lab7WebAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7WebAPP.Controllers
{
    public class StaffController : Controller
    {
        private const string uri = "http://localhost:62820/Service1.svc";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<Staff>>(httpClient.GetStringAsync($"{uri}/GetStaffs").Result);
            return View(models);
        }

        public IActionResult Create()
        {
            var list = JsonConvert.DeserializeObject<IEnumerable<Store>>(httpClient.GetStringAsync($"{uri}/GetStores").Result);
            ViewBag.Stores = new SelectList(list, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            try
            {
                //var model = httpClient.PostAsJsonAsync($"{uri}/AddStaff", staff).Result;
                var model = httpClient.PostAsync<Staff>($"{uri}/AddStaff", staff, new JsonMediaTypeFormatter { UseDataContractJsonSerializer = true }).Result;
                if (model.IsSuccessStatusCode && ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                var list = JsonConvert.DeserializeObject<IEnumerable<Store>>(httpClient.GetStringAsync($"{uri}/GetStores").Result);
                ViewBag.Stores = new SelectList(list, "Id", "Name");

                ViewBag.MSg = "Error";
            }
            catch (Exception)
            {
                ViewBag.MSg = "Error";
            }
            return View();
        }
    }
}
