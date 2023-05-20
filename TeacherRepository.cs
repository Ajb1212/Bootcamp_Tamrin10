namespace Tamrin9
{
    class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ICollection<Teacher> entities) : base(entities)
        {
        }
    }
}