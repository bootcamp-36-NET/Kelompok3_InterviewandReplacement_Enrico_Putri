using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class ReplacementVM
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Replacement_reason { get; set; }
        public int SiteId { get; set; }
        public int SiteName { get; set; }
        public int SiteSupName { get; set; }
    }
}
