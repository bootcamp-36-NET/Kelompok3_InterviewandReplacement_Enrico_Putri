using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class PlacementRepository : GeneralRepo<Placement, MyContext>
    {
        MyContext _context;
        public PlacementRepository(MyContext myContext) : base(myContext) //bisa pake SP dalam sini
        {
            _context = myContext;
        }

        public override async Task<int> Create(Placement placement)
        {
            placement.EmpId = placement.EmpId;
            placement.SiteId = placement.SiteId;
            placement.PlacementDate = placement.PlacementDate;
            placement.PlacementEndDate = placement.PlacementEndDate;
            placement.CreateData = DateTimeOffset.Now;
            placement.isDelete = false;
            await _context.Set<Placement>().AddAsync(placement);
            var createItem = await _context.SaveChangesAsync();
            return createItem;
        }
    }
}
