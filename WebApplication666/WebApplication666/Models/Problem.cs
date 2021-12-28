using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication666.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public string State { get; set; }
        public string Info { get; set; }
        public List<String> Comments { get; set; }
        public StuffMember stuffMember { get; set; }
        public Problem(string info, DateTime creationTime)
        {
            Info = info;
            CreationDate = creationTime;
            Comments = new List<string>();
        }
    }
}
