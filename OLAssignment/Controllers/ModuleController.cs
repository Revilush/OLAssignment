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

            //Read data from TEMPDATA passed from category action "Show Modules for Course":
            if (TempData["CourseRowId"] != null)
            {
                int catid = Convert.ToInt32(TempData["CategoryRowId"]);

                result = (from prd in modRepo.GetData() where Convert.ToInt32(prd.CourseRowId) == catid select prd).ToList();
                //TempData.Keep();

                ViewBag.Message = $"Category of row id:{catid} Contains {result.Count} products ";

                if (result.Count == 0)
                {
                    ViewBag.Message = $"This Category of row id:{catid} has no products ";
                }
            }
            else
            {
                result = modRepo.GetData();
                ViewBag.Message = "List of all products ";
            }

            return View(result);
        }
    }
}