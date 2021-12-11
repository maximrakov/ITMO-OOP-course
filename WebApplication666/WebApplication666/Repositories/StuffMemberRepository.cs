using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication666.Models;

namespace WebApplication666.Repositories
{
    public class StuffMemberRepository
    {
        private static List<StuffMember> stuffMembers;
        private static bool isCreate = false;
        public StuffMemberRepository()
        {
            try
            {
                stuffMembers = Deserial();
            }
            catch
            {
                stuffMembers = new List<StuffMember>();
            }
        }

        public StuffMember FindBoss(StuffMember stuff)
        {
            foreach(StuffMember stuffMember in stuffMembers)
            {
                if (stuffMember.employees.Contains(stuff))
                {
                    return stuffMember;
                }
            }
            return null;
        }


        public void addMember(StuffMember stuffMember)
        {
            stuffMembers.Add(stuffMember);
            Serial(stuffMembers);
        }

        public StuffMember FindById(int id)
        {
            foreach(StuffMember stuffMember in stuffMembers)
            {
                if(stuffMember.Id == id)
                {
                    return stuffMember;
                }
            }
            return null;
        }

        public void DeleteMember(int id)
        {
            foreach (StuffMember stuffMember in stuffMembers)
            {
                if (stuffMember.Id == id)
                {
                    stuffMembers.Remove(stuffMember);
                    break;
                }
            }
            Serial(stuffMembers);
        }

        public List<StuffMember> GetAll()
        {
            return stuffMembers;
        }

        public void AddEmployee(StuffMember head, StuffMember employee)
        {
            foreach(StuffMember stuffMember in stuffMembers)
            {
                if(stuffMember.Id == head.Id)
                {
                    stuffMember.employees.Add(employee);
                }
            }
            Serial(stuffMembers);
        }

        public void ChangeHead(StuffMember oldHead, StuffMember emoloyee, StuffMember newHead)
        {
            foreach(StuffMember stuffMember in stuffMembers)
            {
                if(oldHead.Id == stuffMember.Id)
                {
                    stuffMember.employees.Remove(emoloyee);
                }
            }
            foreach (StuffMember stuffMember in stuffMembers)
            {
                if (newHead.Id == stuffMember.Id)
                {
                    stuffMember.employees.Add(emoloyee);
                }
            }
            Serial(stuffMembers);
        }

        private static void Serial(List<StuffMember> stuffMembers)
        {
            string json = JsonSerializer.Serialize(stuffMembers);
            File.WriteAllText(@"D:\reportsStuff\aba.txt", json);
        }

        private static List<StuffMember> Deserial()
        {
            string text = File.ReadAllText(@"D:\reportsStuff\aba.txt", Encoding.UTF8);
            return JsonSerializer.Deserialize <List<StuffMember>>(text);
        }
    }
}
