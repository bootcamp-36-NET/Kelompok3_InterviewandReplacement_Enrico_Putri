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
    public class SitesController : BaseController<Site, SiteRepository>
    {
        private readonly SiteRepository _siteRepository;

        public SitesController(SiteRepository siteRepository) : base(siteRepository)
        {
            this._siteRepository = siteRepository;
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<int>> Update(int id, Site entity)
        {
            var getId = await _siteRepository.GetID(id);
            getId.Name = entity.Name;
            getId.PhoneNumber = entity.PhoneNumber;
            getId.Supervisor_name = entity.Supervisor_name;
            var data = await _siteRepository.Update(getId);
            if (data.Equals(null))
            {
                return BadRequest("Update Unsuccessfull");
            }
            return Ok("Update Successfull");
        }
    }
}