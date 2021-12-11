using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication666.Models;
using WebApplication666.Repositories;

namespace WebApplication666.Services
{
    public class TaskService
    {
        private static int id = 0;
        private static TaskRepository taskRepository = new TaskRepository();
        private static StuffMemberRepository stuffMember = new StuffMemberRepository();
        public void addTask(string info)
        {
            Problem problem = new Problem(info, DateTime.Now);
            problem.Id = id;
            id++;
            taskRepository.AddProblem(problem);
        }
        public Problem FindById(int problemId)
        {
            return taskRepository.FindById(problemId);
        }
        public List<Problem> FindAll()
        {
            return taskRepository.FindAll();
        }
        public List<Problem> FindMemeberProblems(StuffMember stuffMember) 
        {
            return taskRepository.FindMemeberProblems(stuffMember);
        }
        public void AddComments(string uid, int pid, string mess)
        {
            taskRepository.AddComments(uid, pid, mess);
        }
    }
}
