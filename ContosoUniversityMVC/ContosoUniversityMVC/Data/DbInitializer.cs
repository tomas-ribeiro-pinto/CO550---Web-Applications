using ContosoUniversityMVC.Models;
using System;
using System.Linq;

namespace ContosoUniversityMVC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstMidName="Tomas",LastName="Pinto",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Samuel",LastName="Baker",EnrollmentDate=DateTime.Parse("2022-10-08")},
            new Student{FirstMidName="Maarten",LastName="McGregor",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Milena",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-11")},
            new Student{FirstMidName="John",LastName="English",EnrollmentDate=DateTime.Parse("2002-12-01")},

            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=550,Title="Web Applications",Credits=3},
            new Course{CourseID=567,Title="OSD",Credits=3},
            new Course{CourseID=558,Title="Database Design",Credits=3},
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=550,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=567,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=558,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=550,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=567,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=558,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=550},
            new Enrollment{StudentID=3,CourseID=567},
            new Enrollment{StudentID=4,CourseID=550,Grade=Grade.F},
            new Enrollment{StudentID=4,CourseID=567,Grade=Grade.C},
            new Enrollment{StudentID=5,CourseID=550},
            new Enrollment{StudentID=5,CourseID=558,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
