using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sports2.Models;
namespace Sports2.Controllers
{
    public class TimeSlotRequests1Controller : Controller
    {
        private readonly FinalcaseEntities1 db = new FinalcaseEntities1();

        // GET: TimeSlotRequests1
        public ActionResult Index()
        {
            var timeSlotRequests = db.TimeSlotRequests.Include(t => t.TimeSlot).Include(t => t.User);
            return View(timeSlotRequests.ToList());
        }

        // GET: TimeSlotRequests1/Details/5
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

    }
}