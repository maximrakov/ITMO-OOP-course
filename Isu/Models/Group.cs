using System;
using System.Collections.Generic;
using Isu.Tools;
namespace Isu.Models
{
    public class Group
    {
        public Group(string name)
        {
            Name = name;
            CourseNumber = Convert.ToInt32(name[2]) - 48;
            Students = new List<Student>();
            if (IsNameOfGroupValid(name))
            {
                throw new IsuException("Invalid name of group");
            }
        }

        public List<Student> Students { get; }
        public string Name { get; }
        public int CourseNumber { get; }

        public Student GetStudent(int id)
        {
            return Students.Find(x => x.Id == id);
        }

        public Student FindStudent(string name)
        {
            return Students.Find(x => x.Name == name);
        }

        public void AddStudent(Student newStudent)
        {
            Students.Add(newStudent);
            if (Students.Count > 27)
            {
                throw new IsuException("Reach max student per group");
            }
        }

        public void DeleteStudent(Student deletableStudent)
        {
            Students.Remove(deletableStudent);
        }

        private bool IsNameOfGroupValid(string name)
        {
            return name.Length != 5 || !char.IsLetter(name[0]) || !char.IsNumber(name[1]) || !char.IsNumber(name[2]) ||
                   !char.IsNumber(name[3]);
        }
    }
}