using Sports2.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Sports2.Controllers
{
    public class AdminController : Controller
    {
        private readonly FinalcaseEntities1 db = new FinalcaseEntities1();

        // GET: Dashboard
        public ActionResult AdminDashboard()
        {
            return View();
        }
        public ActionResult TimeSlotIndex()
        {
            return View(db.TimeSlots.ToList());
        }

        public ActionResult TimeslotDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlot timeSlot = db.TimeSlots.Find(id);
            if (timeSlot == null)
            {
                return HttpNotFound();
            }
            return View(timeSlot);
        }
    }
}

