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
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewSchedulesController : BaseController<InterviewSchedule, InterviewSchedulesRepository>
    {
        readonly InterviewSchedulesRepository _interviewscheduleRepo;
        public InterviewSchedulesController(InterviewSchedulesRepository interviewSchedulesRepo) : base(interviewSchedulesRepo)
        {
            _interviewscheduleRepo = interviewSchedulesRepo;
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
    }
}
