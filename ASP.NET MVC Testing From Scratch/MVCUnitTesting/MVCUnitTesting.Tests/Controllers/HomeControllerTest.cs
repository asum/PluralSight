#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCUnitTesting.Controllers;
using MVCUnitTesting.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

#endregion

namespace MVCUnitTesting.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void FindByGenreReturnsAllInGenre()
        {
            //Arrange
            var products = new List<Product>
            {
                new Product { ID = 1, Genre = "Fiction", Name = "Moby Dick", Price = 12.50m },
                new Product { ID = 2, Genre = "Fiction", Name = "War and Peace", Price = 17m },
                new Product { ID = 3, Genre = "Non-Fiction", Name = "Chemistry", Price = 35m }
            };

            var productRepository = new Mock<Repository>();
            productRepository
                .Setup(x => x.GetAllProducts())
                .Returns(products);

            // Act
            HomeController controller = new HomeController(productRepository.Object);
            ViewResult viewResult = controller.FindByGenre("Fiction");
            var model = viewResult.Model as IEnumerable<Product>;

            //Assert
            Assert.AreEqual(2, model.Count());
            Assert.AreEqual("Moby Dick", model.OrderBy(x => x.ID).ToList()[0].Name);
            Assert.AreEqual("War and Peace", model.OrderBy(x => x.ID).ToList()[1].Name);
        }

        [TestMethod]
        public void IndexReturnsAllProductsInDB()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { ID = 1, Genre = "Fiction", Name = "Moby Dick", Price = 12.50m },
                new Product { ID = 2, Genre = "Fiction", Name = "War and Peace", Price = 17m }
            };

            var productRepository = new Mock<Repository>();
            productRepository
                .Setup(x => x.GetAllProducts())
                .Returns(products);

            // Act
            HomeController controller = new HomeController(productRepository.Object);
            ViewResult viewResult = controller.Index();
            var model = viewResult.Model as IEnumerable<Product>;

            // Assert
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
