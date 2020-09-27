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
    public class ReplacementController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44395/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadReplacement()
        {
            IEnumerable<Replacement> replacements = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("Replacements");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Replacement>>();
                readTask.Wait();
                replacements = readTask.Result;
            }
            else
            {
                replacements = Enumerable.Empty<Replacement>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(replacements);

        }

        public IActionResult GetById(int Id)
        {
            Replacement replacement = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("Replacements/" + Id);
            resTask.Wait();
            HttpContext.Session.SetInt32("Replacements", Id);
            HttpContext.Session.SetString("Approve", replacement.Approve.ToString());
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                replacement = JsonConvert.DeserializeObject<Replacement>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(replacement);
        }

        public IActionResult InsertOrUpdate(Replacement replacement, int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(replacement);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("token");
                //client.DefaultRequestHeaders.Add("Authorization", token);
                if (replacement.Id == 0)
                {
                    var result = client.PostAsync("replacements", byteContent).Result;
                    return Json(result);
                }
                else if (replacement.Id == id)
                {
                    var result = client.PutAsync("replacements/" + id, byteContent).Result;
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
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var result = client.DeleteAsync("replacements/" + id).Result;
            return Json(result);
        }
    }
}