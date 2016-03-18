#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo09;

#endregion

namespace PluralSight.Moq.Tests.Demo09
{
    // Demo: Mocking Property Setters
    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_customer
        {
            [TestMethod]
            public void the_local_timezone_should_be_set()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();

                var customerService = new CustomerService(
                    mockCustomerRepository.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockCustomerRepository.VerifySet(x => x.LocalTimeZone = It.IsAny<string>());

            }
        }
    }
}