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
    public class InterviewSchedulesRepo : GeneralRepo<InterviewSchedule, MyContext>
    {
        readonly MyContext _context;
        IConfiguration _configuration;
        public InterviewSchedulesRepo(MyContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<int> Create(InterviewSchedule interviewSchedule)
        {
            //interviewSchedule.empId = interviewSchedule.empId;
            interviewSchedule.CreateData = DateTimeOffset.Now;
            interviewSchedule.isDelete = false;
            await _context.Set<InterviewSchedule>().AddAsync(interviewSchedule);
            var createItem = await _context.SaveChangesAsync();
            return createItem;
        }

        public override async Task<List<InterviewSchedule>> GetAll()
        {
            List<InterviewVM> list = new List<InterviewVM>();
            var data = await _context.InterviewSchedules.Include("Joblist").Include("Site").Where(x => x.isDelete == false).ToListAsync();
            if (data.Count == 0)
            {
                return null;
            }
            return data;
        }

        //public override async Task<InterviewSchedule> GetID(int Id)
        //{
        //    var data = await _context.InterviewSchedules.Include("joblist").Include("site").SingleOrDefaultAsync(x => x.Id == Id && x.isDelete == false);

        //    if (!data.Equals(0))
        //    {
        //        return data;
        //    }
        //    return null;
        //}
    }
}
