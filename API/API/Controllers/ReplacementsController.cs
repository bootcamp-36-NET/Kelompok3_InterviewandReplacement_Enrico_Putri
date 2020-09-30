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
        readonly MyContext _context;

        public ReplacementsController(ReplacementRepository replacementRepo, IConfiguration config, SendEmailService sendEmailService, MyContext context) : base(replacementRepo)
        {
            _replacementRepo = replacementRepo;
            _sendEmail = sendEmailService;
            _configuration = config;
            _context = context;

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

        [HttpGet]
        [Route("empId/{id}")]
        public async Task<List<Replacement>> GetIDEmp(string id)
        {
            var getData = await _context.Replacements.Include("Site").Where(x => x.EmpId == id && x.isDelete == false && x.Reject == false).ToListAsync();
            if (getData == null)
            {
                return null;
            }
            return getData;
        }

        [HttpGet]
        [Route("empIdApp/{id}")]
        public async Task<List<Replacement>> GetIdApp(string id)
        {
            var getData = await _context.Replacements.Include("Site").Where(x => x.EmpId == id && x.isDelete == false && x.Approve == true).ToListAsync();
            if (getData == null)
            {
                return null;
            }
            return getData;
        }

        [HttpGet]
        [Route("empIdRej/{id}")]
        public async Task<List<Replacement>> GetIdRej(string id)
        {
            var getData = await _context.Replacements.Include("Site").Where(x => x.EmpId == id && x.isDelete == false && x.Reject == true).ToListAsync();
            if (getData == null)
            {
                return null;
            }
            return getData;
        }

        //nampilin yang udah di approve/reject
        [HttpGet]
        [Route("empIdStatus")]
        public async Task<List<Replacement>> GetAllStatus()
        {
            var getData = await _context.Replacements.Include("Site").Where(x => x.isDelete == false && x.Reject == true || x.Approve == true).ToListAsync();
            if (getData == null)
            {
                return null;
            }
            return getData;
        }

        //nampilin yang belum di approve/reject
        [HttpGet]
        [Route("empIdStatus2")]
        public async Task<List<Replacement>> GetAllStatus2()
        {
            var getData = await _context.Replacements.Include("Site").Where(x => x.isDelete == false && x.Reject == false && x.Approve == false).ToListAsync();
            if (getData == null)
            {
                return null;
            }
            return getData;
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
                Body = "Your replacement request has been approved"
            };
            _sendEmail.SendEmail(emailData);

            return Ok("Request Approved !");
        }

        [HttpPut]
        [Route("reject")]
        public async Task<ActionResult> Reject(ApproveRejectVM approveVM)
        {
            var replacement = await _replacementRepo.GetID(approveVM.Id);

            replacement.Reject = true;
            var result = await _replacementRepo.Reject(replacement);
            if (result < 0)
            {
                return BadRequest("Server Error !");
            }

            var emailData = new SendEmailVM()
            {
                Email = approveVM.Email,
                Subject = "Replacement Approval " + DateTimeOffset.Now.ToString("Y"),
                Body = "We're sorry, your replacement request has been rejected. Please request replacement again!"
            };
            _sendEmail.SendEmail(emailData);

            return Ok("Request Rejected !");
        }
    }
}