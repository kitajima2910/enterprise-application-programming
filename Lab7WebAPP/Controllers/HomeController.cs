using Lab7WebAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab7WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private const string uri = "http://localhost:62820/Service1.svc";
        private HttpClient httpClient = new HttpClient();


        public IActionResult Index(string keyword, string keyname)
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<StoreStaff>>(httpClient.GetStringAsync($"{uri}/GetStoreStaffs").Result);

            var list = JsonConvert.DeserializeObject<IEnumerable<Store>>(httpClient.GetStringAsync($"{uri}/GetStores").Result);
            ViewBag.Stores = new SelectList(list, "Id", "Name");

            var list1 = JsonConvert.DeserializeObject<IEnumerable<Staff>>(httpClient.GetStringAsync($"{uri}/GetStaffs").Result);
            ViewBag.Staffs = new SelectList(list1, "Name", "Name");

            if (!string.IsNullOrWhiteSpace(keyword) && !string.IsNullOrWhiteSpace(keyname))
            {
                models = models.Where(m => m.Store.Id == int.Parse(keyword) && m.Staff.Name.Contains(keyname)).ToList();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    models = models.Where(m => m.Store.Id == int.Parse(keyword)).ToList();
                }
                else if (!string.IsNullOrWhiteSpace(keyname))
                {
                    models = models.Where(m => m.Staff.Name.Contains(keyname)).ToList();
                }
            }

            

            return View(models);
        }
    }
}
