using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly MyContext _context;
        public ChartController(MyContext myContext)
        {
            _context = myContext;
        }
        // GET api/values
        [HttpGet]
        [Route("pie")]
        public async Task<List<ChartVM>> GetPie()
        {
            var data1 = await _context.Placements.Include("Site")
                           .Where(x => x.isDelete == false)
                           .GroupBy(q => q.Site.Name)
                            .Select(q => new ChartVM
                            {
                                SiteName = q.Key,
                                total = q.Count()
                            }).ToListAsync();

            return data1;
        }

        [HttpGet]
        [Route("bar")]
        public async Task<List<BarChartVM>> GetBar()
        {
            var data2 = await _context.Placements.Include("Site")
                           .Where(x => x.isDelete == false)
                           .GroupBy(q => q.Site.Name)
                            .Select(q => new BarChartVM
                            {
                                SiteName2 = q.Key,
                                total = q.Count()
                            }).ToListAsync();
            return data2;
        }
    }
}