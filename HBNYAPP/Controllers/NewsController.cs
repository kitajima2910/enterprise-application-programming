using HBNYAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HBNYAPP.Controllers
{
    public class NewsController : Controller
    {
        private const string url = "http://localhost:62395/api/News/";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Index(string keyword)
        {
            var models = JsonConvert.DeserializeObject<List<News>>(httpClient.GetStringAsync(url).Result);
            if (!string.IsNullOrEmpty(keyword))
            {
                models = JsonConvert.DeserializeObject<List<News>>(httpClient.GetStringAsync($"{url}?keyword={keyword}").Result);
            }
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(News news)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var model = httpClient.PostAsJsonAsync(url, news).Result;
                    if(model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }

        public IActionResult Details(string id)
        {
            var model = JsonConvert.DeserializeObject<News>(httpClient.GetStringAsync($"{url}{id}").Result);
            return View(model);
        }

        public IActionResult Edit(string id)
        {
            var model = JsonConvert.DeserializeObject<News>(httpClient.GetStringAsync($"{url}{id}").Result);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(News news)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = httpClient.PutAsJsonAsync(url, news).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }

        public IActionResult Delete(string id)
        {
            var model = httpClient.DeleteAsync($"{url}{id}").Result;
            if (model.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
