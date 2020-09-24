using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SiteController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44395/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadSite()
        {
            IEnumerable<Site> interviews = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("sites");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Site>>();
                readTask.Wait();
                interviews = readTask.Result;
            }
            else
            {
                interviews = Enumerable.Empty<Site>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(interviews);

        }
    }
}