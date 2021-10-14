using System;
using System.Collections.Generic;
using Isu.Models;
using IsuExtra.OGNPStuff;
using IsuExtra.Tools;
namespace IsuExtra.Managers
{
    public class OGNPManager
    {
        private List<OGNP> ognps;
        public OGNPManager()
        {
            ognps = new List<OGNP>();
        }

        public void RegisterStudentForFlow(Student student, Flow flow, OGNP ognp)
        {
            foreach (OGNP curOGNP in ognps)
            {
                if (ognp == curOGNP)
                {
                    continue;
                }

                List<Flow> flows = curOGNP.GetFlows();
                foreach (Flow curFlow in flows)
                {
                    if (curFlow.HasStudent(student) && flow.HasIntersection(curFlow))
                    {
                        throw new OGNPException("Intersection detected");
                    }
                }
            }

            ognp.RegisterStudentForFlow(student, flow);
        }

        public OGNP CreateOGNP(string name)
        {
            var ognp = new OGNP(name);
            ognps.Add(ognp);
            return ognp;
        }

        public List<Student> GetNotRegisteredStudents(Group group)
        {
            var notRegisteredStudents = new List<Student>();
            List<Student> students = group.Students;
            foreach (Student student in students)
            {
                bool hasFlow = false;
                foreach (OGNP ognp in ognps)
                {
                    if (ognp.FindStudentsFlow(student) != null)
                    {
                        hasFlow = true;
                        break;
                    }
                }

                if (!hasFlow)
                {
                    notRegisteredStudents.Add(student);
                }
            }

            return notRegisteredStudents;
        }
    }
}
