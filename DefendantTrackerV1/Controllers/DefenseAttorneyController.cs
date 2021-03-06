﻿using DefendantTracker.Models.DefenseAttorneyModels;
using DefendantTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefendantTrackerV1.Controllers
{
    public class DefenseAttorneyController : Controller
    {
        // GET: DefenseAttorney
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new DefenseAttorneyService(userID);
            var model = service.GetDefenseAttorneys();
            return View(model);
        }
        // GET: Create
        // DefenseAttorney/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DefenseAttorneyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDefenseAttorneyService();
            if (service.CreateDefenseAttorney (model))
            {
                TempData["SaveResult"] = "Defense Attorney was added";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Defense Attorney was not added");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var dfa = CreateDefenseAttorneyService();
            var model = dfa.GetDefenseAttorneysById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateDefenseAttorneyService();
            var detail = service.GetDefenseAttorneysById(id);
            var model = new DefenseAttorneyEdit
            {
                FirstName = detail.FirstName,
                LastName = detail.LastName
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DefenseAttorneyEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateDefenseAttorneyService();
            if (service.UpdateDefenseAttorney(id, model))
            {
                TempData["SaveResult"] = "Defense Attorney Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Defense Attorney not Updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var dfa = CreateDefenseAttorneyService();
            var model = dfa.GetDefenseAttorneysById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDefenseAttorney(int id)
        {
            var service = CreateDefenseAttorneyService();
            service.DeleteDefenseAttorney(id);
            TempData["SaveResult"] = "Defense Attorney was removed.";
            return RedirectToAction("Index");
        }
        private DefenseAttorneyService CreateDefenseAttorneyService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new DefenseAttorneyService(userID);
            return service;
        }
    }
}