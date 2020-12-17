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
            var defendantID = Guid.Parse(User.Identity.GetUserId());
            var service = new DefendantService(defendantID);
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
        public ActionResult Details(Guid id)
        {
            var dft = CreateDefendantService();
            var model = dft.GetDefendantById(id);
            return View(model);
        }
        public ActionResult Edit(Guid id)
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
                Arrested = detail.Arrested,
                Prosecuted = detail.Prosecuted,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, DefendantEdit model)
        {
            if (!ModelState.IsValid) return View(model);

           
            var service = CreateDefendantService();
            if (service.UpdateDefendant(model))
            {
                TempData["SaveResult"] = "Defendant Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Defendant not Updated");
            return View(model);
        }
        private DefendantService CreateDefendantService()
        {
            var defendantID = Guid.Parse(User.Identity.GetUserId());
            var service = new DefendantService(defendantID);
            return service;
        }
    }
}