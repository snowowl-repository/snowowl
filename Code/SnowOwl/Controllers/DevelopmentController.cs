using System.Web.Mvc;

namespace SnowOwl.Controllers
{
    public class DevelopmentController : Controller
    {
        public ActionResult Desktop()
        {
            return View();
        }

        public ActionResult Web()
        {
            return View();
        }

        public ActionResult Mobile()
        {
            return View();
        }
    }
}
