namespace Isu.Models
{
    public class Student
    {
        private static int _globalId = 0;

        public Student(string name, Group group)
        {
            Name = name;
            Group = group;
            Id = _globalId++;
        }

        public string Name { get; }
        public Group Group { get; set; }
        public int Id { get; }
    }
}