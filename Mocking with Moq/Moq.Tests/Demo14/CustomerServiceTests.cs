#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo14;
using System.Collections.Generic;

#endregion

namespace PluralSight.Moq.Tests.Demo14
{
    // Demo: Strict
    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_customer
        {
            [TestMethod]
            public void the_customer_should_be_saved()
            {
                //Arrange
                var mockCustomerRepository = 
                    new Mock<ICustomerRepository>(MockBehavior.Strict);

                mockCustomerRepository
                    .Setup(x => x.Save(It.IsAny<Customer>()));

                mockCustomerRepository
                    .Setup(x => x.FetchAll())
                    .Returns(() => new List<Customer>());

                var customerService = new CustomerService(
                    mockCustomerRepository.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockCustomerRepository.Verify();
            }
        }
    }
}