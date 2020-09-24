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
    public class PlacementsController : BaseController<Placement, PlacementRepo>
    {
        readonly PlacementRepo _placementRepo;
        public PlacementsController(PlacementRepo placementRepo) : base(placementRepo)
        {
            _placementRepo = placementRepo;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, Placement entity)
        {
            var getid = await _placementRepo.GetID(id);
            getid.EmpId = entity.EmpId;
            getid.SiteId = entity.SiteId;
            var data = await _placementRepo.Update(getid);
            if (data.Equals(null))
            {
                return BadRequest("Data is not Update");
            }
            return Ok("Update Successfull");
        }
    }
}