using System.Web.Mvc;

namespace SnowOwl.Controllers
{
    public class PortfolioController : Controller
    {
        public ActionResult Web()
        {
            return View();
        }

        public ActionResult Desktop()
        {
            return View();
        }

        public ActionResult Mobile()
        {
            return View();
        }
    }
}
