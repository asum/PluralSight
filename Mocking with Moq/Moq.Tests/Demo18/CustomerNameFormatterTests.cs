#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using PluralSight.Moq.Code.Demo18;

#endregion

namespace PluralSight.Moq.Tests.Demo18
{
    // Demo: Protective Members
    public class CustomerNameFormatterTests
    {
        [TestClass]
        public class When_formatting_a_customers_name
        {
            [TestMethod]
            public void all_bad_words_should_be_scrubbed()
            {
                //Arrange
                var mockCustomerNameFormatter = new Mock<CustomerNameFormatter>();

                mockCustomerNameFormatter.Protected().Setup<string>("ParseBadWordsFrom", ItExpr.IsAny<string>()).Returns("abcdef").Verifiable();

                //Act
                mockCustomerNameFormatter.Object.From(new Customer());

                //Assert
                mockCustomerNameFormatter.Verify();
            }
        }
    }
}