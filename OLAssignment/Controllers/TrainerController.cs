using OLAssignment.BizRepository;
using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLAssignment.Controllers
{
    public class TrainerController : Controller
    {
        IBizRepository<Trainer, int> trainRepo;
        OLDbContext context;

        public TrainerController()
        {
            trainRepo = new TrainerBizRepo();
            context = new OLDbContext();
        }

        // GET: Trainer
        public ActionResult Index()
        {
            var result = trainRepo.GetData();
            return View(result);
        }

        public ActionResult GotoTr(string uid)
        {
            //get Area of interests for dropdown
            //ViewBag.AOI = context.AreaOfInterests.ToList();

            var result = new Trainer();
            result.Id = uid;


            //generate Trainer Id
            if (context.Trainers.Count() > 0)
            {
                string trainId = context.Trainers.OrderByDescending(e => e.TrainerId).First().TrainerId;
                string[] temp = trainId.Split(':');
                temp[1] = (Convert.ToInt32(temp[1]) + 1).ToString("000");
                trainId = temp[0] + ':' + temp[1];
                result.TrainerId = trainId;
            }
            else
            {
                result.TrainerId = "T:001";
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult GotoTr(Trainer train)
        {
            if (ModelState.IsValid)
            {
                trainRepo.Create(train);
                return RedirectToAction("Index", "Home");
            }
            return View(train);

        }

        public ActionResult Create(string uid)
        {
            //ViewBag.dob = "StudentDOB";
            var result = new Trainer();
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(Trainer train)
        {
            if (ModelState.IsValid)
            {
                trainRepo.Create(train);
                return RedirectToAction("Index");
            }
            return View(train);
        }

        public ActionResult Edit(int id)
        {
            var result = trainRepo.GetData(id);
            return View(result);
        }

        public ActionResult Edit(int id, Trainer train)
        {
            if (ModelState.IsValid)
            {
                trainRepo.Update(id, train);
                return RedirectToAction("Index");
            }
            return View(train);
        }

        public ActionResult Delete(int id)
        {
            var result = trainRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}