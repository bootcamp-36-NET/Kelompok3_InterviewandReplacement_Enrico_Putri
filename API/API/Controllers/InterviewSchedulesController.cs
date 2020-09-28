using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base;
using API.Context;
using API.Model;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewSchedulesController : BaseController<InterviewSchedule, InterviewSchedulesRepository>
    {
        readonly InterviewSchedulesRepository _interviewscheduleRepo;
        readonly MyContext _context;
        public InterviewSchedulesController(InterviewSchedulesRepository interviewSchedulesRepo, MyContext context) : base(interviewSchedulesRepo)
        {
            _interviewscheduleRepo = interviewSchedulesRepo;
            _context = context;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, InterviewSchedule entity)
        {
            var getid = await _interviewscheduleRepo.GetID(id);
            getid.Interview_date = entity.Interview_date;
            getid.EmpId = entity.EmpId;
            getid.JoblistId = entity.JoblistId;
            getid.SiteId = entity.SiteId;
            var data = await _interviewscheduleRepo.Update(getid);
            if (data.Equals(null))
            {
                return BadRequest("Data is not Update");
            }
            return Ok("Update Successfull");
        }

        //[HttpGet]
        //[Route("empId/{id}")]
        //public async Task<ActionResult<string>> GetIDEmp(string id)
        //{
        //    var data = await _interviewscheduleRepo.GetEmpID(id);
        //    if (data.Equals(null))
        //    {
        //        return BadRequest("Data is not Update");
        //    }
        //    //return data;
        //    return Ok("Successfull");
        //}

        [HttpGet]
        [Route("empId/{id}")]
        public async Task<List<InterviewSchedule>> GetIDEmp(string id)
        {
            var getData = await _context.InterviewSchedules.Include("Joblist").Include("Site").Where(x => x.EmpId == id).ToListAsync();
            if (getData == null)
            {
                return null;
            }
            return getData;
        }
    }
}
