using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication666.Models;
using WebApplication666.Repositories;

namespace WebApplication666.Services
{
    public class StuffMemberService
    {
        private static int id = 0;
        private static StuffMemberRepository stuffMemberRepository = new StuffMemberRepository();
        public void addMember(string login)
        {
            StuffMember stuffMember = new StuffMember(login);
            stuffMember.Id = id;
            id++;
            stuffMemberRepository.addMember(stuffMember);
        }

        public StuffMember FindBoss(StuffMember stuffMember)
        {
            return stuffMemberRepository.FindBoss(stuffMember);
        }
        public StuffMember GetById(int id)
        {
            return stuffMemberRepository.FindById(id);
        }

        public void DeleteMember(int id)
        {
            stuffMemberRepository.DeleteMember(id);
        }

        public List<StuffMember> GetAll()
        {
            return stuffMemberRepository.GetAll();
        }

        public void AddEmployee(StuffMember head, StuffMember employee)
        {
            stuffMemberRepository.AddEmployee(head, employee);
        }

        public void ChangeHead(StuffMember employee, StuffMember newHead)
        {
            stuffMemberRepository.ChangeHead(FindBoss(employee), employee, newHead);
        }
        
        public void Appoint(string emp, string empn)
        {
            StuffMember stuffMember = GetById(Int32.Parse(emp));
            StuffMember stuffMember1 = GetById(Int32.Parse(empn));
        }
    }
}
