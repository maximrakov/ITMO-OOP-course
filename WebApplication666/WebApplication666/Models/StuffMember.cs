using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication666.Models
{
    [Serializable]
    public class StuffMember
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public List<StuffMember> employees { get; set; }
        public List<Problem>tasks { get; set; }
        public StuffMember(string login)
        {
            Login = login;
            employees = new List<StuffMember>();
            tasks = new List<Problem>();
        }
    }
}
