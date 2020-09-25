using API.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("TB_M_Replacement")]
    public class Replacement : BaseModel
    {
        public int Id { get; set; }
        public string Replacement_reason { get; set; }
        public string EmpId { get; set; }

        [ForeignKey("Site")]
        public int SiteId { get; set; }
        public Site Site { get; set; }

        public DateTimeOffset CreateData { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public DateTimeOffset DeleteData { get; set; }
        public bool isDelete { get; set; }

        public bool Reject { get; set; }
        public bool Approve { get; set; }
    }
}
