using API.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("TB_M_Site")]
    public class Site : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supervisor_name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public DateTimeOffset CreateData { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public DateTimeOffset DeleteData { get; set; }
        public bool isDelete { get; set; }
    }
}
