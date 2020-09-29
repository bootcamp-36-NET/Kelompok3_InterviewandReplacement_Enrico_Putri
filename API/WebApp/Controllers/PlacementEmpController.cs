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
    public class PlacementEmpController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44395/api/")
        };

        public IActionResult Index()
        {
            if (HttpContext.Session.IsAvailable)
            {
                if (HttpContext.Session.GetString("lvl") == "Employee")
                {
                    return View("~/Views/placement/viewplacementEmp.cshtml");
                }
                return Redirect("/ErrorHandler");
            }
            return Redirect("/ErrorHandler");
        }

        public IActionResult LoadPlacementEmp()
        {
            IEnumerable<Placement> placements = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("placements/empId/" + HttpContext.Session.GetString("id"));
            resTask.Wait();
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Placement>>();
                readTask.Wait();
                //readTask.Result.SingleOrDefault(q => q.EmpId == HttpContext.Session.GetString("id"));
                placements = readTask.Result;
                //var interEmp = interviews.SingleOrDefault(q => q.EmpId == HttpContext.Session.GetString("userId"));
            }
            else
            {
                placements = Enumerable.Empty<Placement>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(placements);

        }

        public IActionResult GetByIdEmp()
        {
            IEnumerable<Placement> placements = null;
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Authorization", token);

            var resTask = client.GetAsync("placements/empId/" + HttpContext.Session.GetString("id"));
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
                var data = result.Content.ReadAsAsync<List<Placement>>();
                data.Wait();
                placements = data.Result;
            }
            else
            {
                placements = Enumerable.Empty<Placement>();
                ModelState.AddModelError(string.Empty, "Server Error.");
            }

            //}
            return Json(placements);
        }
    }
}