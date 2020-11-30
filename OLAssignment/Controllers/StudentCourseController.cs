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
        public ActionResult EnrollCourse(int course_id, int student_id)
        {
            //prepare object for making an entry in database
            StudentCourse cs = new StudentCourse();
            cs.CourseId = context.Courses.Where(e => e.CourseRowId == course_id).FirstOrDefault();
            cs.StudentId = context.Students.Where(e => e.StudentRowId == student_id).FirstOrDefault();
            cs.Status = 0;
            //create row in database
            //studentCourseRepo.create(cs);
            context.StudentCourses.Add(cs);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetEnrolledCourse(string user_id)
        {
            //get Student from user_id
            Student std = context.Students.Where(e => e.Id == user_id).FirstOrDefault();

            //get courses enrolled by user
            List<StudentCourse> result = context.StudentCourses.Where(e => e.StudentId.StudentRowId == std.StudentRowId).ToList();
            return View(result);
        }


    }
}