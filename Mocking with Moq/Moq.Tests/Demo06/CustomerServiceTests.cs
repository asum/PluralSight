#region using

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo06;

#endregion

namespace PluralSight.Moq.Tests.Demo06
{
    // Demo: Argument Tracking
    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_customer
        {
            //verify that specific parameter values are passed to the mock object
            [TestMethod]
            public void a_full_name_should_be_created_from_first_and_last_name()
            {
                //Arrange
                var customerToCreateDto = new CustomerToCreateDto
                                              {
                                                  FirstName = "Bob", 
                                                  LastName = "Builder"
                                              };

                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockFullNameBuilder = new Mock<ICustomerFullNameBuilder>();

                mockFullNameBuilder
                    .Setup(x => x.From(It.IsAny<string>(), It.IsAny<string>()));

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, mockFullNameBuilder.Object);

                //Act
                customerService.Create(customerToCreateDto);

                //Assert
                mockFullNameBuilder.Verify(
                    x =>
                        x.From(
                            It.Is<string>(
                                y =>
                                    y.Equals(customerToCreateDto.FirstName, StringComparison.InvariantCultureIgnoreCase)),
                            It.Is<string>(
                                y =>
                                    y.Equals(customerToCreateDto.LastName, StringComparison.InvariantCultureIgnoreCase))));

            }
        }
    }
}