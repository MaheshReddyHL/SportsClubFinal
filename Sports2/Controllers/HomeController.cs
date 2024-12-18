using System.Net.Mail;
using System.Net;
using System;
using System.Web.Mvc;

namespace Sports2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult SendMail()
        {
            return View();
;       }
        [HttpPost]
        public ActionResult SendMail(string Name, string Email, string Subject, string Message)
        {
            try
            {
                // Set up the email
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("your-email@domain.com"); // Sender email address
                mail.To.Add("334748@nttdata.com"); // Recipient email address
                mail.Subject = Subject;
                mail.Body = $"Message from: {Name} ({Email})\n\n{Message}";

                // SMTP settings
                SmtpClient smtpClient = new SmtpClient("smtp.domain.com"); // SMTP server address
                smtpClient.Port = 587; // Port (587 for TLS, 465 for SSL)
                smtpClient.Credentials = new NetworkCredential("your-email@domain.com", "your-email-password"); // Credentials
                smtpClient.EnableSsl = true; // Enable SSL

                // Send the email
                smtpClient.Send(mail);

                // Return success message or redirect to a "thank you" page
                ViewBag.Message = "Email sent successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }

            return View(); // Return to the view after sending the mail
        }
    }
}