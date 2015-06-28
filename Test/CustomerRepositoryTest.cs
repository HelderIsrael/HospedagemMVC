using FluentAssertions;
using HospedagemMVC.Domain;
using HospedagemMVC.Infra.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;


namespace Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private CustomerContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseAlways<CustomerContext>());
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new CustomerContext();

            var customer = ObjectMother.GetCustomer();

            _contextForTest.Customers.Add(customer);

            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateCustomerRepositoryTest()
        {
            //Arrange
            Customer b = ObjectMother.GetCustomer();
            ICustomerRepository repository = new CustomerRepository();

            //Action
            Customer newCustomer = repository.Save(b);

            //Assert
            Assert.IsTrue(newCustomer.Id > 0);
            Assert.IsTrue(newCustomer.Accommodations[0].Id > 0);
        }

        [TestMethod]
        public void RetrieveCustomerRepositoryTest()
        {
            //Arrange
            ICustomerRepository repository = new CustomerRepository();

            //Action
            Customer customer = repository.Get(1);

            //Assert
            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(customer.Name));
            Assert.IsFalse(string.IsNullOrEmpty(customer.Phone));
            Assert.IsFalse(string.IsNullOrEmpty(customer.Email));

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            //customer.Should().NotBeNull();
            //customer.ShouldBeEquivalentTo(ObjectMother.GetCustomer(), options => options.Excluding(b => b.Id));
        }

        [TestMethod]
        public void UpdateCustomerRepositoryTest()
        {
            //Arrange
            ICustomerRepository repository = new CustomerRepository();
            Customer customer = _contextForTest.Customers.Find(2);
            customer.Name = "Helder";
            customer.Phone = "4999332297";
            customer.Email = "helder_israel@hotmail.com";

            //Action
            var updatedCustomer = repository.Update(customer);

            //Assert
            var persistedCustomer = _contextForTest.Customers.Find(2);
            Assert.IsNotNull(updatedCustomer);
            Assert.AreEqual(updatedCustomer.Id, persistedCustomer.Id);
            Assert.AreEqual(updatedCustomer.Name, persistedCustomer.Name);
            Assert.AreEqual(updatedCustomer.Phone, persistedCustomer.Phone);
            Assert.AreEqual(updatedCustomer.Email, persistedCustomer.Email);

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            // updatedCustomer.Should().NotBeNull();
            //updatedCustomer.ShouldBeEquivalentTo(persistedCustomer);
        }

        [TestMethod]
        public void DeleteCustomerRepositoryTest()
        {
            //Arrange
            ICustomerRepository repository = new CustomerRepository();
            
            //Action
            var deletedCustomer = repository.Delete(1);

            //Assert
            var persistedCustomer = _contextForTest.Customers.Find(1);
            Assert.IsNull(persistedCustomer);

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            persistedCustomer.Should().BeNull();
        }

        [TestMethod]
        public void RetrieveCustomerByNameRepositoryTest()
        {
            //Arrange
            ICustomerRepository repository = new CustomerRepository();

            //Action
            var customers = repository.GetByName("Helder Rocha Israel");

            //Assert
            Assert.IsNotNull(customers);
            Assert.AreEqual(1, customers.Count);
        }

        [TestMethod]
        public void RetrieveAllCustomersRepositoryTest()
        {
            //Arrange
            ICustomerRepository repository = new CustomerRepository();

            //Action
            var customers = repository.GetAll();

            //Assert
            Assert.IsNotNull(customers);
            Assert.AreEqual(1, customers.Count);
        }
    }




}