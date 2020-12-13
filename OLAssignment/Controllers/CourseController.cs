using OLAssignment.BizRepository;
using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace OLAssignment.Controllers
{
    public class CourseController : Controller
    {
        IBizRepository<Course, int> corRepo;
        IBizRepository<Trainer, int> trnRepo;
        IBizRepository<Student, int> sturepo;
        OLDbContext context;

        public CourseController()
        {
            sturepo = new StudentBizRepo();
            corRepo = new CourseBizRepo();
            context = new OLDbContext();
        }

        // GET: Course  
        
        public ActionResult Index()
        {
            var result = corRepo.GetData();
            var studentidtmp = sturepo.GetData();
            var studidtmp = studentidtmp.Where(s => s.Id == User.Identity.GetUserId()).FirstOrDefault().Id.ToString();
            ViewBag.Studid = studidtmp;
            return View(result);
        }

        public ActionResult SCourses(string query)
        {
            var result = corRepo.GetData();
            result = result.Where(e => e.CourseName == query).ToList();
            return View(result);
        }

        public ActionResult GetCourses(string uid)
        {
            var result = corRepo.GetData();
            result = result.Where(e => e.CTrainer.Id == uid).ToList();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            TempData["CourseRowId"] = id;
            
            return RedirectToAction("Index", "Module");
        }

        public ActionResult AddCourse(string uid)
        {
            var tmp = context.Trainers.Where(e => e.Id == uid).FirstOrDefault();
            var result = new Course();
            result.CTrainer = tmp;
            //result.CTrainer = context.Trainers.Where(e => e.Id == uid).FirstOrDefault();
            //result.CTrainer = (Trainer)TempData["Trainer"];
            if (context.Courses.Count() > 0)
            {
                string cid = context.Courses.OrderByDescending(e => e.CourseId).First().CourseId;
                string[] temp = cid.Split(':');
                temp[1] = (Convert.ToInt32(temp[1]) + 1).ToString("00");
                cid = temp[0] + ':' + temp[1];
                result.CourseId = cid;
            }
            else
            {
                result.CourseId = "C:1";
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult AddCourse(Course cor)
        {
            if (ModelState.IsValid)
            {
                corRepo.Create(cor);
                return RedirectToAction("Index", "Home");
            }
            return View(cor);
        }


        public ActionResult Create()
        {
            var result = new Course();
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(Course cor)
        {
            if (ModelState.IsValid)
            {
                corRepo.Create(cor);
                return RedirectToAction("Index");
            }
            return View(cor);
        }

        public ActionResult Edit(int id)
        {
            var result = corRepo.GetData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, Course cor)
        {
            if (ModelState.IsValid)
            {
                corRepo.Update(id, cor);
                return RedirectToAction("Index");
            }
            return View(cor);
        }

        public ActionResult Delete(int id)
        {
            var result = corRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}