using HospedagemMVC.Aplication;
using HospedagemMVC.Domain;
using HospedagemMVC.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class CustomerServiceTest
    {
        [TestMethod]
        public void CreateCustomerServiceValidationAndPersistenceTest()
        {
            //Arrange
            Customer customer = ObjectMother.GetCustomer();
            //Fake do repositório
            var repositoryFake = new Mock<ICustomerRepository>();
            repositoryFake.Setup(r => r.Save(customer)).Returns(customer);
            //Fake do dominio
            var customerFake = new Mock<Customer>();
            customerFake.As<IObjectValidation>().Setup(b => b.Validate());

            ICustomerService service = new CustomerService(repositoryFake.Object);

            //Action
            service.Create(customerFake.Object);

            //Assert
            customerFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Save(customerFake.Object));
        }

        [TestMethod]
        public void RetrieveCustomerServiceTest()
        {
            //Arrange
            Customer customer = ObjectMother.GetCustomer();
            //Fake do repositório
            var repositoryFake = new Mock<ICustomerRepository>();
            repositoryFake.Setup(r => r.Get(1)).Returns(customer);

            ICustomerService service = new CustomerService(repositoryFake.Object);

            //Action
            var customerFake = service.Retrieve(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));
            Assert.IsNotNull(customerFake);
        }

        [TestMethod]
        public void UpdateCustomerServiceValidationAndPersistenceTest()
        {
            //Arrange
            Customer customer = ObjectMother.GetCustomer();
            //Fake do repositório
            var repositoryFake = new Mock<ICustomerRepository>();
            repositoryFake.Setup(r => r.Update(customer)).Returns(customer);
            //Fake do dominio
            var customerFake = new Mock<Customer>();
            customerFake.As<IObjectValidation>().Setup(b => b.Validate());

            ICustomerService service = new CustomerService(repositoryFake.Object);

            //Action
            service.Update(customerFake.Object);

            //Assert
            customerFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Update(customerFake.Object));
        }

        [TestMethod]
        public void DeleteCustomerServiceTest()
        {
            //Arrange
            Customer customer = null;
            //Fake do repositório
            var repositoryFake = new Mock<ICustomerRepository>();
            repositoryFake.Setup(r => r.Delete(1)).Returns(customer);

            ICustomerService service = new CustomerService(repositoryFake.Object);

            //Action
            var customerFake = service.Delete(1);

            //Assert
            repositoryFake.Verify(r => r.Delete(1));
            Assert.IsNull(customerFake);
        }
    }
}