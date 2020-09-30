using System;
using System.Collections.Generic;
using System.Dynamic;
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
    public class ApproveRejectReplacementController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44395/api/")
        };

        readonly HttpClient userClient = new HttpClient
        {
            BaseAddress = new Uri("http://winarto-001-site1.dtempurl.com/api/")
        };

        public IActionResult Index()
        {
            if (HttpContext.Session.IsAvailable)
            {
                if (HttpContext.Session.GetString("lvl") == "Super Admin")
                {
                    return View("~/Views/Replacement/ApproveReject.cshtml");
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



        //public IActionResult Approve(int id)
        //{
        //    var token = HttpContext.Session.GetString("token");
        //    client.DefaultRequestHeaders.Add("Authorization", token);
        //    var result = client.DeleteAsync("replacements/Approve/" + id).Result;
        //    return Json(result);
        //}

        public IActionResult ApproveRequest(ApproveRejectVM approveVM)
        {
            var authToken = HttpContext.Session.GetString("token");

            userClient.DefaultRequestHeaders.Add("Authorization", authToken);
            var resTaskUser = userClient.GetAsync("Users/" + approveVM.EmpId);
            resTaskUser.Wait();

            var userResult = resTaskUser.Result;
            var responseUserData = userResult.Content.ReadAsAsync<GetUserVM>().Result;
            approveVM.Email = responseUserData.Email;

            var json = JsonConvert.SerializeObject(approveVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //string stringData = JsonConvert.SerializeObject(approveVM);
            //var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            //client.DefaultRequestHeaders.Add("Authorization", authToken);
            var resTask = client.PutAsync("Replacements/approve", byteContent).Result;
            //resTask.Wait();

            //var result = resTask.Result;
            //var responseData = result.Content.ReadAsStringAsync().Result;

            //dynamic resultVM = new ExpandoObject();
            //resultVM.Item1 = result;
            //resultVM.Item2 = responseData;

            return Json(resTask);
        }

        public IActionResult RejectRequest(ApproveRejectVM approveVM)
        {
            var authToken = HttpContext.Session.GetString("token");

            userClient.DefaultRequestHeaders.Add("Authorization", authToken);
            var resTaskUser = userClient.GetAsync("Users/" + approveVM.EmpId);
            resTaskUser.Wait();

            var userResult = resTaskUser.Result;
            var responseUserData = userResult.Content.ReadAsAsync<GetUserVM>().Result;
            approveVM.Email = responseUserData.Email;

            var json = JsonConvert.SerializeObject(approveVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //string stringData = JsonConvert.SerializeObject(approveVM);
            //var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            //client.DefaultRequestHeaders.Add("Authorization", authToken);
            var resTask = client.PutAsync("Replacements/Reject", byteContent).Result;
            //resTask.Wait();

            //var result = resTask.Result;
            //var responseData = result.Content.ReadAsStringAsync().Result;

            //dynamic resultVM = new ExpandoObject();
            //resultVM.Item1 = result;
            //resultVM.Item2 = responseData;

            return Json(resTask);
        }

        //public IActionResult Reject(int id)
        //{
        //    var token = HttpContext.Session.GetString("token");
        //    client.DefaultRequestHeaders.Add("Authorization", token);
        //    var result = client.DeleteAsync("replacements/Reject/" + id).Result;
        //    return Json(result);
        //}
    }
}