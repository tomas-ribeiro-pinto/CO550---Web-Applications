using ContosoUniversityRazor.Models;

namespace ContosoUniversityRazor.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstMidName="Tomas",LastName="Pinto",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Student{FirstMidName="John",LastName="Kennedy",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Lia",LastName="Rose",EnrollmentDate=DateTime.Parse("2018-09-01")},
            };

            var instructors = new Instructor[]
            {
                new Instructor{FirstMidName = "Derek",LastName = "Peacock", HireDate = DateTime.Parse("1995-03-11")},
                new Instructor{FirstMidName = "Nick",LastName = "Day", HireDate = DateTime.Parse("2002-07-06")},
                new Instructor{FirstMidName = "Mike",LastName = "Everett", HireDate = DateTime.Parse("1998-07-01")},
            };


            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    Instructor = instructors[0],
                    Location = "Smith 17" },
                new OfficeAssignment {
                    Instructor = instructors[1],
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    Instructor = instructors[2],
                    Location = "Thompson 304" },
            };

            context.AddRange(officeAssignments);

            var computing = new Department
            {
                Name = "Computing",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = instructors[0]
            };

            var web = new Department
            {
                Name = "Web Development",
                Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = instructors[1]
            };

            var engineering = new Department
            {
                Name = "Database Engineering",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = instructors[2]
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=1,Title="Web Applications", Department = web, Instructors = new List<Instructor> { instructors[0], instructors[1] }, Credits=3},
                new Course{CourseID=2,Title="Database Design", Department = engineering, Instructors = new List<Instructor> { instructors[2] },Credits=3},
                new Course{CourseID=3,Title="Network Systems", Department = computing, Instructors = new List<Instructor> { instructors[0], instructors[2] },Credits=3},
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=2,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=3,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=1,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=2,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=3,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=3},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}