﻿#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo11;

#endregion

namespace PluralSight.Moq.Tests.Demo11
{
    // Demo: Mocking Property Hierachies
    public class CustomerServiceTests
    {
        [TestClass]
        public class When_creating_a_customer
        {
            [TestMethod]
            public void the_workstationid_should_be_retrieved()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockApplicationSettings = new Mock<IApplicationSettings>();

                mockApplicationSettings
                    .Setup(x => x.SystemConfiguration.AuditingInformation.WorkstationId)
                    .Returns(123);
                
                var customerService = new CustomerService(mockCustomerRepository.Object, mockApplicationSettings.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockApplicationSettings.VerifyGet(
                    x => x.SystemConfiguration.AuditingInformation.WorkstationId);
            }
        }
    }
}