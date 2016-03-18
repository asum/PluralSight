#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo01;

#endregion

namespace PluralSight.Moq.Tests.Demo01
{
    // Demo: AAA Syntax

    public class CustomerServiceTests
    {

        [TestClass]
        public class When_creating_a_customer
        {
            //Test whether the all methods are called on create using the Moq VerifyAll function
            [TestMethod]
            public void the_repository_save_should_be_called()
            {
                // Arrange
                var mockRepository = new Mock<ICustomerRepository>();

                mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));

                var customerService = new CustomerService(mockRepository.Object);

                // Act
                customerService.Create(new CustomerToCreateDto());

                // Assert
                mockRepository.VerifyAll();
            }
        }
    }
}
