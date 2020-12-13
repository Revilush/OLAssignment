using OLAssignment.BizRepository;
using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLAssignment.Controllers
{
    public class StudentController : Controller
    {
        IBizRepository<Student, int> studentRepo;
        OLDbContext context;

        public StudentController()
        {
            studentRepo = new StudentBizRepo();
            context = new OLDbContext();
        }
        // GET: Student
        public ActionResult Index()
        {
            var result = studentRepo.GetData();
            return View(result);
        }


        public ActionResult GotoStu(string uid)
        {
            //get Area of interests for dropdown
            //ViewBag.AOI = context.AreaOfInterests.ToList();

            var result = new Student();
            result.Id = uid;

            //generate Student Id
            if (context.Students.Count() > 0)
            {
                string studentId = context.Students.OrderByDescending(e => e.StudentId).First().StudentId;
                string[] temp = studentId.Split(':');
                temp[1] = (Convert.ToInt32(temp[1]) + 1).ToString("000");
                studentId = temp[0] + ':' + temp[1];
                result.StudentId = studentId;
            }
            else
            {
                result.StudentId = "S:001";
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult GotoStu(Student stud)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Create(stud);
                //ViewBag
                return RedirectToAction("Index", "Home");
            }
            return View(stud);
        }

        public ActionResult Create()
        {
            //populate dropdowns

            var result = new Student();
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(Student stud)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Create(stud);
                return RedirectToAction("Index");
            }
            return View(stud);
        }

        public ActionResult Edit(int id)
        {
            var result = studentRepo.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, Student stud)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Update(id, stud);
                return RedirectToAction("Index");
            }
            return View(stud);
        }

        public ActionResult Delete(int id)
        {
            var result = studentRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}