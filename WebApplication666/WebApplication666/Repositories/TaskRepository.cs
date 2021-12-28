using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication666.Models;

namespace WebApplication666.Repositories
{
    public class TaskRepository
    {
        private static List<Problem> tasks;
        public TaskRepository()
        {
            try
            {
                tasks = Deserial();
            }
            catch
            {
                tasks = new List<Problem>();
            }
        }
        public void AddProblem(Problem problem)
        {
            tasks.Add(problem);
            Serial(tasks);
        }

        public Problem FindById(int problemId)
        {
            foreach(Problem problem in tasks)
            {
                if(problem.Id == problemId)
                {
                    return problem;
                }
            }
            return null;
        }

        public List<Problem> FindAll()
        {
            return tasks;
        }

        public List<Problem> FindMemeberProblems(StuffMember stuffMember)
        {
            List<Problem> stuffProblems = new List<Problem>();
            foreach(Problem problem in tasks)
            {
                if(problem.stuffMember == stuffMember)
                {
                    stuffProblems.Add(problem);
                }
            }
            return stuffProblems;
        }

        public void AddComments(string uid, int pid, string mess)
        {
            foreach (Problem problem in tasks)
            {
                if(problem.Id == pid)
                {
                    problem.Comments.Add(uid + ": "+ mess);
                }
            }
            Serial(tasks);
        }
        private static void Serial(List<Problem> stuffMembers)
        {
            string json = JsonSerializer.Serialize(stuffMembers);
            File.WriteAllText(@"D:\reportsStuff\Problems.txt", json);
        }

        private static List<Problem> Deserial()
        {
            string text = File.ReadAllText(@"D:\reportsStuff\Problems.txt", Encoding.UTF8);
            return JsonSerializer.Deserialize<List<Problem>>(text);
        }
    }
}
