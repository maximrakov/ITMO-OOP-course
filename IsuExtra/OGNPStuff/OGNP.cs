using System;
using System.Collections.Generic;
using Isu.Models;
namespace IsuExtra.OGNPStuff
{
    public class OGNP
    {
        public string OGNPName { get; set; }
        private List<Flow> flows;

        public OGNP(string name)
        {
            OGNPName = name;
            flows = new List<Flow>();
        }

        public Flow RegisterFlow(string groupName, int freePlaces)
        {
            if (groupName is null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            var flow = new Flow(OGNPName + groupName, freePlaces);
            flows.Add(flow);
            return flow;
        }

        public void RegisterStudentForFlow(Student student, Flow flow)
        {
            flow.AddStudent(student);
        }

        public void AddClassesToFlow(Flow flow, string time, string teacher, string auditory)
        {
            if (flow is null)
            {
                throw new ArgumentNullException(nameof(flow));
            }

            if (teacher is null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            if (auditory is null)
            {
                throw new ArgumentNullException(nameof(auditory));
            }

            flow.AddClasses(time, teacher, auditory);
        }

        public Flow FindStudentsFlow(Student student)
        {
            foreach (Flow flow in flows)
            {
                if (flow.HasStudent(student))
                {
                    return flow;
                }
            }

            return null;
        }

        public void CancelRegistration(Student student)
        {
            Flow flow = FindStudentsFlow(student);
            flow.DeleteStudent(student);
        }

        public List<Flow> GetFlows()
        {
            return flows;
        }
    }
}