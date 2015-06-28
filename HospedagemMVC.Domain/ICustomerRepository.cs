using HospedagemMVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospedagemMVC.Domain
{
    public interface ICustomerRepository
    {
        Customer Save(Customer customer);
        Customer Get(int id);
        Customer Update(Customer customer);
        Customer Delete(int i);
        List<Customer> GetAll();

        List<Customer> GetByName(string name);
    }
}
