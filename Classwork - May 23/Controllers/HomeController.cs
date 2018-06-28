using Classwork___May_23.Data;
using Classwork___May_23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Classwork___May_23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCandidate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCandidate(Candidate candidate)
        {
            var cRepo = new CandidatesRepository(Properties.Settings.Default.Constr);
            cRepo.AddCandidate(candidate);
            return RedirectToAction("Index");
        }

        public ActionResult Pending()
        {
            var cRepo = new CandidatesRepository(Properties.Settings.Default.Constr);
            return View(cRepo.GetCandidates(Status.Pending));
        }

        public ActionResult Confirmed()
        {
            var cRepo = new CandidatesRepository(Properties.Settings.Default.Constr);
            return View(cRepo.GetCandidates(Status.Confirmed));
        }

        public ActionResult Refused()
        {
            var cRepo = new CandidatesRepository(Properties.Settings.Default.Constr);
            return View(cRepo.GetCandidates(Status.Refused));
        }

        public ActionResult Details(int id)
        {
            var cRepo = new CandidatesRepository(Properties.Settings.Default.Constr);
            return View(cRepo.GetCandidateById(id));
        }

        [HttpPost]
        public void UpdateStatus(int id, Status status)
        {
            var cRepo = new CandidatesRepository(Properties.Settings.Default.Constr);
            cRepo.UpdateStatus(id, status);
        }

        public ActionResult GetCounts()
        {
            var cRepo = new CandidatesRepository(Properties.Settings.Default.Constr);
            var counts = new Counts
            {
                Pending = cRepo.GetCount(Status.Pending),
                Confirmed = cRepo.GetCount(Status.Confirmed),
                Refused = cRepo.GetCount(Status.Refused)
            };
            return Json(counts, JsonRequestBehavior.AllowGet);
        }
    }
}