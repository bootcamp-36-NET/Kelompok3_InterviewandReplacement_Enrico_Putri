using API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class InterviewVM : BaseModel
    {
        public int Id { get; set; }
        public DateTime interview_date { get; set; }
        public string empId { get; set; }
        public string empName { get; set; }
        public string joblistID { get; set; }
        public string joblistName { get; set; }
        public int siteId { get; set; }
        public int siteName { get; set; }
        public int siteSupName { get; set; }
        public DateTimeOffset CreateData { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public DateTimeOffset DeleteData { get; set; }
        public bool isDelete { get; set; }
    }
}
