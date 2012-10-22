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
            //TODO: need move strings to resource files and wrap result to object
            var isSended = false;
            if (!ModelState.IsValid) return Content("{\"isSuccess\": false,\"message\": \"Your request has not been sent.Please, try again...\"}");
            
            try { isSended = Mailer.SendContactUsMail(model); }
            catch { if (!ModelState.IsValid) return Content("{\"isSuccess\": false,\"message\": \"Your request has not been sent.Please, try again...\"}"); }
            
            string result = isSended
                                   ? "Your request has been successfully sent. Our manager contact you as soon as possible."
                                   : "Your request hasn't been sent. Please, try again...";

            return Content(string.Format("{{\"isSuccess\": {0}, \"message\": \"{1}\"}}", isSended.ToString().ToLower(), result));
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
