using API.Context;
using API.Model;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class PlacementRepo : GeneralRepo<Placement, MyContext>
    {
        readonly MyContext _context;
        IConfiguration _configuration;
        public PlacementRepo(MyContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<int> Create(Placement placement)
        {
            //interviewSchedule.empId = interviewSchedule.empId;
            placement.CreateData = DateTimeOffset.Now;
            placement.isDelete = false;
            await _context.Set<Placement>().AddAsync(placement);
            var createItem = await _context.SaveChangesAsync();
            return createItem;
        }

        public override async Task<List<Placement>> GetAll()
        {
            List<PlacementVM> list = new List<PlacementVM>();
            var data = await _context.Placements.Include("Site").Where(x => x.isDelete == false).ToListAsync();
            if (data.Count == 0)
            {
                return null;
            }
            return data;
        }
    }
}
