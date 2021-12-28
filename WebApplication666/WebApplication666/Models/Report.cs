using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication666.Models
{
    public class Report
    {
        public int Id { get; set; }
        public StuffMember StuffMember { get; set; }
        public string Info { get; set; }
        public Report(StuffMember stuffMember, string info)
        {
            StuffMember = stuffMember;
            Info = info;
        }
    }
}
