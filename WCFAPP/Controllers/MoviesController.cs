using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WCFAPP.Models;

namespace WCFAPP.Controllers
{
    public class MoviesController : Controller
    {
        private string uri = "http://localhost:50576/MovieServices.svc";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Search(string keyword)
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<Movie>>(httpClient.GetStringAsync($"{uri}/GetMoviesList").Result);
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync($"{uri}/PostMovie", movie).Result;
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
            var model = httpClient.DeleteAsync($"{uri}/DeleteMovie/{id}").Result;
            if (model.IsSuccessStatusCode)
            {
                return RedirectToAction("Search");
            }
            return RedirectToAction("Search");
        }
    }
}
