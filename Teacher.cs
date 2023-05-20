namespace Tamrin9
{
    class Teacher : BaseEntity
    {
        public Teacher() => Id = Interlocked.Increment(ref _id);
        static int _id;

        public string Name { get; set; } = "";
        public string Subject { get; set; } = "";
    }
}