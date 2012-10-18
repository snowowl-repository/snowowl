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

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            bool isSended = Mailer.SendContactUsMail(model);

            string result = isSended
                                ? "Your request has been successfully sent. Our manager contact you as soon as possible."
                                : "Your request hasn't been sent.Please, try again...";
            return Content(result);
        }

        public ActionResult Carrers()
        {
            return View();
        }
    }
}
