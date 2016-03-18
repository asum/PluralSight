#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSight.Moq.Code.Demo15;

#endregion

namespace PluralSight.Moq.Tests.Demo15
{
    // Demo: Base Class Implementations
    public class CustomerNameFormatterTests
    {
        [TestClass]
        public class When_formatting_a_customers_name
        {
            [TestMethod]
            public void bad_words_should_be_stripped_from_the_first_and_last_names()
            {
                //Arrange
                var mockNameFormatter = new Mock<CustomerNameFormatter>();

                //Act
                mockNameFormatter.Object.From(new Customer("Bob", "SAPBuilder"));

                //Assert
                mockNameFormatter.Verify(x => x.ParseBadWordsFrom(It.IsAny<string>()), Times.Exactly(2));
            }
        }
    }
}