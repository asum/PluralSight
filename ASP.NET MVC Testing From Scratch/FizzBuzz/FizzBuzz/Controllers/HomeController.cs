#region using

using System.Web.Mvc;

#endregion

namespace FizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}