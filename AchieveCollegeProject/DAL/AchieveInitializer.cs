using AchieveCollegeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AchieveCollegeProject.DAL
{
    public class AchieveInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<AchieveContext>

    {
        protected override void Seed(AchieveContext context)
        {
            var students = new List<Student>
            {
            new Student{FirstName="Sagrika",LastName="Aggarwal",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Joshua",LastName="Diaz",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Andrei",LastName="Draggos",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Gurvinder",LastName="Singh", EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Yianni",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Paul",LastName="Nyugen",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstName="Pooja",LastName="Nv",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Aishwarya",LastName="Singh",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
            new Course{ID=1050,CourseName="Asp .NET Development using MVC",Credits=3,},
            new Course{ID=4022,CourseName="Web Developement",Credits=3,},
            new Course{ID=4041,CourseName="Android I",Credits=3,},
            new Course{ID=1045,CourseName="Big Data I",Credits=4,},
            new Course{ID=3141,CourseName="J2EE",Credits=4,},
            new Course{ID=2021,CourseName="Data Analysis & Design Patterns",Credits=3,},
            new Course{ID=2042,CourseName="Career Connections",Credits=4,}
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050,},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}
