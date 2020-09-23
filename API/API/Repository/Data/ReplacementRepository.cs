using API.Context;
using API.Model;
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
    }
}

