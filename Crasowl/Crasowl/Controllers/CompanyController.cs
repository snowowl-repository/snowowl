using System.Web.Mvc;
using Crasowl.Models;

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
            //TODO: place to send mail
            return View();
        }

        public ActionResult Carrers()
        {
            return View();
        }
    }
}
