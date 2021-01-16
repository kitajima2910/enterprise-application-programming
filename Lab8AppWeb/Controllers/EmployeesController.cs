using Grpc.Core;
using Lab8AppWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab8AppWeb.Controllers
{
    public class EmployeesController : Controller
    {

        private string uri = "http://localhost:64080/Service1.svc";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<Employee>>(httpClient.GetStringAsync($"{uri}/GetEmployees").Result);
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
                var models = JsonConvert.DeserializeObject<IEnumerable<Employee>>(httpClient.GetStringAsync($"{uri}/GetEmployees").Result);
                var model = models.SingleOrDefault(m => m.Code.Equals(employee.Code) && m.Password.Equals(employee.Password));
                if (model != null)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.Msg = "Fail!";
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error!";
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee, IFormFile file)
        {
            try
            {

                if(ModelState.IsValid)
                {
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var rename = Convert.ToString(Guid.NewGuid()) + "." + fileName.Split('.').Last();
                        var path = Path.Combine("wwwroot/image", rename);
                        var stream = new FileStream(path, FileMode.Create);
                        file.CopyToAsync(stream);

                        employee.Photo = "image/" + rename;

                        var model = JsonConvert.DeserializeObject<Employee>(httpClient.GetStringAsync($"{uri}/GetEmployee/{employee.Code}").Result);

                        if (model == null)
                        {
                            var postModel = httpClient.PostAsync($"{uri}/PostEmployee", employee, new JsonMediaTypeFormatter { UseDataContractJsonSerializer = true }).Result;
                            if (postModel.IsSuccessStatusCode)
                            {
                                return RedirectToAction("Index");
                            }
                        }
                        else
                        {
                            ViewBag.Msg = "Code is existed...";
                        }
                    }
                    else
                    {
                        ViewBag.Msg = "File Url Fail";
                    }
                }

                ViewBag.Msg = "Fail!";
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error!";
            }
            return View();
        }


        public IActionResult Edit(string id)
        {
            var model = JsonConvert.DeserializeObject<Employee>(httpClient.GetStringAsync($"{uri}/GetEmployee/{id}").Result);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee, IFormFile file)
        {
            try
            {

                var model = JsonConvert.DeserializeObject<Employee>(httpClient.GetStringAsync($"{uri}/GetEmployee/{employee.Code}").Result);

                employee.Password = model.Password;
                var saveFileNameOld = model.Photo;

                //if (ModelState.IsValid)
                //{
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var rename = Convert.ToString(Guid.NewGuid()) + "." + fileName.Split('.').Last();
                        var path = Path.Combine("wwwroot/image", rename);
                        var stream = new FileStream(path, FileMode.Create);
                        file.CopyToAsync(stream);

                        employee.Photo = "image/" + rename;

                        var puttModel = httpClient.PutAsync($"{uri}/PutEmployee", employee, new JsonMediaTypeFormatter { UseDataContractJsonSerializer = true }).Result;
                        if (puttModel.IsSuccessStatusCode)
                        {
                            System.IO.File.Delete("@" + saveFileNameOld);
                            return RedirectToAction("Index");
                        }

                        ViewBag.Msg = "Fail!";
                    }
                    else
                    {
                        ViewBag.Msg = "File Url Fail";
                    }
                //}

                ViewBag.Msg = "Fail!";
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error!";
            }
            return View();
        }
    }
}
