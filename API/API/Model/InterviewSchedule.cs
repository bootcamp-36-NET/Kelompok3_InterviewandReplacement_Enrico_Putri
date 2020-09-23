using API.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class InterviewSchedule : BaseModel
    {
        public int Id { get; set; }
        public DateTime Interview_date { get; set; }
        public string EmpId { get; set; }

        [ForeignKey("joblist")]
        public int JoblistId { get; set; }
        public Joblist Joblist { get; set; }

        [ForeignKey("site")]
        public int SiteId { get; set; }
        public Site Site { get; set; }

        public DateTimeOffset CreateData { get; set ; }
        public DateTimeOffset UpdateDate { get; set; }
        public DateTimeOffset DeleteData { get; set; }
        public bool isDelete { get; set; }
    }
}
