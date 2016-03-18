#region using

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo02;

#endregion

namespace PluralSight.Moq.Tests.Demo02
{
    // Demo: Simple Mock Verification

    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_multiple_customers
        {
            //Test whether the save method is called for every customer item created using the Moq TimesCalled function
            [TestMethod]
            public void the_customer_repository_should_be_called_once_per_customer()
            {
                //Arrange
                var listOfCustomerDtos = new List<CustomerToCreateDto>
                {
                    new CustomerToCreateDto
                    {
                        FirstName = "Sam", LastName = "Sampson"
                    },
                    new CustomerToCreateDto
                    {
                        FirstName = "Bob", LastName = "Builder"
                    },
                    new CustomerToCreateDto
                    {
                        FirstName = "Doug", LastName = "Digger"
                    }
                };

                var mockCustomerRepository = new Mock<ICustomerRepository>();
                
                var cusomterService = new CustomerService(mockCustomerRepository.Object);

                //Act
                cusomterService.Create(listOfCustomerDtos);

                //Assert
                mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()), Times.Exactly(listOfCustomerDtos.Count));

            }
        }
    }
}