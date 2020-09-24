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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacementsController : BaseController<Placement, PlacementRepository>
    {
        readonly PlacementRepository _placementRepository;
        private readonly MyContext _context;
        public PlacementsController(PlacementRepository placementRepository, MyContext myContext) : base(placementRepository)
        {
            _placementRepository = placementRepository;
            this._context = myContext;
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

        [Route("semuaPlacement")]
        [HttpGet]
        public async Task<List<PlacementVM>> GetAllSemua()
        {
            List<PlacementVM> list = new List<PlacementVM>();
            var data = await _context.Placements.Include("Site").Where(x => x.isDelete == false).ToListAsync();
            if (data.Count == 0)
            {
                return null;
            }
            foreach (var placement in data)
            {
                var emp = new PlacementVM()
                {
                    Id = placement.Id,
                    EmpId = placement.EmpId,
                    //    EmpName = replacement.EmpId,
                    PlacementDate = placement.PlacementDate,
                    PlacementEndDate = placement.PlacementEndDate,
                    SiteId = placement.SiteId,
                    SiteName = placement.Site.Name,
                    Supervisor_name = placement.Site.Supervisor_name,
                    Address = placement.Site.Address
                };
                list.Add(emp);
            }
            return list;
        }
    }
}