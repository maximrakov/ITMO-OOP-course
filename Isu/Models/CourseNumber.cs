namespace Isu.Models
{
    public class CourseNumber
    {
        private int _course;

        public CourseNumber(int course)
        {
            _course = course;
        }

        public int Course => _course;
    }
}