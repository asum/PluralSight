#region using

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo05;

#endregion

namespace PluralSight.Moq.Tests.Demo05
{
    // Demo: Multiple Return Values
    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_customer
        {
            [TestMethod]
            public void each_customer_should_be_assigned_an_id()
            {
                //Arrange
                var listOfCustomersToCreate = new List<CustomerToCreateDto>
                                                  {
                                                      new CustomerToCreateDto(),
                                                      new CustomerToCreateDto()
                                                  };

                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockIdFactory = new Mock<IIdFactory>();

                var i = 1;
                mockIdFactory
                    .Setup(x => x.Create()).Returns(() => i).Callback(() => i++);

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, mockIdFactory.Object);

                //Act
                customerService.Create(listOfCustomersToCreate);

                //Assert
                mockIdFactory.Verify(x => x.Create(), Times.Exactly(listOfCustomersToCreate.Count));
            }
        }
    }
}