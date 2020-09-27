using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class JoblistRepository : GeneralRepo<Joblist, MyContext>
    {
        public JoblistRepository(MyContext context) : base(context)
        {

        }
    }
}
