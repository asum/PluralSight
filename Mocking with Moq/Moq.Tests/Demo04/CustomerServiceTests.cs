#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo04;

#endregion

namespace PluralSight.Moq.Tests.Demo04
{
    // Demo: Out Parameters

    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_customer
        {
            [TestMethod]
            public void the_customer_should_be_persisted()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockMailingAddressFactory = new Mock<IMailingAddressFactory>();

                var mailingAddress = new MailingAddress
                {
                    Country = "UK"
                };

                mockMailingAddressFactory
                    .Setup(x => x.TryParse(It.IsAny<string>(), out mailingAddress))
                    .Returns(() => true);

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, mockMailingAddressFactory.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockCustomerRepository.Verify(x=>x.Save(It.IsAny<Customer>()));
            }
        }
    }
}