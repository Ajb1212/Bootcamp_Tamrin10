namespace Tamrin9
{
    class Student : BaseEntity
    {
        public Student() => Id = Interlocked.Increment(ref _id);
        static int _id;

        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Field { get; set; } = "";
    }
}