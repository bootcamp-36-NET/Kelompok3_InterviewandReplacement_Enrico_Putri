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
    public class SitesController : Controller
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
            IEnumerable<Site> sites = null;
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("sites");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Site>>();
                readTask.Wait();
                sites = readTask.Result;
            }
            else
            {
                sites = Enumerable.Empty<Site>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(sites);

        }

        public JsonResult GetById(int id)
        {
            Site site = null;
            //var token = HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var restTask = client.GetAsync("sites/" + id);
            restTask.Wait();

            var result = restTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                site = JsonConvert.DeserializeObject<Site>(readTask);
            }
            return Json(site);
        }

        public JsonResult InsertOrUpdate(Site site, int Id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(site);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("JWToken");
                //client.DefaultRequestHeaders.Add("Authorization", token);

                if (site.Id == 0)
                {
                    var result = client.PostAsync("sites", byteContent).Result;
                    return Json(result);
                }
                else if (site.Id != 0)
                {
                    var result = client.PutAsync("sites/" + Id, byteContent).Result;
                    return Json(result);
                }

                return Json(404);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public IActionResult InsertOrUpdate(Site site, int id)
        //{
        //    try
        //    {
        //        var json = JsonConvert.SerializeObject(site);
        //        var buffer = System.Text.Encoding.UTF8.GetBytes(json);
        //        var byteContent = new ByteArrayContent(buffer);
        //        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        //var token = HttpContext.Session.GetString("token");
        //        //client.DefaultRequestHeaders.Add("Authorization", token);
        //        if (site.Id == 0)
        //        {
        //            var result = client.PostAsync("sites", byteContent).Result;
        //            return Json(result);
        //        }
        //        else if (site.Id == id)
        //        {
        //            var result = client.PutAsync("sites/" + id, byteContent).Result;
        //            return Json(result);
        //        }

        //        return Json(404);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public IActionResult Delete(int id)
        {
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var result = client.DeleteAsync("sites/" + id).Result;
            return Json(result);
        }
    }
}