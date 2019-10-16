namespace AchieveCollegeProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AchieveCollegeProject.DAL;
    using AchieveCollegeProject.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<AchieveCollegeProject.DAL.AchieveContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AchieveCollegeProject.DAL.AchieveContext context)
        {

            var students = new List<Student>
            {
            new Student{FirstName="Sagrika",LastName="Aggarwal",Email="sagrika@achievemail.com",Password="12345678",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Joshua",LastName="Diaz",Email="josh@achievemail.com",Password="12345678",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Andrei",LastName="Draggos",Email="andrei@achievemail.com",Password="12345678",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Gurvinder",LastName="Saini",Email="gurvinder@achievemail.com",Password="12345678", EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Yianni",LastName="Li",Email="yianni@achievemail.com",Password="12345678",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Paul",LastName="Nyugen",Email="paul@achievemail.com",Password="12345678",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstName="Pooja",LastName="Nv",Email="pooja@achievemail.com",Password="12345678",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Aishwarya",LastName="Singh",Email="aish@achievemail.com",Password="12345678",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor { FirstName = "Ali",     LastName = "Hesson",
                    HireDate = DateTime.Parse("2017-03-11") },
                new Instructor { FirstName = "Adel",    LastName = "Muhhamad",
                    HireDate = DateTime.Parse("2018-07-06") },
                new Instructor { FirstName = "RavinderPal",   LastName = "Singh",
                    HireDate = DateTime.Parse("2006-07-01") },
                new Instructor { FirstName = "Nithaya", LastName = "Thayananthan",
                    HireDate = DateTime.Parse("2011-01-15") },
                new Instructor { FirstName = "Shahdad",   LastName = "Shriatmadari",
                    HireDate = DateTime.Parse("2007-02-12") }
            };
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "Information Technology Solutions",     Budget = 350000,
                    StartDate = DateTime.Parse("2005-09-01"),InstructorID  = instructors.Single( i => i.LastName == "Singh").ID },
                new Department { Name = "Information Technology Solutions", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),InstructorID  = instructors.Single( i => i.LastName == "Hesson").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),InstructorID  = instructors.Single( i => i.LastName == "Shriatmadari").ID },
                new Department { Name = "Engineering",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),InstructorID  = instructors.Single( i => i.LastName == "Thayananthan").ID }
            };

            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
            new Course{ID=1050,CourseName="Asp .NET Development using MVC",Credits=3,DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
                  Instructors = new List<Instructor>() },
            new Course{ID=4022,CourseName="Web Developement",Credits=3,DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
                  Instructors = new List<Instructor>() },
            new Course{ID=4041,CourseName="Android I",Credits=3,DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
                  Instructors = new List<Instructor>() },
            new Course{ID=1045,CourseName="Big Data I",Credits=4,DepartmentID = departments.Single( s => s.Name == "Information Technology Solutions").DepartmentID,
                  Instructors = new List<Instructor>() },
            new Course{ID=3141,CourseName="J2EE",Credits=4,DepartmentID = departments.Single( s => s.Name == "Information Technology Solutions").DepartmentID,
                  Instructors = new List<Instructor>() },
            new Course{ID=2021,CourseName="Data Analysis & Design Patterns",Credits=3,DepartmentID = departments.Single( s => s.Name == "Information Technology Solutions").DepartmentID,
                  Instructors = new List<Instructor>() },
            new Course{ID=2042,CourseName="Career Connections",Credits=4,DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
                  Instructors = new List<Instructor>() }
            };

            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseName, s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Singh").ID,
                    Location = "North L" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Shariatmadari").ID,
                    Location = "Lakeshore 12" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Hesson").ID,
                    Location = "North EX" },
            };
            officeAssignments.ForEach(s => context.OfficeAssignments.AddOrUpdate(p => p.InstructorID, s));
            context.SaveChanges();

            AddOrUpdateInstructor(context, "Asp .NET Development using MVC", "Hesson");
            AddOrUpdateInstructor(context, "J2EE", "Singh");
            AddOrUpdateInstructor(context, "Web Developement", "Shariatmadari");
            AddOrUpdateInstructor(context, "Web Development", "Muhhamad");

            AddOrUpdateInstructor(context, "Android I", "Thayananthan");
            AddOrUpdateInstructor(context, "J2EE", "Shariatmadari");
            AddOrUpdateInstructor(context, "Data Analysis & Design Patterns", "Singh");
            AddOrUpdateInstructor(context, "Career Connections", "Muhhamad");

            context.SaveChanges();


            var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Aggarwal").ID,
                    CourseID = courses.Single(c => c.CourseName == "Android I" ).ID,

                },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Aggarwal").ID,
                    CourseID = courses.Single(c => c.CourseName == "Big Data I" ).ID,

                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Aggarwal").ID,
                    CourseID = courses.Single(c => c.CourseName == "Asp .NET Development using MVC" ).ID,

                 },
                 new Enrollment {
                     StudentID = students.Single(s => s.LastName == "Diaz").ID,
                    CourseID = courses.Single(c => c.CourseName == "Data Analysis & Design Patterns" ).ID,

                 },
                 new Enrollment {
                     StudentID = students.Single(s => s.LastName == "Diaz").ID,
                    CourseID = courses.Single(c => c.CourseName == "Career Connections" ).ID,

                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Diaz").ID,
                    CourseID = courses.Single(c => c.CourseName == "J2EE" ).ID,

                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Draggos").ID,
                    CourseID = courses.Single(c => c.CourseName == "Asp .NET Development using MVC" ).ID
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Draggos").ID,
                    CourseID = courses.Single(c => c.CourseName == "Microeconomics").ID,

                 },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Singh").ID,
                    CourseID = courses.Single(c => c.CourseName == "J2EE").ID,

                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Singh").ID,
                    CourseID = courses.Single(c => c.CourseName == "Asp .NET Development using MVC").ID,

                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Nyugen").ID,
                    CourseID = courses.Single(c => c.CourseName == "J2EE").ID,

                 }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Student.ID == e.StudentID &&
                         s.Course.ID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();


        }

        void AddOrUpdateInstructor(AchieveContext context, string courseTitle, string instructorName)
        {
            var crs = context.Courses.SingleOrDefault(c => c.CourseName == courseTitle);
            var inst = crs.Instructors.SingleOrDefault(i => i.LastName == instructorName);
            if (inst == null)
                crs.Instructors.Add(context.Instructors.Single(i => i.LastName == instructorName));
        }
    }
}
