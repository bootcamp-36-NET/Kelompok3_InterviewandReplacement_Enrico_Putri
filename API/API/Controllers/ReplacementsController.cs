using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base;
using API.Context;
using API.Model;
using API.Repository.Data;
using API.Services;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplacementsController : BaseController<Replacement, ReplacementRepository>
    {
        public IConfiguration _configuration;
        readonly ReplacementRepository _replacementRepo;
        private readonly SendEmailService _sendEmail;
        public ReplacementsController(ReplacementRepository replacementRepo, IConfiguration config, SendEmailService sendEmailService) : base(replacementRepo)
        {
            _replacementRepo = replacementRepo;
            _sendEmail = sendEmailService;
            _configuration = config;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, Replacement entity)
        {
            var getid = await _replacementRepo.GetID(id);
            getid.EmpId = entity.EmpId;
            getid.SiteId = entity.SiteId;
            getid.Replacement_reason = entity.Replacement_reason;
            var data = await _replacementRepo.Update(getid);
            if (data.Equals(null))
            {
                return BadRequest("Data is not Update");
            }
            return Ok("Update Successfull");
        }

        //[HttpDelete]
        //[Route("Approve/{id}")]
        //public async Task<ActionResult<int>> Approve(int Id)
        //{
        //    var data = await _replacementRepo.Approve(Id);
        //    if (data.Equals(null))
        //    {
        //        return BadRequest("Something Wrong! Please check again");
        //    }
        //    return data;
        //}

        //[HttpDelete]
        //[Route("Reject")]
        //public async Task<ActionResult<int>> Reject(int Id)
        //{
        //    var data = await _replacementRepo.Reject(Id);
        //    if (data.Equals(null))
        //    {
        //        return BadRequest("Something Wrong! Please check again");
        //    }
        //    return data;
        //}

        [HttpPut]
        [Route("approve")]
        public async Task<ActionResult> Approve(ApproveRejectVM approveVM)
        {
            var replacement = await _replacementRepo.GetID(approveVM.Id);

            replacement.Approve = true;
            var result = await _replacementRepo.Approve(replacement);
            if (result < 0)
            {
                return BadRequest("Server Error !");
            }

            var emailData = new SendEmailVM()
            {
                Email = approveVM.Email,
                Subject = "Replacement Approval " + DateTimeOffset.Now.ToString("Y"),
                Body = "Your Replacement Request Has been Approved"
            };
            _sendEmail.SendEmail(emailData);

            return Ok("Request Approved !");
        }

        [HttpPut]
        [Route("reject")]
        public async Task<ActionResult> Reject(ApproveRejectVM approveVM)
        {
            var replacement = await _replacementRepo.GetID(approveVM.Id);

            replacement.Approve = true;
            var result = await _replacementRepo.Reject(replacement);
            if (result < 0)
            {
                return BadRequest("Server Error !");
            }

            var emailData = new SendEmailVM()
            {
                Email = approveVM.Email,
                Subject = "Replacement Approval " + DateTimeOffset.Now.ToString("Y"),
                Body = "We're Sorry, Your Replacement Request Has been Rejected"
            };
            _sendEmail.SendEmail(emailData);

            return Ok("Request Rejected !");
        }

        //[HttpPost]
        //[Route("Reject")]
        //public IActionResult Reject(Replacement replacement)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var jobsid = _context.Replacements.Where(r => r.EmpId == replacement.EmpId).FirstOrDefault();

        //        //var user = new User();
        //        //if (jobsid.Id == userVM.Id)
        //        //{
        //        //    userVM.Email = jobsid.Email;
        //        //    userVM.Username = jobsid.JobSeeker.Name;

        //        //}
        //        //client.Port = 587;
        //        //client.Host = "smtp.gmail.com";
        //        //client.EnableSsl = true;
        //        //client.Timeout = 10000;
        //        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        //client.UseDefaultCredentials = false;
        //        //client.Credentials = new NetworkCredential(attrEmail.mail, attrEmail.pass);

        //        //var fill = "Dear " + userVM.Username + "\n\n"
        //        //          + "We are sorry that your submission doesn't match what we are looking for, maybe you can try again next time or other position. Keep spirit and always have a nice days \n"
        //        //          + "\n\nThank You";

        //        //MailMessage mm = new MailMessage("donotreply@domain.com", userVM.Email, "Job Registration Submission", fill);
        //        //mm.BodyEncoding = UTF8Encoding.UTF8;
        //        //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        //        //client.Send(mm);

        //        jobsid.Approve = true;

        //        _context.SaveChanges();
        //        return Ok("Successfully Sent");
        //    }
        //    return BadRequest("Not Successfully");
        //}
    }
}