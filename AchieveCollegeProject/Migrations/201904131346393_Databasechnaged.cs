namespace AchieveCollegeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Databasechnaged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                {
                    ID = c.Int(nullable: false),
                    CourseName = c.String(maxLength: 50),
                    Credits = c.Int(nullable: false),
                    DepartmentID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);

            CreateTable(
                "dbo.Department",
                c => new
                {
                    DepartmentID = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 50),
                    Budget = c.Decimal(nullable: false, storeType: "money"),
                    StartDate = c.DateTime(nullable: false),
                    InstructorID = c.Int(),
                })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Instructor", t => t.InstructorID)
                .Index(t => t.InstructorID);

            CreateTable(
                "dbo.Instructor",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    LastName = c.String(maxLength: 50),
                    FirstName = c.String(maxLength: 50),
                    HireDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.OfficeAssignment",
                c => new
                {
                    InstructorID = c.Int(nullable: false),
                    Location = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.Instructor", t => t.InstructorID)
                .Index(t => t.InstructorID);

            CreateTable(
                "dbo.Enrollment",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    StudentID = c.Int(nullable: false),
                    CourseID = c.Int(nullable: false),
                    Grade = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);

            CreateTable(
                "dbo.Student",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 50),
                    EnrollmentDate = c.DateTime(nullable: false),
                    Email = c.String(),
                    Password = c.String(maxLength: 16),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.CourseInstructor",
                c => new
                {
                    CourseID = c.Int(nullable: false),
                    InstructorID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.CourseID, t.InstructorID })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Instructor", t => t.InstructorID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.InstructorID);


        }
        public override void Down()
        {
            DropForeignKey("dbo.CourseInstructor", "InstructorID", "dbo.Instructor");
            DropForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Course", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "InstructorID", "dbo.Instructor");
            DropForeignKey("dbo.OfficeAssignment", "InstructorID", "dbo.Instructor");
            DropIndex("dbo.CourseInstructor", new[] { "InstructorID" });
            DropIndex("dbo.CourseInstructor", new[] { "CourseID" });
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropIndex("dbo.Enrollment", new[] { "StudentID" });
            DropIndex("dbo.OfficeAssignment", new[] { "InstructorID" });
            DropIndex("dbo.Department", new[] { "InstructorID" });
            DropIndex("dbo.Course", new[] { "DepartmentID" });
            DropTable("dbo.CourseInstructor");
            DropTable("dbo.Student");
            DropTable("dbo.Enrollment");
            DropTable("dbo.OfficeAssignment");
            DropTable("dbo.Instructor");
            DropTable("dbo.Department");
            DropTable("dbo.Course");
        }
    }
}
