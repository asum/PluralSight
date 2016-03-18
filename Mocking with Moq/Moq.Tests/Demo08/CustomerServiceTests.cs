#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo08;

#endregion

namespace PluralSight.Moq.Tests.Demo08
{
    // Demo: Exceptions

    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_customer_which_has_an_invalid_address
        {
            [TestMethod]
            [ExpectedException(typeof(CustomerCreationException))]
            public void an_exception_should_be_raised()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockCustomerAddressFactory = new Mock<ICustomerAddressFactory>();

                mockCustomerAddressFactory
                    .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
                    .Throws<InvalidCustomerAddressException>();

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockCustomerAddressFactory.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
            }
        }
    }
}