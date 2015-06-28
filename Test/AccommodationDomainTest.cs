using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HospedagemMVC.Domain;
using HospedagemMVC.Infra;

namespace Test
{
    [TestClass]
    public class AccommodationDomainTest
    {
            [TestMethod]
            public void CreateAAccommodationTest()
            {
                Accommodation accommodation = ObjectMother.GetAccommodation();

                Assert.IsNotNull(accommodation);
            }

            [TestMethod]
            public void CreateAValidAccommodationTest()
            {
                Accommodation accommodation = ObjectMother.GetAccommodation();

                Validator.Validate(accommodation);
            }

            [TestMethod]
            [ExpectedException(typeof (Exception))]
            public void CreateAInvalidAccommodationDateCheckInTest()
            {
                Accommodation accommodation = new Accommodation();

                Validator.Validate(accommodation);
            }

            [TestMethod]
            [ExpectedException(typeof (Exception))]
            public void CreateAInvalidAccommodationDateCheckOutTest()
            {
                Accommodation accommodation = new Accommodation();
                accommodation.DateChekIn = DateTime.Now;

                Validator.Validate(accommodation);
            }

            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void CreateAInvalidAccommodationAmountPeopleTest()
            {
                Accommodation accommodation = new Accommodation();
                accommodation.DateChekIn = DateTime.Now;
                accommodation.DateCheckOut = DateTime.Now.AddDays(2);

                Validator.Validate(accommodation);
            }

            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void CreateAInvalidAccommodationAmountChaletsTest()
            {
                Accommodation accommodation = new Accommodation();
                accommodation.DateChekIn = DateTime.Now;
                accommodation.DateCheckOut = DateTime.Now.AddDays(2);
                accommodation.ValueAdult = 130;

                Validator.Validate(accommodation);
            }

            [TestMethod]
            //[ExpectedException(typeof(Exception))]
            public void CalculateAccommodationValueTotalTest()
            {
                Accommodation accommodation = new Accommodation();
                accommodation.DateChekIn = DateTime.Now;
                accommodation.DateCheckOut = DateTime.Now.AddDays(2);
                accommodation.ValueAdult = 130;
                accommodation.AmountPeopleAdult = 2;
                accommodation.ValueChild = 65;
                accommodation.AmountPeopleChild = 2;

                accommodation.CalculateValueTotal();

                Assert.AreEqual(780, accommodation.ValueTotal);
            }


        }
    }
