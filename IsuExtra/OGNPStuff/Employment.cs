using System;
using Isu.Models;

namespace IsuExtra.OGNPStuff
{
    public class Employment
    {
        public Employment(Group group, string time, string auditory, string teacher)
        {
            if (group is null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (auditory is null)
            {
                throw new ArgumentNullException(nameof(auditory));
            }

            if (teacher is null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            Time = time;
            Auditory = auditory;
            Teacher = teacher;
            Group = group;
        }

        public bool HasIntersection(Employment anotherEmploy)
        {
            return anotherEmploy.Time == Time;
        }

        public string Time { get; set; }
        public Group Group { get; set; }
        public string Auditory { get; set; }
        public string Teacher { get; set; }
    }
}