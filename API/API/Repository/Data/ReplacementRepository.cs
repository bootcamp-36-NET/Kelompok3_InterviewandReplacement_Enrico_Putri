using API.Context;
using API.Model;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ReplacementRepository : GeneralRepo<Replacement, MyContext>
    {
        MyContext _context;
        public ReplacementRepository(MyContext myContext) : base(myContext) //bisa pake SP dalam sini
        {
            _context = myContext;
        }

        public override async Task<int> Create(Replacement replacement)
        {
            replacement.EmpId = replacement.EmpId;
            replacement.SiteId = replacement.SiteId;
            replacement.Replacement_reason = replacement.Replacement_reason;
            replacement.CreateData = DateTimeOffset.Now;
            replacement.isDelete = false;
            await _context.Set<Replacement>().AddAsync(replacement);
            var createItem = await _context.SaveChangesAsync();
            return createItem;
        }

       
        //public override async Task<List<ReplacementVM>> GetAll()
        //{
        //    List<ReplacementVM> list = new List<ReplacementVM>();
        //    var data = await _context.Replacements.Include("Site").Where(x => x.isDelete == false).ToListAsync();
        //    if (data.Count == 0)
        //    {
        //        return null;
        //    }
        //    foreach (var replacement in data)
        //    {
        //        var emp = new ReplacementVM()
        //        {
        //            Id = replacement.Id,
        //            EmpId = replacement.EmpId,
        //            //    EmpName = replacement.EmpId,
        //            Replacement_reason = replacement.Replacement_reason,
        //            SiteId = replacement.SiteId,
        //            SiteName = replacement.Site.Name,
        //            SiteSupName = replacement.Site.Supervisor_name,
        //            AddressSite = replacement.Site.Address
        //        };
        //        list.Add(emp);
        //    }
        //    return list;
        //}
    }
}

