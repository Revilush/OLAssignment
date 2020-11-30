namespace OLAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseRowId = c.Int(nullable: false, identity: true),
                        CourseId = c.String(),
                        CourseName = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        NoFMod = c.Int(nullable: false),
                        CStatus = c.Boolean(nullable: false),
                        Price = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        CTrainer_TrainerRowId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseRowId)
                .ForeignKey("dbo.Trainers", t => t.CTrainer_TrainerRowId)
                .Index(t => t.CTrainer_TrainerRowId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerRowId = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(nullable: false, maxLength: 50),
                        TrainerName = c.String(nullable: false, maxLength: 200),
                        Exp = c.String(nullable: false, maxLength: 300),
                        Id = c.String(),
                    })
                .PrimaryKey(t => t.TrainerRowId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        MId = c.Int(nullable: false),
                        MName = c.Int(nullable: false),
                        MContent = c.Int(nullable: false),
                        CourseRowId_CourseRowId = c.Int(),
                    })
                .PrimaryKey(t => t.ModuleId)
                .ForeignKey("dbo.Courses", t => t.CourseRowId_CourseRowId)
                .Index(t => t.CourseRowId_CourseRowId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        CourseId_CourseRowId = c.Int(),
                        StudentId_StudentRowId = c.Int(),
                    })
                .PrimaryKey(t => t.RowId)
                .ForeignKey("dbo.Courses", t => t.CourseId_CourseRowId)
                .ForeignKey("dbo.Students", t => t.StudentId_StudentRowId)
                .Index(t => t.CourseId_CourseRowId)
                .Index(t => t.StudentId_StudentRowId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentRowId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(nullable: false, maxLength: 50),
                        StudentName = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        MobNo = c.String(nullable: false, maxLength: 10),
                        Interest = c.String(nullable: false, maxLength: 50),
                        Id = c.String(),
                    })
                .PrimaryKey(t => t.StudentRowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "StudentId_StudentRowId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseId_CourseRowId", "dbo.Courses");
            DropForeignKey("dbo.Modules", "CourseRowId_CourseRowId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CTrainer_TrainerRowId", "dbo.Trainers");
            DropIndex("dbo.StudentCourses", new[] { "StudentId_StudentRowId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId_CourseRowId" });
            DropIndex("dbo.Modules", new[] { "CourseRowId_CourseRowId" });
            DropIndex("dbo.Courses", new[] { "CTrainer_TrainerRowId" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Modules");
            DropTable("dbo.Trainers");
            DropTable("dbo.Courses");
        }
    }
}
