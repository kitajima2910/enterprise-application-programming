using Lab2WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab2WebApp.Controllers
{
    public class HomeController : Controller
    {
        private const string uri = "http://localhost:58681/api/Accounts/";
        private readonly HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string accCode, string pinCode)
        {
            var res = JsonConvert.DeserializeObject<Account>(httpClient.GetStringAsync(uri + accCode).Result);

            if(res.PinCode.Equals(pinCode))
            {
                return RedirectToAction("Index", "Accounts");
            }

            ViewBag.Msg = "Error!!";

            return View();
        }
    }
}
