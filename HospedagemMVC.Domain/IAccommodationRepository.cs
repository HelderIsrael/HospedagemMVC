using HospedagemMVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospedagemMVC.Domain
{
    public interface IAccommodationRepository
    {
        Accommodation Save(Accommodation accommodation);
        Accommodation Get(int id);
        Accommodation Update(Accommodation accommodation);
        Accommodation Delete(int i);
        List<Accommodation> GetAll();
        List<Accommodation> GetByDate(DateTime beginDate, DateTime endDate);
    }
}
