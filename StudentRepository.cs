namespace Tamrin9
{
    class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ICollection<Student> entities) : base(entities)
        {
        }
    }
}