using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base;
using API.Context;
using API.Model;
using API.Repository.Data;
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
        private readonly MyContext _context;
        public IConfiguration _configuration;
        readonly ReplacementRepository _replacementRepo;
        public ReplacementsController(ReplacementRepository replacementRepo, MyContext myContext, IConfiguration config) : base(replacementRepo)
        {
            _context = myContext;
            _replacementRepo = replacementRepo;
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



        [HttpPost]
        [Route("Approve")]
        public IActionResult Approve(Replacement replacement)
        {
            if (ModelState.IsValid)
            {
                var jobsid = _context.Replacements.Where(r => r.EmpId == replacement.EmpId).FirstOrDefault();
                ////var user = new User();
                //if (jobsid.EmpId == replacement.EmpId)
                //{
                //    replacement.Email = jobsid.Email;
                //    userVM.Username = jobsid.JobSeeker.Name;

                //}
                ////var email = user.Email.Where(user.Id == userVM.Id);
                ////userVM.Email = user.Email.Where(user.Id.Equals(userVM));
                //client.Port = 587;
                //client.Host = "smtp.gmail.com";
                //client.EnableSsl = true;
                //client.Timeout = 10000;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                //client.Credentials = new NetworkCredential(attrEmail.mail, attrEmail.pass);

                //var fill = "Congratulation " + userVM.Username + "\n\n"
                //          + "Your submission was approved! \n\n"
                //          + "\nThank You";

                //MailMessage mm = new MailMessage("donotreply@domain.com", userVM.Email, "Job Registration Submission", fill);
                //mm.BodyEncoding = UTF8Encoding.UTF8;
                //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                //client.Send(mm);

                jobsid.Approve = true;

                _context.SaveChanges();
                return Ok("Successfully Sent");
            }
            return BadRequest("Not Successfully");
        }

        [HttpPost]
        [Route("Reject")]
        public IActionResult Reject(Replacement replacement)
        {
            if (ModelState.IsValid)
            {
                var jobsid = _context.Replacements.Where(r => r.EmpId == replacement.EmpId).FirstOrDefault();

                //var user = new User();
                //if (jobsid.Id == userVM.Id)
                //{
                //    userVM.Email = jobsid.Email;
                //    userVM.Username = jobsid.JobSeeker.Name;

                //}
                //client.Port = 587;
                //client.Host = "smtp.gmail.com";
                //client.EnableSsl = true;
                //client.Timeout = 10000;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                //client.Credentials = new NetworkCredential(attrEmail.mail, attrEmail.pass);

                //var fill = "Dear " + userVM.Username + "\n\n"
                //          + "We are sorry that your submission doesn't match what we are looking for, maybe you can try again next time or other position. Keep spirit and always have a nice days \n"
                //          + "\n\nThank You";

                //MailMessage mm = new MailMessage("donotreply@domain.com", userVM.Email, "Job Registration Submission", fill);
                //mm.BodyEncoding = UTF8Encoding.UTF8;
                //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                //client.Send(mm);

                jobsid.Approve = true;

                _context.SaveChanges();
                return Ok("Successfully Sent");
            }
            return BadRequest("Not Successfully");
        }
    }
}