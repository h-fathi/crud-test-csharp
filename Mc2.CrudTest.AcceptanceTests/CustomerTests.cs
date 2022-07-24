using Mc2.CrudTest.AcceptanceTests.SeedWork;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Customers.Events;
using Mc2.CrudTest.Domain.Customers.Rules;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Mc2.CrudTest.AcceptanceTests
{
    [TestFixture]
    public class CustomerTests : TestBase
    {

        // Please create more tests based on project requirements as per in readme.md

        [Test]
        public void GivenCustomerEmailIsUnique_WhenCustomerIsRegistering_IsSuccessful()
        {
            // Arrange
            var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            const string fName = "hossein";
            const string lName = "fathi";
            const string email = "testEmail@email.com";
            DateTime bDate = DateTime.Now.AddYears(-32).Date;
            customerUniquenessChecker.CustomerEmailMustBeUnique(email).Returns(true);
            customerUniquenessChecker.CustomerFirstLastNameAndBirthOfDateMustBeUnique(fName, lName, bDate).Returns(true);
            // Act
            var customer = Customer.CreateRegistered(fName, lName, bDate, "+989124165597", email, "987654321987676", customerUniquenessChecker);

            // Assert
            AssertPublishedDomainEvent<CustomerRegisteredEvent>(customer);
        }

        [Test]
        public void GivenCustomerEmailIsNotUnique_WhenCustomerIsRegistering_BreaksCustomerEmailMustBeUniqueRule()
        {
            // Arrange
            var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            const string fName = "hossein";
            const string lName = "fathi";
            const string email = "testEmail@email.com";
            DateTime bDate = DateTime.Now.AddYears(-32).Date;
            customerUniquenessChecker.CustomerEmailMustBeUnique(email).Returns(false);
            customerUniquenessChecker.CustomerFirstLastNameAndBirthOfDateMustBeUnique(fName, lName, bDate).Returns(true);

            // Assert
            AssertBrokenRule<CustomerEmailUniqueValidatiorRule>(() =>
            {
                // Act
                Customer.CreateRegistered(fName, lName, bDate, "+989124165597", email, "987654321987676", customerUniquenessChecker);
            });
        }

        [Test]
        public void GivenCustomerEmailIsNotUnique_WhenCustomerIsRegistering_BreaksCustomerPhoneNumberMustBeUniqueRule()
        {
            // Arrange
            var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            const string fName = "hossein";
            const string lName = "fathi";
            const string email = "testEmail@email.com";
            DateTime bDate = DateTime.Now.AddYears(-32).Date;
            customerUniquenessChecker.CustomerEmailMustBeUnique(email).Returns(true);
            customerUniquenessChecker.CustomerFirstLastNameAndBirthOfDateMustBeUnique(fName, lName, bDate).Returns(true);

            // Assert
            AssertBrokenRule<CustomerPhoneNumberValidatiorRule>(() =>
            {
                // Act
                Customer.CreateRegistered(fName, lName, bDate, "09124165597", email, "987654321987676", customerUniquenessChecker);
            });
        }
    }
}
