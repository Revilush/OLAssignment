using OLAssignment.BizRepository;
using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLAssignment.Controllers
{
    public class ModuleController : Controller
    {
        IBizRepository<Course, int> corRepo;
        IBizRepository<Module, int> modRepo;
        OLDbContext context;

        public ModuleController()
        {
            corRepo = new CourseBizRepo();
            modRepo = new ModuleRepo();
            context = new OLDbContext();
        }

        // GET: Module
        public ActionResult Index()
        {
            var result = modRepo.GetData();
            //Read data from TEMPDATA passed from courses action "Show Modules for Course":
            if (TempData["CourseRowId"] != null)
            {
                int corid = Convert.ToInt32(TempData["CourseRowId"]);
                result = (from mod in modRepo.GetData() where Convert.ToInt32(mod.CourseRowId) == corid select mod).ToList();
                //TempData.Keep();
                ViewBag.Message = $"Course of row id:{corid} Contains {result.Count} modules ";
                if (result.Count == 0)
                {
                    ViewBag.Message = $"This Course of row id:{corid} has no modules ";
                }
            }
            else
            {
                result = modRepo.GetData();
                ViewBag.Message = "List of all modules ";
            }
            return View(result);
        }

        public ActionResult Create()
        {
            var result = new Module();
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(Module mod)
        {
            if (ModelState.IsValid)
            {
                modRepo.Create(mod);
                return RedirectToAction("Index");
            }
            return View(mod);
        }



    }
}