#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo13;

#endregion

namespace PluralSight.Moq.Tests.Demo13
{
    // Demo: Mocking Events
    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_new_customer
        {
            [TestMethod]
            public void an_email_should_be_sent_to_the_sales_team()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockMailingRepository = new Mock<IMailingRepository>();

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, mockMailingRepository.Object);

                //Act
                mockCustomerRepository.Raise(x => x.NotifySalesTeam += null, "Jim", false);

                //Assert
                mockMailingRepository.Verify(x => x.NewCustomerMessage("Jim"));
            }
        }
    }
}