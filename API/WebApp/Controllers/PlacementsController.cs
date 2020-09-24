using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Model;
using API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public class PlacementsController : Controller
    {
        readonly HttpClient http = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44395/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadPlace()
        {
            IEnumerable<PlacementVM> replace = null;
            //var token = HttpContext.Session.GetString("token");
            //http.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = http.GetAsync("placements/semuaPlacement");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<PlacementVM>>();
                readTask.Wait();
                replace = readTask.Result;
            }
            else
            {
                replace = Enumerable.Empty<PlacementVM>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(replace);

        }


        public JsonResult GetById(int id)
        {
            Placement replace = null;
            //var token = HttpContext.Session.GetString("JWToken");
            //http.DefaultRequestHeaders.Add("Authorization", token);
            var restTask = http.GetAsync("placements/" + id);
            restTask.Wait();

            var result = restTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                replace = JsonConvert.DeserializeObject<Placement>(readTask);
            }
            return Json(replace);
        }

        public JsonResult InsertOrUpdate(Placement placement, int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(placement);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("JWToken");
                //http.DefaultRequestHeaders.Add("Authorization", token);

                if (placement.Id == 0)
                {
                    var result = http.PostAsync("placements", byteContent).Result;
                    return Json(result);
                }
                else if (placement.Id != 0)
                {
                    var result = http.PutAsync("placements/" + id, byteContent).Result;
                    return Json(result);
                }

                return Json(404);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult Delete(int id)
        {
            // var token = HttpContext.Session.GetString("JWToken");
            // http.DefaultRequestHeaders.Add("Authorization", token);
            var result = http.DeleteAsync("placements/" + id).Result;
            return Json(result);
        }
    }
}