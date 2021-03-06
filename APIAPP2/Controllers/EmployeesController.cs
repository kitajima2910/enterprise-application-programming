﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using APIAPP2.Models;

namespace APIAPP2.Controllers
{
    public class EmployeesController : Controller
    {
        private const string uri = "http://localhost:51459/api/Employees";
        private HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            var models = JsonConvert.DeserializeObject<List<Employee>>(httpClient.GetStringAsync(uri).Result);
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {

                var model = httpClient.PostAsJsonAsync(uri, employee).Result;
                if (model.IsSuccessStatusCode)
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

        public IActionResult Edit(int id)
        {
            var model = JsonConvert.DeserializeObject<Employee>(httpClient.GetStringAsync($"{uri}/{id}").Result);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            try
            {

                var model = httpClient.PutAsJsonAsync(uri, employee).Result;
                if (model.IsSuccessStatusCode)
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
    }
}
