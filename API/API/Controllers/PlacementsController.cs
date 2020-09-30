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
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacementsController : BaseController<Placement, PlacementRepository>
    {
        readonly PlacementRepository _placementRepo;
        readonly MyContext _context;
        public PlacementsController(PlacementRepository placementRepo, MyContext context) : base(placementRepo)
        {
            _placementRepo = placementRepo;
            _context = context;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, Placement entity)
        {
            var getid = await _placementRepo.GetID(id);
            getid.EmpId = entity.EmpId;
            getid.SiteId = entity.SiteId;
            getid.PlacementDate = entity.PlacementDate;
            getid.PlacementEndDate = entity.PlacementEndDate;
            var data = await _placementRepo.Update(getid);
            if (data.Equals(null))
            {
                return BadRequest("Data is not Update");
            }
            return Ok("Update Successfull");
        }


        [HttpGet]
        [Route("empId/{id}")]
        public async Task<List<Placement>> GetIDEmp(string id)
        {
            var getData = await _context.Placements.Include("Site").Where(x => x.EmpId == id && x.isDelete == false).ToListAsync();
            if (getData == null)
            {
                return null;
            }
            return getData;
        }
    }
}