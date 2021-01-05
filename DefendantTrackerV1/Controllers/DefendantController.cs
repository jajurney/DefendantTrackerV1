using DefendantTracker.Models.DefendantModels;
using DefendantTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefendantTrackerV1.Controllers
{
    [Authorize]
    public class DefendantController : Controller
    {
        // GET: Defendant
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new DefendantService(userID);
            var model = service.GetDefendants();
            return View(model);
        }
        // GET: Create
        // Defendant/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DefendantCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDefendantService();
            if (service.CreateDefendant(model))
            {
                TempData["SaveResult"] = "Defendant was Created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Defendant was not Created");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var dft = CreateDefendantService();
            var model = dft.GetDefendantById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateDefendantService();
            var detail = service.GetDefendantById(id);
            var model = new DefendantEdit
            {
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                StreetAddress = detail.StreetAddress,
                City = detail.City,
                County = detail.County,
                State = detail.State,
                Zipcode = detail.Zipcode,
                Prosecuted = detail.Prosecuted,
                Arrested = detail.Arrested,
                //CourtHearingID = detail.CourtHearingID,
                //ConvictionID = detail.ConvictionID
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DefendantEdit model)
        {
            if (!ModelState.IsValid) return View(model);

           
            var service = CreateDefendantService();
            if (service.UpdateDefendant(id, model))
            {
                TempData["SaveResult"] = "Defendant Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Defendant not Updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var dft = CreateDefendantService();
            var model = dft.GetDefendantById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDefendant(int id)
        {
            var service = CreateDefendantService();
            service.DeleteDefendant(id);
            TempData["SaveResult"] = "Defedant was removed.";
            return RedirectToAction("Index");
        }
        private DefendantService CreateDefendantService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new DefendantService(userID);
            return service;
        }
    }
}