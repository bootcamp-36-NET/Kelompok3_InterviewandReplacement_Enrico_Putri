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
        public int joblistID { get; set; }
        public string joblistName { get; set; }
        public int siteId { get; set; }
        public string siteName { get; set; }
        public string siteSupName { get; set; }
        public DateTimeOffset CreateData { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public DateTimeOffset DeleteData { get; set; }
        public bool isDelete { get; set; }

        
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
