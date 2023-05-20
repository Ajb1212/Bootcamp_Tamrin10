using System.Text;

namespace Tamrin9
{
    internal class Program
    {
        static IStudentRepository _studentRepository = new StudentRepository(Database.Students);
        static ITeacherRepository _teacherRepository = new TeacherRepository(Database.Teachers);
        static ICourseRepository _courceRepository = new CourseRepository(Database.Courses);

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1- Insert Student");
                Console.WriteLine("2- Insert Teacher");
                Console.WriteLine("3- Insert Course");
                Console.WriteLine("4- Get Student");
                Console.WriteLine("5- Get Teacher");
                Console.WriteLine("6- Get Course");

                var command = Console.ReadLine() ?? throw new ArgumentNullException("Error!!!");
                switch (int.Parse(command))
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        AddTeacher();
                        break;
                    case 3:
                        AddCourse();
                        break;
                    case 4:
                        GetStudents();
                        break;
                    case 5:
                        GetTeachers();
                        break;
                    case 6:
                        GetCourses();
                        break;
                    case 7:
                        AssignTeacherToCourse();
                        break;
                }
            }
        }

        private static void AssignTeacherToCourse()
        {
            Console.WriteLine("What is the teacher id? = ");
            int teacherId = int.Parse(Console.ReadLine() ?? "1");
            Console.WriteLine("What is the class id? = ");
            int courseId = int.Parse(Console.ReadLine() ?? "1");
        }

        static void AddStudent()
        {
            var student = new Student();
            Console.WriteLine("Name = ");
            student.Name = Console.ReadLine() ?? "";
            Console.WriteLine("Age = ");
            student.Age = int.Parse(Console.ReadLine() ?? "1");
            Console.WriteLine("Field = ");
            student.Field = Console.ReadLine() ?? "";

            _studentRepository.Insert(student);
        }

        static void AddTeacher()
        {
            var teacher = new Teacher();
            Console.WriteLine("Name = ");
            teacher.Name = Console.ReadLine() ?? "";
            Console.WriteLine("Subject = ");
            teacher.Subject = Console.ReadLine() ?? "";

            _teacherRepository.Insert(teacher);
        }

        static void AddCourse()
        {
            var course = new Course();
            Console.WriteLine("Name = ");
            course.Name = Console.ReadLine() ?? "";
            Console.WriteLine("Duration = ");
            course.Duration = TimeSpan.Parse(Console.ReadLine() ?? "2:0:0");
            Console.WriteLine("Day of Week = ");
            course.DayOfWeek = Enum.Parse<DayOfWeek>(Console.ReadLine() ?? "Monday");
            Console.WriteLine("Teacher Id = ");
            var teacherId = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException());
            course.Teacher = _teacherRepository.Get(teacherId);

            bool isThereMoreStudentsToAdd;
            do
            {
                Console.WriteLine("Student Id = ");
                var studentId = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException());
                course.Students.Add(_studentRepository.Get(studentId));
                Console.WriteLine("Is there more students to add?");
                isThereMoreStudentsToAdd = bool.Parse(Console.ReadLine() ?? "False");
            } while (isThereMoreStudentsToAdd);

            _courceRepository.Insert(course);
        }

        static void GetStudents()
        {
            Console.WriteLine("List of students =>\n");
            _studentRepository.GetAll().ToList().ForEach(student =>
            {
                Console.WriteLine($"Name = {student.Name}, Age = {student.Age}, Field of Study = {student.Field}\n");
            });
        }

        static void GetTeachers()
        {
            Console.WriteLine("List of teachers =>\n");
            _teacherRepository.GetAll().ToList().ForEach(teacher =>
            {
                Console.WriteLine($"Name = {teacher.Name}, Subject = {teacher.Subject}");
            });
        }

        static void GetCourses()
        {
            Console.WriteLine("List of courses =>\n");
            _courceRepository.GetAll().ToList().ForEach(course =>
            {
                var info = new StringBuilder();
                info.Append($"Name = {course.Name}, Duration = {course.Duration}, Day of the week = {course.DayOfWeek}\n");
                info.Append($"Teacher info: Name = {course.Teacher.Name}, Subject = {course.Teacher.Subject}\n");
                info.Append("Students info:\n");
                course.Students.ToList().ForEach(student =>
                {
                    info.Append($"\t Name = {student.Name}, Age = {student.Age}, Field = {student.Field}\n");
                });

                Console.WriteLine(info);
            });
        }
    }
}