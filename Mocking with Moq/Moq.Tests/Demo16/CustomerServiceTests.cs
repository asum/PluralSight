#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo16;

#endregion

namespace PluralSight.Moq.Tests.Demo16
{
    // Demo: Recursive Mocking
    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_customer
        {
            [TestMethod]
            public void the_address_should_be_formatted()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockAddressFormatterFactory = 
                    new Mock<IAddressFormatterFactory> 
                        {DefaultValue = DefaultValue.Mock}; // Tells Moq to moq return values instead of using default values

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockAddressFormatterFactory.Object);

                var addressFormatter = mockAddressFormatterFactory.Object.From(It.IsAny<string>()); // Gets a mocked IAddressFormatterFactory 

                var mock = Mock.Get(addressFormatter); // Gets the moq of the mocked IAddressFormatterFactory so we can us it in the Assert

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mock.Verify(x => x.From(It.IsAny<CustomerToCreateDto>()));
            }
        }
    }
}