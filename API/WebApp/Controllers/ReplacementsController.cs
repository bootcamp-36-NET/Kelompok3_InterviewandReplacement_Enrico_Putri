﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public class ReplacementsController : Controller
    {
        readonly HttpClient http = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44395/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult LoadReplace()
        {
            IEnumerable<Replacement> replace = null;
            //var token = HttpContext.Session.GetString("JWToken");
            //http.DefaultRequestHeaders.Add("Authorization", token);
            var restTask = http.GetAsync("replacements");
            restTask.Wait();

            var result = restTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Replacement>>();
                readTask.Wait();
                replace = readTask.Result;
            }
            return Json(replace, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public JsonResult GetById(string id)
        {
            Replacement replace = null;
            //var token = HttpContext.Session.GetString("JWToken");
            //http.DefaultRequestHeaders.Add("Authorization", token);
            var restTask = http.GetAsync("replacements/" + id);
            restTask.Wait();

            var result = restTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                replace = JsonConvert.DeserializeObject<Replacement>(readTask);
            }
            return Json(replace);
        }

        public JsonResult InsertOrUpdate(Replacement replacement, string id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(replacement);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("JWToken");
                //http.DefaultRequestHeaders.Add("Authorization", token);

                if (replacement.Id == 0)
                {
                    var result = http.PostAsync("replacements", byteContent).Result;
                    return Json(result);
                }
                else if (replacement.Id != 0)
                {
                    var result = http.PutAsync("replacements/" + id, byteContent).Result;
                    return Json(result);
                }

                return Json(404);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult Delete(string id)
        {
           // var token = HttpContext.Session.GetString("JWToken");
           // http.DefaultRequestHeaders.Add("Authorization", token);
            var result = http.DeleteAsync("replacements/" + id).Result;
            return Json(result);
        }
    }
}