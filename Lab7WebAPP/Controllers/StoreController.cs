using Lab7WebAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab7WebAPP.Controllers
{
    public class StoreController : Controller
    {
        private const string uri = "http://localhost:62820/Service1.svc";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<Store>>(httpClient.GetStringAsync($"{uri}/GetStores").Result);
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Store store)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync($"{uri}/AddStore", store).Result;
                if (model.IsSuccessStatusCode && ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
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
