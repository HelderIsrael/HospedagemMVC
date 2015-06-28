using HospedagemMVC.Domain;
using HospedagemMVC.Infra.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class AccommodationRepositoryTest
    {
        private CustomerContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseAlways<CustomerContext>());
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new CustomerContext();
            var accommodation = ObjectMother.GetAccommodation();
            _contextForTest.Accommodations.Add(accommodation);
            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateAccommodationRepositoryTest()
        {
            //Arrange
            Accommodation p = ObjectMother.GetAccommodation();
            IAccommodationRepository repository = new AccommodationRepository();

            //Action
            Accommodation newAccommodation = repository.Save(p);

            //Assert
            Assert.IsTrue(newAccommodation.Id > 0);
        }

        [TestMethod]
        public void RetrieveAccommodationRepositoryTest()
        {
            //Arrange
            IAccommodationRepository repository = new AccommodationRepository();

            //Action
            Accommodation accommodation = repository.Get(2);

            //Assert
            Assert.IsNotNull(accommodation);
            Assert.IsTrue(accommodation.Id > 0);

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            //blog.Should().NotBeNull();
            //blog.ShouldBeEquivalentTo(ObjectMother.GetBlog(), options => options.Excluding(b => b.Id));
        }

        [TestMethod]
        public void UpdateAccommodationRepositoryTest()
        {
            //Arrange
            IAccommodationRepository repository = new AccommodationRepository();
            ICustomerRepository _repository = new CustomerRepository();

            Customer customer = _repository.Get(2);
            customer.Name = "Helder Rocha Israel";
            customer.Phone = "4999332297";
            customer.Email = "helder_israel@hotmail.com";
            customer.City = "Urubici";

            Accommodation accommodation = repository.Get(2);
            accommodation.DateChekIn = DateTime.Now;
            accommodation.DateCheckOut = DateTime.Now.AddDays(2);
            accommodation.AmountPeopleAdult = 2;
            accommodation.ValueAdult = 130;
            accommodation.AmountPeopleChild = 0;
            accommodation.ValueChild = 65;
            accommodation.AmountChalets = 1;
            accommodation.Obs = "bla bla bla";
            accommodation.CalculateValueTotal();
            accommodation.Customer = customer;

            //Action
            var updatedAccommodation = repository.Update(accommodation);

            //Assert
            var persistedAccommodation = repository.Get(2);
            Assert.IsNotNull(updatedAccommodation);
            Assert.AreEqual(updatedAccommodation.Id, persistedAccommodation.Id);
            Assert.AreEqual(updatedAccommodation.DateChekIn, persistedAccommodation.DateChekIn);
            Assert.AreEqual(updatedAccommodation.DateCheckOut, persistedAccommodation.DateCheckOut);
            Assert.AreEqual(updatedAccommodation.AmountPeopleAdult, persistedAccommodation.AmountPeopleAdult);
            Assert.AreEqual(updatedAccommodation.ValueAdult, persistedAccommodation.ValueAdult);
            Assert.AreEqual(updatedAccommodation.AmountPeopleChild, persistedAccommodation.AmountPeopleChild);
            Assert.AreEqual(updatedAccommodation.ValueChild, persistedAccommodation.ValueChild);
            Assert.AreEqual(updatedAccommodation.AmountChalets, persistedAccommodation.AmountChalets);
            Assert.AreEqual(updatedAccommodation.Obs, persistedAccommodation.Obs);
            Assert.AreEqual(updatedAccommodation.ValueTotal, persistedAccommodation.ValueTotal);
            Assert.AreEqual(updatedAccommodation.Customer, persistedAccommodation.Customer);
            
            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            // updatedBlog.Should().NotBeNull();
            //updatedBlog.ShouldBeEquivalentTo(persistedBlog);
        }

        [TestMethod]
        public void DeleteAccommodationRepositoryTest()
        {
            //Arrange
            IAccommodationRepository repository = new AccommodationRepository();

            //Action
            var deletedAccommodation = repository.Delete(2);

            //Assert
            var persistedAccommodation = _contextForTest.Accommodations.Find(2);
            Assert.IsNull(persistedAccommodation);

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            //persistedAccommodation.Should().BeNull();
        }

        [TestMethod]
        public void RetrieveAccommodationBydateRepositoryTest()
        {
            //Arrange
            IAccommodationRepository repository = new AccommodationRepository();

            DateTime beginDate = new DateTime(2015, 05, 01);
            DateTime endDate = new DateTime(2015, 06, 30);

            //Action
            List<Accommodation> accommodations = repository.GetByDate(beginDate, endDate);

            //Assert
            Assert.IsNotNull(accommodations);
            Assert.AreEqual(5, accommodations.Count);

        }

    }
}
