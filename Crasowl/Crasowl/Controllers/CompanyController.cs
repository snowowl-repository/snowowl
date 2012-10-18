using System.Web.Mvc;
using Crasowl.Code;
using Crasowl.Models;
using System;

namespace Crasowl.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ExtendedContact()
        {
            TempData["SendContactUsMailResult"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            if (!ModelState.IsValid)
                return Content("Your request hasn't been sent.Please, try again...");
            bool isSended = Mailer.SendContactUsMail(model);

            string result = isSended
                                ? "Your request has been successfully sent. Our manager contact you as soon as possible."
                                : "Your request hasn't been sent.Please, try again...";
            return Content(result);
        }

        [HttpPost]
        public ActionResult ExtendedContact(ContactModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            bool isSended = Mailer.SendContactUsMail(model);
            TempData["SendContactUsMailResult"] = isSended
                                ? "Your request has been successfully sent. Our manager contact you as soon as possible."
                                : "Your request has not been sent.Please, try again...";
            return isSended ? View(model) : View();
        }

        public ActionResult Carrers()
        {
            return View();
        }
    }
}
