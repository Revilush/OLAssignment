using OLAssignment.BizRepository;
using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLAssignment.Controllers
{
    public class CourseController : Controller
    {
        IBizRepository<Course, int> corRepo;
        OLDbContext context;

        public CourseController(IBizRepository<Course, int> corRepository)
        {
            this.corRepo = corRepository;
            context = new OLDbContext();
        }

        // GET: Course  
        public ActionResult Index()
        {
            var result = corRepo.GetData();
            return View();
        }
        public ActionResult GetCourses(string user_id)
        {
            var result = corRepo.GetData();
            result = result.Where(e => e.CTrainer.Id == user_id).ToList();
            return View(result);
        }

        public ActionResult ShowModulesForCOurses(int id)
        {
            TempData["CourseRowId"] = id;
            return RedirectToAction("Index", "Module");
        }

        public ActionResult AddCourse(string user_id)
        {
            var t_trainer = context.Trainers.Where(e => e.Id == user_id).FirstOrDefault();
            var result = new Course();
            result.CTrainer = t_trainer;
            //generate Course Id
            if (context.Courses.Count() > 0)
            {
                string c_id = context.Courses.OrderByDescending(e => e.CourseId).First().CourseId;
                string[] temp = c_id.Split(':');
                temp[1] = (Convert.ToInt32(temp[1]) + 1).ToString("000");
                c_id = temp[0] + ':' + temp[1];
                result.CourseId = c_id;
            }
            else
            {
                result.CourseId = "C:001";
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