using Sports2.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Sports2.Controllers
{
    public class MembershipChargesController : Controller
    {
        private readonly FinalcaseEntities1 db = new FinalcaseEntities1();

        // GET: MembershipCharges
        public ActionResult Index()
        {
            return View(db.MembershipCharges.ToList());
        }

        // GET: MembershipCharges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipCharge membershipCharge = db.MembershipCharges.Find(id);
            if (membershipCharge == null)
            {
                return HttpNotFound();
            }
            return View(membershipCharge);
        }

        // GET: MembershipCharges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembershipCharges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MembershipChargeId,MembershipType,Amount")] MembershipCharge membershipCharge)
        {
            if (ModelState.IsValid)
            {
                db.MembershipCharges.Add(membershipCharge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membershipCharge);
        }

        // GET: MembershipCharges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipCharge membershipCharge = db.MembershipCharges.Find(id);
            if (membershipCharge == null)
            {
                return HttpNotFound();
            }
            return View(membershipCharge);
        }

        // POST: MembershipCharges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MembershipChargeId,MembershipType,Amount")] MembershipCharge membershipCharge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membershipCharge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membershipCharge);
        }

        // GET: MembershipCharges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipCharge membershipCharge = db.MembershipCharges.Find(id);
            if (membershipCharge == null)
            {
                return HttpNotFound();
            }
            return View(membershipCharge);
        }

        // POST: MembershipCharges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                MembershipCharge membershipCharge = db.MembershipCharges.Find(id);
                db.MembershipCharges.Remove(membershipCharge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = (ex.Message);
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
