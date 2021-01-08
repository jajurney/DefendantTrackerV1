using DefendantTracker.Models.StateAttorneyModels;
using DefendantTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefendantTrackerV1.Controllers
{
    public class StateAttorneyController : Controller
    {
        // GET: StateAttorney
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new StateAttorneyService(userID);
            var model = service.GetStateAttorneys();
            return View(model);
        }
        // GET: Create
        // StateAttorney/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StateAttorneyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateStateAttorneyService();
            if (service.CreateStateAttorney(model))
            {
                TempData["SaveResult"] = "State Attorney was added";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "State Attorney was not added");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var sat = CreateStateAttorneyService();
            var model = sat.GetStateAttorneysById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateStateAttorneyService();
            var detail = service.GetStateAttorneysById(id);
            var model = new StateAttorneyEdit
            {
                FirstName = detail.FirstName,
                LastName = detail.LastName
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StateAttorneyEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateStateAttorneyService();
            if (service.UpdateStateAttorney(id, model))
            {
                TempData["SaveResult"] = "State Attorney Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "State Attorney not Updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var sat = CreateStateAttorneyService();
            var model = sat.GetStateAttorneysById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStateAttorney(int id)
        {
            var service = CreateStateAttorneyService();
            service.DeleteStateAttorney(id);
            TempData["SaveResult"] = "State Attorney was removed.";
            return RedirectToAction("Index");
        }
        private StateAttorneyService CreateStateAttorneyService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new StateAttorneyService(userID);
            return service;
        }
    }
}