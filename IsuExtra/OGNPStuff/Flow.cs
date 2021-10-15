using System;
using System.Collections.Generic;
using Isu.Models;
using IsuExtra.Tools;
namespace IsuExtra.OGNPStuff
{
    public class Flow
    {
        private List<Employment> classes;
        public int FreePlaces { get; set; }
        public Group Group { get; set; }
        public Flow(string groupName, int freePlaces)
        {
            Group = new Group(groupName);
            classes = new List<Employment>();
            FreePlaces = freePlaces;
        }

        public bool HasStudent(Student student)
        {
            return Group.FindStudent(student.Name) == student;
        }

        public void AddStudent(Student student)
        {
            if (student is null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (FreePlaces <= 0)
            {
                throw new OGNPException("Flow does not have free places");
            }
            else
            {
                FreePlaces--;
            }

            if (student.Group.Name[0] == Group.Name[0])
            {
                throw new OGNPException("Student can't register to OGNP which realize by his MF");
            }

            Group.AddStudent(student);
        }

        public void AddClasses(string time, string teacher, string auditory)
        {
            if (teacher is null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            if (auditory is null)
            {
                throw new ArgumentNullException(nameof(auditory));
            }

            classes.Add(new Employment(Group, time, teacher, auditory));
        }

        public bool HasIntersection(Flow anotherFlow)
        {
            foreach (Employment curClass in classes)
            {
                foreach (Employment anothClass in anotherFlow.classes)
                {
                    if (curClass.HasIntersection(anothClass))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void DeleteStudent(Student deletableStudent)
        {
            Group.DeleteStudent(deletableStudent);
            FreePlaces++;
        }

        public List<Student> GetAllStudents()
        {
            return Group.Students;
        }
    }
}
