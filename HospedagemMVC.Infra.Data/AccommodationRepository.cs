using HospedagemMVC.Domain;
using HospedagemMVC.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace HospedagemMVC.Infra.Data
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private CustomerContext context;

        public AccommodationRepository()
        {
            context = new CustomerContext();
        }

        public Accommodation Save(Accommodation accommodation)
        {
            var newAccommodation = context.Accommodations.Add(accommodation);
            context.SaveChanges();
            return newAccommodation;
        }


        public Accommodation Get(int id)
        {
            var accommodation = context.Accommodations.Find(id);
            return accommodation;
        }


        public Accommodation Update(Accommodation accommodation)
        {
            DbEntityEntry entry = context.Entry(accommodation);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return accommodation;
        }


        public Accommodation Delete(int id)
        {
            var accommodation = context.Accommodations.Find(id);
            DbEntityEntry entry = context.Entry(accommodation);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return accommodation;
        }

        public List<Accommodation> GetAll()
        {
            return context.Accommodations.ToList();
        }

        public List<Accommodation> GetByDate(DateTime beginDate, DateTime endDate)
        {
            return context.Accommodations.Where(accommodation => 
                (accommodation.DateChekIn >= beginDate && accommodation.DateCheckOut <= endDate)
                || (accommodation.DateChekIn <= endDate && accommodation.DateCheckOut >= beginDate)).ToList();

        }
    }
}
