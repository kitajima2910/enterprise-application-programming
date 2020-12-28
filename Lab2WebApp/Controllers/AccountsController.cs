using Lab2WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lab2WebApp.Controllers
{
    public class AccountsController : Controller
    {
        private const string uri = "http://localhost:58681/api/Accounts/";
        private readonly HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            var res = JsonConvert.DeserializeObject<IEnumerable<Account>>(httpClient.GetStringAsync(uri).Result);

            return View(res);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync(uri, account).Result;
                if(model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Accounts");
                }

                ModelState.AddModelError(string.Empty, "Error!!!");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View();
        }

        [HttpGet]
        public IActionResult Login(Account account)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string accCode, string pinCode)
        {
            var model = JsonConvert.DeserializeObject<Account>(httpClient.GetStringAsync($"{uri}{accCode}/{pinCode}").Result);
            if(model != null)
            {
                HttpContext.Session.SetString("InfoAccount", JsonConvert.SerializeObject(model));

                return RedirectToAction("Balance", "Accounts");
            }

            ViewBag.Msg = "Error!!";
            return View();
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var res = JsonConvert.DeserializeObject<Account>(httpClient.GetStringAsync(uri + id).Result);
            return View(res);
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var res = JsonConvert.DeserializeObject<Account>(httpClient.GetStringAsync(uri + id).Result);
            return View(res);
        }

        [HttpPost]
        public IActionResult Update(Account account)
        {
            try
            {
                var model = httpClient.PutAsJsonAsync(uri + account.AccountCode, account).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Accounts");
                }

                ModelState.AddModelError(string.Empty, "Error!!!");
            }
            catch (Exception)
            {

                throw;
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            try
            {
                var model = httpClient.DeleteAsync(uri + id).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Accounts");
                }

                ModelState.AddModelError(string.Empty, "Error!!!");
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }


        public IActionResult Balance()
        {
            ViewBag.AccountCode = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("InfoAccount")).AccountCode;

            return View();
        }

        [HttpPost]
        public IActionResult Balance(string accountCode, string key, double balance)
        {
            try
            {
                var account = JsonConvert.DeserializeObject<Account>(httpClient.GetStringAsync(uri + accountCode).Result);

                if (key.Equals("Withdrawal"))
                {
                    account.Balance -= balance;
                }
                else if (key.Equals("Recharge"))
                {
                    account.Balance += balance;
                }

                var model = httpClient.PutAsJsonAsync(uri + account.AccountCode, account).Result;
                if (model.IsSuccessStatusCode)
                {
                    ViewBag.AccountCode = accountCode;
                    ViewBag.Msg = "Successfuly!...";
                }

            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            

            return View();
        }

    }
}
