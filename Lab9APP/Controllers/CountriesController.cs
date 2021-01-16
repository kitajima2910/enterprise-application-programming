using Lab9DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Lab9APP.Controllers
{
    public class CountriesController : Controller
    {
        private string uri = "http://localhost:53764/api/Countries";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            var models = JsonConvert.DeserializeObject<List<Country>>(httpClient.GetStringAsync(uri).Result);
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var rename = Convert.ToString(Guid.NewGuid()) + "." + fileName.Split('.').Last();
                        var path = Path.Combine("wwwroot/Images", rename);
                        var stream = new FileStream(path, FileMode.Create);
                        file.CopyToAsync(stream);

                        country.Photo = "Images/" + rename;

                        var model = httpClient.PostAsJsonAsync(uri, country).Result;
                        if(model.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }

                ViewBag.Msg = "Fail!";
            }
            catch (Exception)
            {
                ViewBag.Msg = "Erro!";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = JsonConvert.DeserializeObject<Country>(httpClient.GetStringAsync($"{uri}/{id}").Result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Country country, IFormFile file)
        {
            try
            {
                var modelOld = JsonConvert.DeserializeObject<Country>(httpClient.GetStringAsync($"{uri}/{country.Id}").Result);
                var pathImageOld = modelOld.Photo;

                if (ModelState.IsValid)
                {
                    if(file == null)
                    {
                        country.Photo = modelOld.Photo;
                        var model = httpClient.PutAsJsonAsync(uri, country).Result;
                        if (model.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    } 
                    else
                    {
                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                            var rename = Convert.ToString(Guid.NewGuid()) + "." + fileName.Split('.').Last();
                            var path = Path.Combine("wwwroot/Images", rename);
                            var stream = new FileStream(path, FileMode.Create);
                            file.CopyToAsync(stream);

                            country.Photo = "Images/" + rename;

                            var model = httpClient.PutAsJsonAsync(uri, country).Result;
                            if (model.IsSuccessStatusCode)
                            {
                                var pathOld = Path.Combine("wwwroot", pathImageOld);
                                System.IO.File.Delete(pathOld);
                                return RedirectToAction("Index");
                            }
                        }
                    }

                }

                ViewBag.Msg = "Erro!";
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

    }
}
