using HospedagemMVC.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace HospedagemMVC.Infra.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext context;

        public CustomerRepository()
        {
            context = new CustomerContext();
        }

        public Customer Save(Customer customer)
        {
            var newCustomer = context.Customers.Add(customer);
            context.SaveChanges();
            return newCustomer;
        }


        public Customer Get(int id)
        {
            var customer = context.Customers.Find(id);
            return customer;
        }


        public Customer Update(Customer customer)
        {
            DbEntityEntry entry = context.Entry(customer);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return customer;
        }


        public Customer Delete(int id)
        {
            var customer = context.Customers.Find(id);
            DbEntityEntry entry = context.Entry(customer);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return customer;
        }


        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }


        public List<Customer> GetByName(string name)
        {
            return context.Customers.Where(customer => customer.Name.Contains(name)).ToList();
        }
    }
}
