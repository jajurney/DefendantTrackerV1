using DefendantTracker.Models.ArrestModels;
using DefendantTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefendantTrackerV1.Controllers
{
    public class ArrestController : Controller
    {
        // GET: Arrest
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ArrestService(userID);
            var model = service.GetArrests();
            return View(model);
        }
        // GET: Create
        // Arrest/Create

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArrestCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateArrestService();
            if (service.CreateArrest(model))
            {
                TempData["SaveResult"] = "Arrest was added";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Arrest was not added");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var arr = CreateArrestService();
            var model = arr.GetArrestById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateArrestService();
            var detail = service.GetArrestById(id);
            var model = new ArrestEdit
            {
                ArrestDate = detail.ArrestDate,
                StreetName = detail.StreetName,
                ArrestCity = detail.ArrestCity,
                ArrestCounty = detail.ArrestCounty,
                ArrestState = detail.ArrestState,
                ArrestZipcode = detail.ArrestZipcode,
                ArrestDesc = detail.ArrestDesc,
                DefendantID = detail.DefendantID,
                OfficerID = detail.OfficerID
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArrestEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateArrestService();
            if (service.UpdateArrest(id, model))
            {
                TempData["SaveResult"] = "Arrest Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Arrest not Updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var arr = CreateArrestService();
            var model = arr.GetArrestById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteArrest(int id)
        {
            var service = CreateArrestService();
            service.DeleteArrest(id);
            TempData["SaveResult"] = "Arrest was removed.";
            return RedirectToAction("Index");
        }
        private ArrestService CreateArrestService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ArrestService(userID);
            return service;
        }
    }
}