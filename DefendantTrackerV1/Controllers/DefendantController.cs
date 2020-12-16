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
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var defendantID = Guid.Parse(User.Identity.GetUserId());
            var service = new DefendantService(defendantID);
            service.CreateDefendant(model);
            return RedirectToAction("Index");
        }
    }
}