using System.ComponentModel;
using HospedagemMVC.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HospedagemMVC.Domain
{
    public class Customer : IObjectValidation
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Fone")]
        public string Phone { get; set; }

        [DisplayName("Cidade")]
        public string City { get; set; }

        public List<Accommodation> Accommodations { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception("Nome Inválido");
            if (string.IsNullOrEmpty(Phone))
                throw new Exception("Telefone Inválido");
            if (!string.IsNullOrEmpty(Email))
            {
                if (!Email.Contains("@"))
                    throw new Exception("E-mail Inválido");
            }
        }
    }
}
