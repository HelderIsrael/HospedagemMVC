using HospedagemMVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospedagemMVC.Aplication
{
    public interface IAccommodationService
    {
            Accommodation Create(Accommodation accommodation);
            Accommodation Retrieve(int id);
            Accommodation Update(Accommodation accommodation);
            Accommodation Delete(int id);
            List<Accommodation> RetrieveAll();

            double CalculateValueTotal(Accommodation accommodation);
           List<Accommodation> GetByDate(DateTime beginDate, DateTime endDate);

    }
    }

