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
    public class PlacementController : Controller
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

        public IActionResult LoadPlacement()
        {
            IEnumerable<Placement> placements = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("placements");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Placement>>();
                readTask.Wait();
                placements = readTask.Result;
            }
            else
            {
                placements = Enumerable.Empty<Placement>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(placements);

        }

        public IActionResult GetById(int Id)
        {
            Placement placement = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("placements/" + Id);
            resTask.Wait();
            HttpContext.Session.SetInt32("placements", Id);
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                placement = JsonConvert.DeserializeObject<Placement>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(placement);
        }

        public IActionResult InsertOrUpdate(Placement placement, int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(placement);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Add("Authorization", token);
                if (placement.Id == 0)
                {
                    var result = client.PostAsync("placements", byteContent).Result;
                    return Json(result);
                }
                else if (placement.Id == id)
                {
                    var result = client.PutAsync("placements/" + id, byteContent).Result;
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
            var result = client.DeleteAsync("placements/" + id).Result;
            return Json(result);
        }
    }
}