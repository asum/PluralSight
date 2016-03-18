#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo07;

#endregion

namespace PluralSight.Moq.Tests.Demo07
{
    // Demo: Arguements and Execution Flow
    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_platinum_status_customer
        {
            [TestMethod]
            public void a_special_save_routine_should_be_used()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockCustomerStatusFactory = new Mock<ICustomerStatusFactory>();

                var customerToCreate = new CustomerToCreateDto
                                           {
                                               DesiredStatus = CustomerStatus.Platinum, 
                                               FirstName = "Bob", 
                                               LastName = "Builder"
                                           };

                mockCustomerStatusFactory
                    .Setup(x => x.CreateFrom(It.Is<CustomerToCreateDto>(y => y.DesiredStatus == CustomerStatus.Platinum)))
                    .Returns(CustomerStatus.Platinum);

                mockCustomerStatusFactory
                    .Setup(x => x.CreateFrom(It.Is<CustomerToCreateDto>(y => y.DesiredStatus == CustomerStatus.Bronze)))
                    .Returns(CustomerStatus.Bronze);

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, mockCustomerStatusFactory.Object);

                //Act
                customerService.Create(customerToCreate);

                //Assert
                mockCustomerRepository.Verify(
                    x=>x.SaveSpecial(It.IsAny<Customer>()));
            }
        }
    }
}