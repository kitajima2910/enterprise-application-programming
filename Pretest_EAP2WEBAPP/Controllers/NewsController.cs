using Microsoft.AspNetCore.Mvc;
using Pretest_EAP2WEBAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Pretest_EAP2WEBAPP.Controllers
{
    public class NewsController : Controller
    {
        //private string uri = "http://localhost:50256/api/News";
        private string uri = "http://localhost:54032/Service1.svc";

        private HttpClient httpClient = new HttpClient();

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(News news)
        {
            try
            {
                var model = httpClient.PostAsync($"{uri}/PostNews", news, new JsonMediaTypeFormatter { UseDataContractJsonSerializer = true }).Result;
                if(model.IsSuccessStatusCode && ModelState.IsValid)
                {
                    ViewBag.Msg = "Successfuly!";
                }
                else
                {
                    ViewBag.Msg = "Fail!";
                }
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error!";
            }
            return View();
        }


        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(News news)
        {
            try
            {

                var model = httpClient.DeleteAsync($"{uri}/DeleteNews/{news.NewsId}").Result;

                if (model.IsSuccessStatusCode)
                {
                    ViewBag.Msg = "Successfuly!";
                }
                else
                {
                    ViewBag.Msg = "Fail!";
                }
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error!";
            }
            return View();
        }

    }
}
