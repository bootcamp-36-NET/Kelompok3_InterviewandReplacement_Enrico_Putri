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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplacementsController : BaseController<Replacement, ReplacementRepository>
    {
        readonly ReplacementRepository _replacementRepository;
        readonly MyContext myContext;
        public ReplacementsController(ReplacementRepository replacementRepository) : base(replacementRepository)
        {
            _replacementRepository = replacementRepository;
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<int>> Update(int Id, Replacement entity)
        {
            var getId = await _replacementRepository.GetID(Id);
            getId.Replacement_reason = entity.Replacement_reason;
            getId.SiteId = entity.SiteId;
            var data = await _replacementRepository.Update(getId);
            if (data.Equals(null))
            {
                return BadRequest("Data is not Update");
            }
            return Ok("Update Successfull");
        }

    }

}