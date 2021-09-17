namespace Isu.Models
{
    public class Student
    {
        private static int _globalId = 0;
        private string _name;
        private Group _group;
        private int _id;

        public Student(string name, Group group)
        {
            _id = _globalId++;
            _name = name;
            _group = group;
        }

        public string Name => _name;

        public Group Group
        {
            get => _group;
            set => _group = value;
        }

        public int Id => _id;
    }
}