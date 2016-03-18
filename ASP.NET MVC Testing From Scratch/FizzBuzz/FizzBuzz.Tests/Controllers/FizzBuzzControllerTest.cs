#region using

using FizzBuzz.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

#endregion

namespace FizzBuzz.Tests.Controllers
{
    [TestClass]
    public class FizzBuzzControllerTest
    {
        [TestMethod]
        public void Given1Return1()
        {
            // Arrange
            FizzBuzzController controller = new FizzBuzzController();

            // Act
            ViewResult result = controller.Index(1) as ViewResult;

            // Assert
            string expected = "1 ";
            string actual = result.ViewBag.Output;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given3Return12Fizz()
        {
            // Arrange
            FizzBuzzController controller = new FizzBuzzController();

            // Act
            ViewResult result = controller.Index(3) as ViewResult;

            // Assert
            string expected = "1 2 Fizz ";
            string actual = result.ViewBag.Output;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given5Return12Fizz4Buzz()
        {
            // Arrange
            FizzBuzzController controller = new FizzBuzzController();

            // Act
            ViewResult result = controller.Index(5) as ViewResult;

            // Assert
            string expected = "1 2 Fizz 4 Buzz ";
            string actual = result.ViewBag.Output;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given15ReturnFizzBuzz()
        {
            // Arrange
            FizzBuzzController controller = new FizzBuzzController();

            // Act
            ViewResult result = controller.Index(15) as ViewResult;

            // Assert
            string expected = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz ";
            string actual = result.ViewBag.Output;
            Assert.AreEqual(expected, actual);
        }
    }
}
