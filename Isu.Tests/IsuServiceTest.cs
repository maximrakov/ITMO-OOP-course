using System;
using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;
using Isu.Models;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            string nameOfGroup = "M3205";
            Group currentGroup = _isuService.AddGroup(nameOfGroup);
            Student student = _isuService.AddStudent(currentGroup, "Ivan");
            List<Student> listOfStudents = _isuService.FindStudents(nameOfGroup);
            Assert.AreEqual(student.Group, currentGroup);
            Assert.AreEqual(listOfStudents.Contains(student), true);
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group overGroup = _isuService.AddGroup("M3205");
                for (int i = 0; i < 28; i++)
                {
                    overGroup.AddStudent(new Student("ivan", overGroup));
                }
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                _isuService.AddGroup("MM05");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group firstGroup = _isuService.AddGroup("M3105");
            Group secondGroup = _isuService.AddGroup("M3205");
            Student student = _isuService.AddStudent(firstGroup, "Alex");
            _isuService.ChangeStudentGroup(student, secondGroup);
            Assert.AreEqual(student.Group, secondGroup);
            Assert.AreEqual(firstGroup.FindStudent(student.Name), null);
            Assert.AreEqual(secondGroup.FindStudent(student.Name), student);
        }
    }
}