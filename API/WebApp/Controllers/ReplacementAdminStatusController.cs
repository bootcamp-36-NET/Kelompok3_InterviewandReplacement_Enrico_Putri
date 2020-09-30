using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public class ReplacementAdminStatusController : Controller
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
                    return View("~/Views/replacement/viewreplacementstatusAdmin.cshtml");
                }
                return Redirect("/ErrorHandler");
            }
            return Redirect("/ErrorHandler");
        }

        public IActionResult LoadReplacement()
        {
            IEnumerable<Replacement> replacements = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("Replacements/empIdStatus");
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

        //coba get Approve
        public IActionResult GetByIdEmpApp()
        {
            IEnumerable<Replacement> replacements = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);

            var resTask = client.GetAsync("replacements/empIdApp/" + HttpContext.Session.GetString("id"));
            resTask.Wait();
            //HttpContext.Session.SetInt32("interviewschedules", Id);
            //HttpContext.Session.SetString("EmpId", interviewSchedule.EmpId);
            //if (interviewSchedule.EmpId == HttpContext.Session.GetString("id"))
            //{
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                //var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                ////var scheduleEmp = json.Where(q => q.Equals(interviewSchedule.EmpId) == HttpContext.Session.GetString("userId"));
                //interviewSchedule = JsonConvert.DeserializeObject<InterviewSchedule>(json);
                var data = result.Content.ReadAsAsync<List<Replacement>>();
                data.Wait();
                replacements = data.Result;
            }
            else
            {
                replacements = Enumerable.Empty<Replacement>();
                ModelState.AddModelError(string.Empty, "Server Error.");
            }

            //}
            return Json(replacements);
        }
        //
        public IActionResult GetById(int Id)
        {
            Replacement replacement = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("Replacements/" + Id);
            resTask.Wait();
            HttpContext.Session.SetInt32("Replacements", Id);
            //HttpContext.Session.SetString("Approve", replacement.Approve.ToString());
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
    }
}