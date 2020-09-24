using API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class PlacementVM : BaseModel
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime PlacementDate { get; set; }
        public DateTime PlacementEndDate { get; set; }
        public int SiteId { get; set; }
        public int siteName { get; set; }
        public int siteSupName { get; set; }
        public int sitephone { get; set; }
        public int siteaddress { get; set; }
        public DateTimeOffset CreateData { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public DateTimeOffset DeleteData { get; set; }
        public bool isDelete { get; set; }
    }
}
