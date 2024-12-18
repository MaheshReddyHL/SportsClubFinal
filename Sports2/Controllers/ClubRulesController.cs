using Sports2.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Sports2.Controllers
{
    public class ClubRulesController : Controller
    {
        private readonly FinalcaseEntities1 db = new FinalcaseEntities1();

        // GET: ClubRules
        public ActionResult Index()
        {
            return View(db.ClubRules.ToList());
        }

        // GET: ClubRules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubRule clubRule = db.ClubRules.Find(id);
            if (clubRule == null)
            {
                return HttpNotFound();
            }
            return View(clubRule);
        }

        // GET: ClubRules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClubRules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RuleId,Description")] ClubRule clubRule)
        {
            if (ModelState.IsValid)
            {
                db.ClubRules.Add(clubRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clubRule);
        }

        // GET: ClubRules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubRule clubRule = db.ClubRules.Find(id);
            if (clubRule == null)
            {
                return HttpNotFound();
            }
            return View(clubRule);
        }

        // POST: ClubRules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RuleId,Description")] ClubRule clubRule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubRule);
        }

        // GET: ClubRules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubRule clubRule = db.ClubRules.Find(id);
            if (clubRule == null)
            {
                return HttpNotFound();
            }
            return View(clubRule);
        }

        // POST: ClubRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {

                ClubRule clubRule = db.ClubRules.Find(id);
                db.ClubRules.Remove(clubRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
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
