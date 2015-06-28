using HospedagemMVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ObjectMother
    {
        public static Customer GetCustomer()
        {
            Customer customer = new Customer();
            customer.Name = "helder Rocha Israel";
            customer.Phone = "4999332297";
            customer.Email = "helder_israel@hotmail.com";
            customer.City = "Urubici";
            customer.Accommodations = new List<Accommodation>()
            {
                new Accommodation()
                {
                    DateChekIn = DateTime.Now,
                    DateCheckOut = DateTime.Now.AddDays(2),
                    AmountPeopleAdult = 5,
                    AmountPeopleChild = 2,
                    AmountChalets = 2,
                    ValueAdult = 150,
                    ValueChild = 65,
                    ValueTotal = 300,
                    Obs = "observaçoes relevantes a hospedagem"
                }
            };

            return customer;
        }

        public static Accommodation GetAccommodation()
        {
            Customer customer = new Customer();
            customer.Name = "helder Rocha Israel";
            customer.Phone = "4999332297";
            customer.Email = "helder_israel@hotmail.com";
            customer.City = "Urubici";

            Accommodation accommodation = new Accommodation();
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

            return accommodation;
            
        }
    }
}
