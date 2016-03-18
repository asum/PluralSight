#region using

using MVCUnitTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

#endregion

namespace MVCUnitTesting.Controllers
{
    public class HomeController : Controller
    {
        private Repository repository;

        public HomeController(Repository repository)
        {
            this.repository = repository;
        }

        public HomeController()
        {
            this.repository = new WorkingProductRepository();
        }

        public ViewResult Index()
        {
            var products = repository.GetAllProducts();
            return View(products);
        }

        public ViewResult FindByGenre(string genre)
        {
            var products = repository.GetAllProducts();
            List<Product> results = products.Where(x => x.Genre == genre).ToList();
            return View(results);
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
    }
}