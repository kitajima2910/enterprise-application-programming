using Lab6WebAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab6WebAPP.Controllers
{
    public class BooksController : Controller
    {
        private const string uri = "http://localhost:60985/Service1.svc";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            var res = JsonConvert.DeserializeObject<IEnumerable<Book>>(httpClient.GetStringAsync($"{uri}/findAll").Result);
            return View(res);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            try
            {
                var mode = httpClient.PostAsJsonAsync($"{uri}/AddBook", book).Result;
                if(mode.IsSuccessStatusCode)
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
    }
}
