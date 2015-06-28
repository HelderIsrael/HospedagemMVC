using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HospedagemMVC.Test
{
    [TestClass]
    public class CustomerDomainTest
    {
        [TestMethod]
        public void CreateACustomerTest()
        {
            Customer customer = ObjectMother.GetCustomer();

            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void CreateAValidCustomerTest()
        {
            Customer customer = ObjectMother.GetCustomer();

            Validator.Validate(customer);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidCustomerNameTest()
        {
            Customer customer = new Customer();

            Validator.Validate(customer);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidCustomerAuthorTest()
        {
            Customer customer = new Customer();
            customer.Name = "Helder";

            Validator.Validate(customer);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidCustomerUrlTest()
        {
            Customer customer = new Customer();
            customer.Name = "Helder";
            customer.City = "Urubici";
            customer.eMail = "helder@htomail.com";

            Validator.Validate(customer);
        }
    }




}

