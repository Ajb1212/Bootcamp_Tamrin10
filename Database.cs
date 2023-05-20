namespace Tamrin9
{
    class Database
    {
        public static ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
        public static ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public static ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}