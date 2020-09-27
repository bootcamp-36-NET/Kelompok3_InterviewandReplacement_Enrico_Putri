using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class ScheduleEmpVM
    {
        public int Id { get; set; }
        public DateTime Interview_date { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public int JoblistId { get; set; }
        public string JoblistName { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }

        public DateTimeOffset CreateData { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public DateTimeOffset DeleteData { get; set; }
        public bool isDelete { get; set; }
    }
}
