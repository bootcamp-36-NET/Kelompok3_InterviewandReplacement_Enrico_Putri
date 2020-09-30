using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            if (HttpContext.Session.IsAvailable)
            {
                if (HttpContext.Session.GetString("lvl") == "Super Admin")
                {
                    return View();
                }
                return Redirect("/ErrorHandler");
            }
            return Redirect("/ErrorHandler");
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

        public IActionResult GetById(int Id)
        {
            Site site = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("sites/" + Id);
            resTask.Wait();
            HttpContext.Session.SetInt32("sites", Id);
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                site = JsonConvert.DeserializeObject<Site>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(site);
        }

        public IActionResult InsertOrUpdate(Site site, int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(site);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Add("Authorization", token);
                if (site.Id == 0)
                {
                    var result = client.PostAsync("sites", byteContent).Result;
                    return Json(result);
                }
                else if (site.Id == id)
                {
                    var result = client.PutAsync("sites/" + id, byteContent).Result;
                    return Json(result);
                }

                return Json(404);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Delete(int id)
        {
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var result = client.DeleteAsync("sites/" + id).Result;
            return Json(result);
        }
    }
}