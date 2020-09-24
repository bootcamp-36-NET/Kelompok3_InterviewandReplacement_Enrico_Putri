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
    public class ReplacementRepo : GeneralRepo<Replacement, MyContext>
    {
        readonly MyContext _context;
        IConfiguration _configuration;
        public ReplacementRepo(MyContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<int> Create(Replacement replacement)
        {
            //interviewSchedule.empId = interviewSchedule.empId;
            replacement.CreateData = DateTimeOffset.Now;
            replacement.isDelete = false;
            await _context.Set<Replacement>().AddAsync(replacement);
            var createItem = await _context.SaveChangesAsync();
            return createItem;
        }

        public override async Task<List<Replacement>> GetAll()
        {
            List<ReplacementVM> list = new List<ReplacementVM>();
            var data = await _context.Replacements.Include("Site").Where(x => x.isDelete == false).ToListAsync();
            if (data.Count == 0)
            {
                return null;
            }
            return data;
        }
    }
}
