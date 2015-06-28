using HospedagemMVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospedagemMVC.Aplication
{
    public interface ICustomerService
    {
            Customer Create(Customer customer);
            Customer Retrieve(int id);
            Customer Update(Customer customer);
            Customer Delete(int id);
            List<Customer> GetAll();

            List<Customer> GetByName(string name);
    }
    }
