using System;
using System.Collections.Generic;
using NUnit.Framework;
using IsuExtra.Managers;
using IsuExtra.Tools;
using IsuExtra.OGNPStuff;
using Isu.Models;
using Isu.Services;
namespace IsuExtra.Tests
{
    public class Tests
    {
        OGNPManager ognpManager = new OGNPManager();
        IsuService isuService = new IsuService();
        [SetUp]
        public void Setup()
        {
            var ognpManager = new OGNPManager();
            var isuService = new IsuService();
        }

        [Test]
        public void RegisterStudentsForOGNP()
        {
            var groupN = isuService.AddGroup("N3205");
            var groupM = isuService.AddGroup("M3205");
            var ivan = isuService.AddStudent(groupN, "Ivan");
            var petr = isuService.AddStudent(groupM, "Petr");
            OGNP ognp1 = ognpManager.CreateOGNP("M");
            Flow ognp1Flow = ognp1.RegisterFlow("0001", 10);
            ognp1Flow.AddClasses("WD 15:20", "Ivan Ivanov", "100");
            ognp1.RegisterStudentForFlow(ivan, ognp1Flow);
            Assert.AreEqual(ognp1Flow.HasStudent(ivan), true);
            Assert.Catch<OGNPException>(() =>
            {
                ognp1.RegisterStudentForFlow(petr, ognp1Flow);
            });
            ognp1.CancelRegistration(ivan);
            Assert.AreEqual(ognp1.FindStudentsFlow(ivan), null);
        }
        [Test]
        public void GetStudentsWhoDoesNotHaveOGNP()
        {
            Group group = isuService.AddGroup("M3205");
            var ivan = isuService.AddStudent(group, "Ivan");
            var petr = isuService.AddStudent(group, "Petr");
            var georgiy = isuService.AddStudent(group, "Georgiy");
            OGNP ognp1 = ognpManager.CreateOGNP("N");
            Flow ognp1Flow = ognp1.RegisterFlow("0000", 100);
            ognp1.RegisterStudentForFlow(ivan, ognp1Flow);
            ognp1.RegisterStudentForFlow(petr, ognp1Flow);
            Assert.AreEqual(ognpManager.GetNotRegisteredStudents(group)[0], georgiy);
        }
        [Test]
        public void IntersectionCheck()
        {
            OGNP ognp1 = ognpManager.CreateOGNP("Z");
            OGNP ognp2 = ognpManager.CreateOGNP("N");
            Group group = isuService.AddGroup("M3205");
            Student ivan = isuService.AddStudent(group, "Ivan");
            Flow flow1 = ognp1.RegisterFlow("0001", 20);
            Flow flow2 = ognp2.RegisterFlow("0002", 20);
            ognp1.AddClassesToFlow(flow1, "MD 13:30", "Ivan Ivanov", "100");
            ognp2.AddClassesToFlow(flow2, "MD 13:30", "Georgiy Ivanov", "200");
            ognpManager.RegisterStudentForFlow(ivan, flow1, ognp1);
            Assert.Catch<OGNPException>(() =>
            {
                ognpManager.RegisterStudentForFlow(ivan, flow2, ognp2);
            });
        }
    }
}