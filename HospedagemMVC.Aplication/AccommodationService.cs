using HospedagemMVC.Domain;
using HospedagemMVC.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospedagemMVC.Aplication
{
    public class AccommodationService : IAccommodationService
    {
        private IAccommodationRepository _accommodationRepository;

        public AccommodationService(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public Accommodation Create(Accommodation accommodation)
        {

            accommodation.CalculateValueTotal();

            Validator.Validate(accommodation);

            //CalculateValueTotal(accommodation);

            var savedAccommodation = _accommodationRepository.Save(accommodation);

            return savedAccommodation;
        }


        public Accommodation Retrieve(int id)
        {
            return _accommodationRepository.Get(id);
        }


        public Accommodation Update(Accommodation accommodation)
        {
            Validator.Validate(accommodation);

            var updatedAccommodation = _accommodationRepository.Update(accommodation);

            return updatedAccommodation;
        }


        public Accommodation Delete(int id)
        {
            return _accommodationRepository.Delete(id);
        }


        public List<Accommodation> RetrieveAll()
        {
            return _accommodationRepository.GetAll();
        }

        public double CalculateValueTotal(Accommodation accommodation)
        {
            Validator.Validate(accommodation);

            accommodation.CalculateValueTotal();

            return accommodation.ValueTotal;
        }

        public List<Accommodation> GetByDate(DateTime beginDate, DateTime endDate)
        {
            return _accommodationRepository.GetByDate(beginDate, endDate);

        }
    }
}

