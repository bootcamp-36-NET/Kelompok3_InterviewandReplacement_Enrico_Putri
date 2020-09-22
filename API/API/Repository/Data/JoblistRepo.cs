using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class JoblistRepo : GeneralRepo<Joblist, MyContext>
    {
        public JoblistRepo(MyContext context) : base(context)
        {

        }
    }
}
