using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Model;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public class InterviewScheduleController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44395/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadInterviewSchedule()
        {
            IEnumerable<InterviewSchedule> interviews = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("interviewschedules");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<InterviewSchedule>>();
                readTask.Wait();
                interviews = readTask.Result;
            }
            else
            {
                interviews = Enumerable.Empty<InterviewSchedule>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(interviews);

        }

        public IActionResult GetById(int Id)
        {
            InterviewSchedule interviewSchedule = null;
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("interviewschedules/" + Id);
            resTask.Wait();
            HttpContext.Session.SetInt32("interviewschedules", Id);
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                interviewSchedule = JsonConvert.DeserializeObject<InterviewSchedule>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(interviewSchedule);
        }

        public IActionResult InsertOrUpdate(InterviewSchedule interviewSchedule, int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(interviewSchedule);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("token");
                //client.DefaultRequestHeaders.Add("Authorization", token);
                if (interviewSchedule.Id == 0)
                {
                    var result = client.PostAsync("interviewschedules", byteContent).Result;
                    return Json(result);
                }
                else if (interviewSchedule.Id == id)
                {
                    var result = client.PutAsync("interviewschedules/" + id, byteContent).Result;
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
            var result = client.DeleteAsync("interviewschedules/" + id).Result;
            return Json(result);
        }
    }
}