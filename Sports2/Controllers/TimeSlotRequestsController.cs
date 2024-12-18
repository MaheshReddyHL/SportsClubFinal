using Sports2.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Sports2.Controllers
{
    public class TimeSlotRequestsController : Controller
    {
        private readonly FinalcaseEntities1 db = new FinalcaseEntities1();

        // GET: TimeSlotRequests
        public ActionResult Index()
        {
            try
            {

                var user = db.TimeSlotRequests.ToList();

                var customer = Session["UserId"].ToString();
                user = user.Where(u => u.UserId.ToString() == customer).ToList();
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
      /*      var timeSlotRequests = db.TimeSlotRequests.Include(t => t.TimeSlot).Include(t => t.User);
            return View(timeSlotRequests.ToList());*/
        }

        // GET: TimeSlotRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlotRequest timeSlotRequest = db.TimeSlotRequests.Find(id);
            if (timeSlotRequest == null)
            {
                return HttpNotFound();
            }
            return View(timeSlotRequest);
        }

        // GET: TimeSlotRequests/Create
        public ActionResult Create()
        {
            ViewBag.TimeSlotId = new SelectList(db.TimeSlots, "TimeSlotId", "TimeSlotId");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FullName");
            return View();
        }

        // POST: TimeSlotRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,UserId,TimeSlotId,RequestDate,IsApproved")] TimeSlotRequest timeSlotRequest)
        {
            if (ModelState.IsValid)
            {
                db.TimeSlotRequests.Add(timeSlotRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeSlotId = new SelectList(db.TimeSlots, "TimeSlotId", "TimeSlotId", timeSlotRequest.TimeSlotId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FullName", timeSlotRequest.UserId);
            return View(timeSlotRequest);
        }

        // GET: TimeSlotRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlotRequest timeSlotRequest = db.TimeSlotRequests.Find(id);
            
            
            if (timeSlotRequest == null)
            {
                return HttpNotFound();
            }

            ViewBag.TimeSlotId = new SelectList(db.TimeSlots, "TimeSlotId", "TimeSlotId", timeSlotRequest.TimeSlotId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserId", timeSlotRequest.UserId);
            return View(timeSlotRequest);
        }

        // POST: TimeSlotRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,UserId,TimeSlotId,RequestDate,IsApproved")] TimeSlotRequest timeSlotRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeSlotRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TimeSlotId = new SelectList(db.TimeSlots, "TimeSlotId", "TimeSlotId", timeSlotRequest.TimeSlotId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserId", timeSlotRequest.UserId);
            return View(timeSlotRequest);
        }

        // GET: TimeSlotRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlotRequest timeSlotRequest = db.TimeSlotRequests.Find(id);
            if (timeSlotRequest == null)
            {
                return HttpNotFound();
            }
            return View(timeSlotRequest);
        }

        // POST: TimeSlotRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSlotRequest timeSlotRequest = db.TimeSlotRequests.Find(id);
            db.TimeSlotRequests.Remove(timeSlotRequest);
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
