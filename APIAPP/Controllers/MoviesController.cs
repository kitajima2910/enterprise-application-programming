using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using APIAPP.Models;

namespace APIAPP.Controllers
{
    public class MoviesController : Controller
    {
        private const string uri = "http://localhost:50359/api/Movies";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Search(string keyword)
        {
            var models = JsonConvert.DeserializeObject<List<Movie>>(httpClient.GetStringAsync(uri).Result);
            if(!string.IsNullOrWhiteSpace(keyword))
            {
                models = models.Where(m => m.Director.Contains(keyword)).ToList();
            }
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync(uri, movie).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Search");
                }
                ViewBag.Msg = "Fail!";
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error!";
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = httpClient.DeleteAsync($"{uri}/{id}").Result;
            if (model.IsSuccessStatusCode)
            {
                return RedirectToAction("Search");
            }
            return RedirectToAction("Search");
        }
    }
}
