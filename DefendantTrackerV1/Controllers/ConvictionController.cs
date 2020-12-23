using DefendantTracker.Models.ConvictionModels;
using DefendantTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefendantTrackerV1.Controllers
{
    public class ConvictionController : Controller
    {
        // GET: Conviction
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ConvictionService(userID);
            var model = service.GetConvictions();
            return View(model);
        }
        // GET: Create
        // Conviction/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConvictionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateConvictionService();
            if (service.CreateConviction(model))
            {
                TempData["SaveResult"] = "Conviction was add to Defendant";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Conviction was not added");
            return View(model);
        }
        // Conviction/Details/{id}
        public ActionResult Details(int id)
        {
            var con = CreateConvictionService();
            var model = con.GetConvictionById(id);
            return View(model);
        }
        // Conviction/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateConvictionService();
            var detail = service.GetConvictionById(id);
            var model = new ConvictionEdit
            {
                ConvicID = detail.ConvicID,
                StreetAddress = detail.StreetAddress,
                City = detail.City,
                County = detail.County,
                State = detail.State,
                Zipcode = detail.Zipcode,
                DateOfConviction = DateTime.Now,
                ConvictionSeverity = detail.ConvictionSeverity
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConvictionEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateConvictionService();
            if (service.UpdateConviction(id, model))
            {
                TempData["SaveResult"] = "Conviction Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Conviction not Updated");
            return View(model);
        }
        // Conviction/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var con = CreateConvictionService();
            var model = con.GetConvictionById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConviction(int id)
        {
            var service = CreateConvictionService();
            service.DeleteConviction(id);
            TempData["SaveResult"] = "Conviction was removed.";
            return RedirectToAction("Index");
        }
        private ConvictionService CreateConvictionService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ConvictionService(userID);
            return service;
        }
    }
} 