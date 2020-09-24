using API.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("TB_M_Placement")]
    public class Placement : BaseModel
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public DateTime PlacementDate { get; set; }
        public DateTime PlacementEndDate { get; set; }

        [ForeignKey("Site")]
        public int SiteId { get; set; }
        public Site Site { get; set; }

        public DateTimeOffset CreateData { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public DateTimeOffset DeleteData { get; set; }
        public bool isDelete { get; set; }

        //public ICollection<Replacement> Replacements { get; set; }
    }
}
