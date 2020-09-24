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
    public class ReplacementsController : BaseController<Replacement, ReplacementRepository>
    {
        readonly ReplacementRepository _replacementRepository;
        private readonly MyContext _context;
        public ReplacementsController(ReplacementRepository replacementRepository, MyContext myContext) : base(replacementRepository)
        {
            _replacementRepository = replacementRepository;
            this._context = myContext;
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

        //    getAllReplacements
        [Route("semua")]
        [HttpGet]
        public async Task<List<ReplacementVM>> GetAllSemua()
        {
            List<ReplacementVM> list = new List<ReplacementVM>();
            var data = await _context.Replacements.Include("Site").Where(x => x.isDelete == false).ToListAsync();
            if (data.Count == 0)
            {
                return null;
            }
            foreach (var replacement in data)
            {
                var emp = new ReplacementVM()
                {
                    Id = replacement.Id,
                    EmpId = replacement.EmpId,
                    //    EmpName = replacement.EmpId,
                    Replacement_reason = replacement.Replacement_reason,
                    SiteId = replacement.SiteId,
                    SiteName = replacement.Site.Name,
                    Supervisor_name = replacement.Site.Supervisor_name,
                    Address= replacement.Site.Address
                };
                list.Add(emp);
            }
            return list;
        }

        //[Route("semua")]
        //[HttpGet("{id}")]
        //public async Task<ReplacementVM> GetID(int Id)
        //{
        //    var getData = await _context.Replacements.Include("Site").SingleOrDefaultAsync(x => x.Id == Id);
        //    if (getData == null)
        //    {
        //        return null;
        //    }
        //    var emp = new ReplacementVM()
        //    {
        //        Id = getData.Id,
        //        EmpId = getData.EmpId,
        //        //    EmpName = getData.EmpId,
        //        Replacement_reason = getData.Replacement_reason,
        //        SiteId = getData.Site.Id,
        //        Address = getData.Site.Address,
        //        SiteName = getData.Site.Name,
        //        Supervisor_name = getData.Site.Supervisor_name
        //    };
        //    return emp;
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var getData = _context.Replacements.Include("Site").Where(x => x.isDelete == false).SingleOrDefault(x => x.Id == id);
        //        if (getData == null)
        //        {
        //            return BadRequest("Not Successfully");
        //        }
        //        getData.DeleteData = DateTimeOffset.Now;
        //        getData.isDelete = true;

        //        //_context.Employees.Update(getData);
        //        _context.Entry(getData).State = EntityState.Modified;
        //        _context.SaveChanges();
        //        return Ok("Successfully Deleted");
        //    }
        //    return BadRequest("Not Successfully");
        
    }
}