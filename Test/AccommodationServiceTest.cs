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
    public class AccommodationServiceTest
    {
        
        [TestMethod]
        public void CreateAccommodationServiceValidationAndPersistenceTest()
        {
            //Arrange
            Accommodation accommodation = ObjectMother.GetAccommodation();
            //Fake do repositório
            var repositoryFake = new Mock<IAccommodationRepository>();
            repositoryFake.Setup(r => r.Save(accommodation)).Returns(accommodation);
            //Fake do dominio
            var accommodationFake = new Mock<Accommodation>();
            accommodationFake.As<IObjectValidation>().Setup(b => b.Validate());

            IAccommodationService service = new AccommodationService(repositoryFake.Object);

            //Action
            service.Create(accommodationFake.Object);

            //Assert
            accommodationFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Save(accommodationFake.Object));
        }

        [TestMethod]
        public void RetrieveAccommodationServiceTest()
        {
            //Arrange
            Accommodation accommodation = ObjectMother.GetAccommodation();
            //Fake do repositório
            var repositoryFake = new Mock<IAccommodationRepository>();
            repositoryFake.Setup(r => r.Get(1)).Returns(accommodation);

            IAccommodationService service = new AccommodationService(repositoryFake.Object);

            //Action
            var accommodationFake = service.Retrieve(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));
            Assert.IsNotNull(accommodationFake);
        }

        [TestMethod]
        public void UpdateAccommodationServiceValidationAndPersistenceTest()
        {
            //Arrange
            Accommodation accommodation = ObjectMother.GetAccommodation();
            //Fake do repositório
            var repositoryFake = new Mock<IAccommodationRepository>();
            repositoryFake.Setup(r => r.Update(accommodation)).Returns(accommodation);
            //Fake do dominio
            var accommodationFake = new Mock<Accommodation>();
            accommodationFake.As<IObjectValidation>().Setup(b => b.Validate());

            IAccommodationService service = new AccommodationService(repositoryFake.Object);

            //Action
            service.Update(accommodationFake.Object);

            //Assert
            accommodationFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Update(accommodationFake.Object));
        }

        [TestMethod]
        public void DeleteAccommodationServiceTest()
        {
            //Arrange
            Accommodation accommodation = null;
            //Fake do repositório
            var repositoryFake = new Mock<IAccommodationRepository>();
            repositoryFake.Setup(r => r.Delete(1)).Returns(accommodation);

            IAccommodationService service = new AccommodationService(repositoryFake.Object);

            //Action
            var accommodationFake = service.Delete(1);

            //Assert
            repositoryFake.Verify(r => r.Delete(1));
            Assert.IsNull(accommodationFake);
        }
    }
}