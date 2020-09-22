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
    public class InterviewSchedulesController : BaseController<InterviewSchedule, InterviewSchedulesRepo>
    {
        readonly InterviewSchedulesRepo _joblistRepo;
        public InterviewSchedulesController(InterviewSchedulesRepo interviewSchedulesRepo) : base(interviewSchedulesRepo)
        {
            _joblistRepo = interviewSchedulesRepo;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, Joblist entity)
        {
            var getid = await _joblistRepo.GetID(id);
            //getid.Name = entity.Name;
            var data = await _joblistRepo.Update(getid);
            if (data.Equals(null))
            {
                return BadRequest("Update Unsuccessfull");
            }
            return data;
        }
    }
}
