namespace Tamrin9
{
    class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ICollection<Course> entities) : base(entities)
        {
        }

        public void AssignTeacherToCourse(int courseId, int teacherId)
        {
            //TODO
            var course = Get(courseId);
            //var teacher = 
        }
    }
}