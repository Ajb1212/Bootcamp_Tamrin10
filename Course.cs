namespace Tamrin9
{
    class Course : BaseEntity
    {
        public Course() => Id = Interlocked.Increment(ref _id);
        static int _id;

        public string Name { get; set; } = "";
        public TimeSpan Duration { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public Teacher Teacher { get; set; } = new Teacher();
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}