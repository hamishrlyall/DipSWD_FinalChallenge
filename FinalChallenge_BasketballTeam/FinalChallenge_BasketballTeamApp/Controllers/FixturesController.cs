using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalChallenge_BasketballTeamApp.Models;

namespace FinalChallenge_BasketballTeamApp.Controllers
{
    [Authorize]
    public class FixturesController : Controller
    {
        private FinalChallenge_BasketballTeamDBEntities db = new FinalChallenge_BasketballTeamDBEntities();

        // GET: Fixtures
        public ActionResult Index()
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;

            var fixtures = db.Fixtures.Include(f => f.Manager);
            return View(fixtures.ToList());
        }
        // GET: Upcoming Fixtures
        public ActionResult upcomingfixtures()
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;

            var fixtures = db.Fixtures.Include(f => f.Manager);
            return View(fixtures.Where(F => F.fixtureDateTime > DateTime.Now).ToList());
        }

        //GET: Past Fixtures
        public ActionResult pastfixtures()
        {
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manage.FindById(User.Identity.GetUserId());
            ViewBag.Confirmed = currentUser.EmailConfirmed;

            var fixtures = db.Fixtures.Include(f => f.Manager);
            return View(fixtures.Where(F => F.fixtureDateTime < DateTime.Now).ToList());
        }

        // GET: Fixtures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = db.Fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // GET: Fixtures/Create
        public ActionResult Create()
        {
            ViewBag.managerID = new SelectList(db.Managers, "managerID", "Name");
            return View();
        }

        // POST: Fixtures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fixtureID,managerID,Team,teamManager,fixtureDateTime,Venue,Spent")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Fixtures.Add(fixture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.managerID = new SelectList(db.Managers, "managerID", "Name", fixture.managerID);
            return View(fixture);
        }

        // GET: Fixtures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = db.Fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            ViewBag.managerID = new SelectList(db.Managers, "managerID", "Name", fixture.managerID);
            return View(fixture);
        }

        // POST: Fixtures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fixtureID,managerID,Team,teamManager,fixtureDateTime,Venue,Spent")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managerID = new SelectList(db.Managers, "managerID", "Name", fixture.managerID);
            return View(fixture);
        }

        // GET: Fixtures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = db.Fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // POST: Fixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fixture fixture = db.Fixtures.Find(id);
            db.Fixtures.Remove(fixture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
