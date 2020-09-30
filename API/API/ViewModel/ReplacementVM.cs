using API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class ReplacementVM : BaseModel
    {
        public int Id { get; set; }
        public string Replacement_reason { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public int SiteId { get; set; }
        public int siteId { get; set; }
        public string siteName { get; set; }
        public string siteSupName { get; set; }
        public int sitephone { get; set; }
        public string siteaddress { get; set; }
        public DateTimeOffset CreateData { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public DateTimeOffset DeleteData { get; set; }
        public bool isDelete { get; set; }
        public bool Approve { get; set; }
        public bool Reject { get; set; }
    }
}
