using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class ApproveRejectVM
    {
        public string EmpId { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string RejectReason { get; set; }
    }
}
