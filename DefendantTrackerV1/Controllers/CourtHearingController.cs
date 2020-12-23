using DefendantTracker.Models.CourtHearingModels;
using DefendantTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefendantTrackerV1.Controllers
{
    public class CourtHearingController : Controller
    {
        // GET: CourtHearing
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CourtHearingService(userID);
            var model = service.GetCourtHearings();
            return View(model);
        }
        // GET: Create
        // CourtHearing/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourtHearingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCourtHearingService();
            if (service.CreateCourtHearing(model))
            {
                TempData["SaveResult"] = "CourtHearing was add to Defendant";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "CourtHearing was not added");
            return View(model);
        }
        // CourtHearing/Details/{id}
        public ActionResult Details(int id)
        {
            var con = CreateCourtHearingService();
            var model = con.GetCourtHearingById(id);
            return View(model);
        }
        // CourtHearing/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateCourtHearingService();
            var detail = service.GetCourtHearingById(id);
            var model = new CourtHearingEdit
            {
                HearingDesc = detail.HearingDesc,
                CourtDate = detail.CourtDate,
                CourtAddress = detail.CourtAddress,
                CourtCity = detail.CourtCity,
                CourtCounty = detail.CourtCounty,
                CourtState = detail.CourtState,
                CourtZipcode = detail.CourtZipcode
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourtHearingEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateCourtHearingService();
            if (service.UpdateCourtHearing(id, model))
            {
                TempData["SaveResult"] = "CourtHearing Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "CourtHearing not Updated");
            return View(model);
        }
        // CourtHearing/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var cor = CreateCourtHearingService();
            var model = cor.GetCourtHearingById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourtHearing(int id)
        {
            var service = CreateCourtHearingService();
            service.DeleteCourtHearing(id);
            TempData["SaveResult"] = "CourtHearing was removed.";
            return RedirectToAction("Index");
        }
        private CourtHearingService CreateCourtHearingService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CourtHearingService(userID);
            return service;
        }
    }
}