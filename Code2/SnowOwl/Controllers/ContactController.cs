using System.Web.Mvc;
using SnowOwl.Models;

namespace SnowOwl.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            return View();
        }
    }
}
