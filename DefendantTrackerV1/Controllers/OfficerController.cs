using DefendantTracker.Models.OfficerModels;
using DefendantTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefendantTrackerV1.Controllers
{
    public class OfficerController : Controller
    {
        // GET: Officer
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new OfficerService(userID);
            var model = service.GetOfficers();
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
        public ActionResult Create(OfficerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateOfficerService();
            if (service.CreateOfficer(model))
            {
                TempData["SaveResult"] = "Officer was Created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Officer was not Created");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var off = CreateOfficerService();
            var model = off.GetOfficerById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateOfficerService();
            var detail = service.GetOfficerById(id);
            var model = new OfficerEdit
            {
                BadgeID = detail.BadgeID,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                DepartmentCity = detail.DepartmentCity,
                DepartmentCounty = detail.DepartmentCounty,
                DepartmentState = detail.DepartmentState,
                DepartmentZipcode = detail.DepartmentZipcode,
                DepartmentName = detail.DepartmentName
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OfficerEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateOfficerService();
            if (service.UpdateOfficer(id, model))
            {
                TempData["SaveResult"] = "Officer Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Officer not Updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var off = CreateOfficerService();
            var model = off.GetOfficerById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOfficer(int id)
        {
            var service = CreateOfficerService();
            service.DeleteOfficer(id);
            TempData["SaveResult"] = "Officer was removed.";
            return RedirectToAction("Index");
        }
        private OfficerService CreateOfficerService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new OfficerService(userID);
            return service;
        }
    }
}