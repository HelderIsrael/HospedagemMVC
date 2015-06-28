using System.ComponentModel.DataAnnotations;
using HospedagemMVC.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HospedagemMVC.Domain
{
    public class Accommodation : IObjectValidation
    {
        public int Id { get; set; }

        [DisplayName("Check-In")]
        public DateTime DateChekIn { get; set; }

        [DisplayName("Check-Out")]
        public DateTime DateCheckOut { get; set; }

        [DisplayName("Adultos")]
        public int AmountPeopleAdult { get; set; }

        [DisplayName("Criança")]
        public int AmountPeopleChild { get; set; }

        [DisplayName("Chalés")]
        public int AmountChalets { get; set; }

        [DisplayName("R$ Adulto")]
        public int ValueAdult { get; set; }

        [DisplayName("R$ Criança")]
        public int ValueChild { get; set; }

        [DisplayName("R$ Total")]
        public int ValueTotal { get; set; }

        [DisplayName("Obs")]
        public string Obs { get; set; }

        [DisplayName("Cliente")]
        public virtual Customer Customer { get; set; }

        [DisplayName("Cliente")]
        public int CustomerId { set; get; }


        public int CalculateValueTotal()
        {
            var dif = (DateCheckOut - DateChekIn).TotalDays;

            int calculateAux = (ValueAdult*AmountPeopleAdult) + (ValueChild*AmountPeopleChild);

            double valor = dif*calculateAux;

            ValueTotal = Convert.ToInt32(valor);

            return ValueTotal;
        }
       
        public void Validate()
        {
            if (DateChekIn < DateTime.Today)
                throw new Exception("Data de Check In inválida");

            if (DateChekIn > DateCheckOut)
                throw new Exception("Data de Check Out inválida");

            if (AmountPeopleAdult <= 0)
                throw new Exception("Quantidade de Pessoas não pode ser 0 ou menor");

            if (AmountChalets <= 0)
                throw new Exception("Quantidade de Chalés não pode ser 0 ou menor");

            if (ValueAdult <= 0)
                throw new Exception("Valor da diária por pessoa não pode ser igual a zero");
        }

    }
}
