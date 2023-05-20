namespace Tamrin9
{
    interface ICourseRepository : IRepository<Course>
    {
        void AssignTeacherToCourse(int courseId, int teacherId);
    }
}