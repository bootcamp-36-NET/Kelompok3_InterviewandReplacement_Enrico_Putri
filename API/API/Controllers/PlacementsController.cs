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
    public class PlacementsController : BaseController<Placement, PlacementRepository>
    {
        readonly PlacementRepository _placementRepository;
        readonly MyContext myContext;
        public PlacementsController(PlacementRepository placementRepository) : base(placementRepository)
        {
            _placementRepository = placementRepository;
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<int>> Update(int Id, Placement entity)
        {
            var getId = await _placementRepository.GetID(Id);
            getId.EmpId = entity.EmpId;
            getId.PlacementDate = entity.PlacementDate;
            getId.PlacementEndDate = entity.PlacementEndDate;
            getId.SiteId = entity.SiteId;
            var data = await _placementRepository.Update(getId);
            if (data.Equals(null))
            {
                return BadRequest("Data is not Update");
            }
            return Ok("Update Successfull");
        }
    }
}