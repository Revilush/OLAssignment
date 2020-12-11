using OLAssignment.BizRepository;
using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLAssignment.Controllers
{
    public class StudentCourseController : Controller
    {
        IBizRepository<StudentCourse, int> scRepo;
        OLDbContext context;

        public StudentCourseController()
        {
            scRepo = new StudentCourseRepo();
            context = new OLDbContext();
        }

        // GET: StudentCourse
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Student")]
        public ActionResult CourseEnroll(int corid, int stuid)
        {
            StudentCourse cs = new StudentCourse();
            cs.CourseId = context.Courses.Where(e => e.CourseRowId == corid).FirstOrDefault();
            cs.StudentId = context.Students.Where(e => e.StudentRowId == stuid).FirstOrDefault();
            cs.Status = 0;
            context.StudentCourses.Add(cs);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetEnrolledCourse(string uid)
        {
            Student std = context.Students.Where(e => e.Id == uid).FirstOrDefault();

            List<StudentCourse> result = context.StudentCourses.Where(e => e.StudentId.StudentRowId == std.StudentRowId).ToList();
            return View(result);
        }


    }
}