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
    public class ReplacementsController : BaseController<Replacement, ReplacementRepository>
    {
        readonly ReplacementRepository _replacementRepo;
        public ReplacementsController(ReplacementRepository replacementRepo) : base(replacementRepo)
        {
            _replacementRepo = replacementRepo;
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
    }
}