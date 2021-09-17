using System;
using System.Collections.Generic;
using Isu.Tools;
namespace Isu.Models
{
    public class Group
    {
        private List<Student> _students = new List<Student>();
        private int _courseNumber;
        private string _name;
        public Group(string name)
        {
            _name = name;
            _courseNumber = Convert.ToInt32(name[2]) - 48;
            if (IsNameOfGroupValid(name))
            {
                throw new IsuException("Invalid name of group");
            }
        }

        public List<Student> Students => _students;

        public int CourseNumber => _courseNumber;

        public string Name => _name;

        public Student GetStudent(int id)
        {
            return _students.Find(x => x.Id == id);
        }

        public Student FindStudent(string name)
        {
            return _students.Find(x => x.Name == name);
        }

        public void AddStudent(Student newStudent)
        {
            _students.Add(newStudent);
            if (_students.Count > 27)
            {
                throw new IsuException("Reach max student per group");
            }
        }

        public void DeleteStudent(Student deletableStudent)
        {
            _students.Remove(deletableStudent);
        }

        private bool IsNameOfGroupValid(string name)
        {
            return name.Length != 5 || !char.IsLetter(name[0]) || !char.IsNumber(name[1]) || !char.IsNumber(name[2]) ||
                   !char.IsNumber(name[3]);
        }
    }
}