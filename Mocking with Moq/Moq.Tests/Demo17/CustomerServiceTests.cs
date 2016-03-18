#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo17;

#endregion

namespace PluralSight.Moq.Tests.Demo17
{
    // Demo: Centralizing Mock Creation
    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_new_customer
        {
            [TestMethod]
            public void the_address_should_be_formatted()
            {
                //Arrange
                var mockFactory = new MockRepository(MockBehavior.Loose) 
                                {DefaultValue = DefaultValue.Mock};
                var mockCustomerRepository = mockFactory.Create<ICustomerRepository>();
                var mockCustomerAddressFormatter = mockFactory.Create<ICustomerAddressFormatter>();

                mockCustomerAddressFormatter
                    .Setup(x => x.For(It.IsAny<CustomerToCreateDto>()))
                    .Returns(new Address());

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockCustomerAddressFormatter.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockFactory.Verify();
            }
        }
    }
}