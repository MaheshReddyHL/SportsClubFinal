using Sports2.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Sports2.Controllers
{
    public class AccountController : Controller
    {

        private readonly FinalcaseEntities1 db = new FinalcaseEntities1();
        public ActionResult MainIndex() { return View(); }

        // Login Action
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if the admin exists in the database
                    var existingAdmin = db.Admins.FirstOrDefault(a => a.EmailId == admin.EmailId && a.Password == admin.Password);

                    if (existingAdmin != null)
                    {
                        Session["email"] = admin.EmailId;

                        // Successfully logged in, redirect to Admin dashboard
                         ViewBag.ErrorMessage=("Login SuccessFul");
                        //Response.Write("Login failed");

                        return RedirectToAction("AdminDashboard", "Admin");
                    }
                    else
                    {
                        // If the credentials are incorrect
                        ViewBag.ErrorMessage = "Invalid email or password";

                        return View(admin);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage(ex.Message);
            }
            // If the model state is not valid, return to the login view
            return View(admin);
        }

        //userlogin
        public ActionResult UserLogin() => View();
        [HttpPost]
        public ActionResult UserLogin(string email, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = db.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
                    if (user != null)
                    {
                        Session["UserId"] = user.UserId;
                        Session["UserMail"] = user.Email;
                        return RedirectToAction("MemberDashboard", "Member");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Invalid login credentials";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage(ex.Message);
            }
            return View();
        }

        // Register Action
        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if email already exists
                    var isEmailExist = db.Users.Any(x => x.Email == user.Email);
                    if (isEmailExist)
                    {
                        ModelState.AddModelError("Email", "Email already exists. Please use a different email/Login.");
                        return View(user);
                    }

                    // Proceed with registration logic if email doesn't
                    if (user != null)
                    {
                        var users = new User
                        {

                            Email = user.Email,
                            Password = user.Password
                        };

                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    // Redirect to some success page or login page
                    return RedirectToAction("UserLogin");
                }
                else
                {
                    if (user == null)
                    {
                        ViewBag.ErrorMessage = "Invalid Details";
                        return View(user);
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage(ex.Message);
            }
            return View(user);

        }
    }
}
