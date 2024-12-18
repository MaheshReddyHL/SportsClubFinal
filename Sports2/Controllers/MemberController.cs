using Sports2.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Sports2.Controllers
{
    public class MemberController : Controller
    {

        private readonly FinalcaseEntities1 db = new FinalcaseEntities1();

        // GET: Member Dashboard
        public ActionResult MemberDashboard()
        {
            return View();
        }
        // GET: View Available Slots

        public ActionResult MemberTimeSlotIndex()
        {
            return View(db.TimeSlots.ToList());
        }

        public ActionResult MemberTimeslotDetails(int? id)
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

        public ActionResult ViewRulesIndex()
        {
            return View(db.ClubRules.ToList());
        }

        // GET: ClubRules/Details/5
        public ActionResult ViewRulesDetails(int? id)
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
    }
}

