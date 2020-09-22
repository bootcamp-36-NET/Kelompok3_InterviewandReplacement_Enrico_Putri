using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base;
using API.Model;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoblistsController : BaseController<Joblist, JoblistRepo>
    {
        readonly JoblistRepo _joblistRepo;
        public JoblistsController(JoblistRepo joblistRepo) : base(joblistRepo)
        {
            _joblistRepo = joblistRepo;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, Joblist entity)
        {
            var getid = await _joblistRepo.GetID(id);
            getid.Name = entity.Name;
            var data = await _joblistRepo.Update(getid);
            if (data.Equals(null))
            {
                return BadRequest("Update Unsuccessfull");
            }
            return data;
        }
    }
}