using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HospedagemMVC.Infra;
using HospedagemMVC.Domain;

namespace Test
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
        public void CreateAInvalidCustomerPhoneTest()
        {
            Customer customer = new Customer();
            customer.Name = "Helder";

            Validator.Validate(customer);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidCustomerEmailTest()
        {
            Customer customer = new Customer();
            customer.Name = "Helder";
            customer.Phone = "4999332297";
            customer.Email = "teste";

            Validator.Validate(customer);
        }

    }




}