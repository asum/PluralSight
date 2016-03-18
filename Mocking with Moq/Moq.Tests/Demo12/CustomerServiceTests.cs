#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo12;

#endregion

namespace PluralSight.Moq.Tests.Demo12
{
    // Demo: Stubbing Properties
    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_customer
        {
            [TestMethod]
            public void the_workstation_id_should_be_retrieved()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockApplicationSettings = new Mock<IApplicationSettings>();

                mockApplicationSettings.SetupAllProperties();
                mockApplicationSettings.Object.WorkstationId = 23456;
                mockApplicationSettings.Object.RevisionNumber = "ABC";
                mockApplicationSettings.Object.SaveDirectory = "fdss";

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockApplicationSettings.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockApplicationSettings.VerifyGet(x=>x.WorkstationId);
            }
        }
    }
}