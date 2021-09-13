using System.Collections.Generic;
using System.Linq;
using Isu.Models;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<Group> _allGroups = new List<Group>();
        public Group AddGroup(string name)
        {
            var newGroup = new Group(name);
            _allGroups.Add(newGroup);
            return newGroup;
        }

        public Student AddStudent(Group @group, string name)
        {
            var newStudent = new Student(name, group);
            group.AddStudent(newStudent);
            return newStudent;
        }

        public Student GetStudent(int id)
        {
            var requiredStudent = _allGroups.Find(x => (x.GetStudent(id) != null))?.GetStudent(id);
            if (requiredStudent == null)
            {
                throw new IsuException("Student not found");
            }
            else
            {
                return requiredStudent;
            }
        }

        public Student FindStudent(string name)
        {
            return _allGroups.Find(x => (x.FindStudent(name) != null))?.FindStudent(name);
        }

        public List<Student> FindStudents(string groupName)
        {
            return FindGroup(groupName).Students;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var groups = FindGroups(courseNumber);
            return groups.SelectMany(x => x.Students).ToList();
        }

        public Group FindGroup(string groupName)
        {
            return _allGroups.Find(x => x.Name == groupName);
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            int numberOfCourse = courseNumber.Course;
            return _allGroups.FindAll(x => x.CourseNumber == numberOfCourse);
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            Group oldGroup = student.Group;
            oldGroup.DeleteStudent(student);
            student.Group = newGroup;
            newGroup.AddStudent(student);
        }
    }
}