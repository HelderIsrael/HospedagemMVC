using HospedagemMVC.Domain;
using HospedagemMVC.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospedagemMVC.Aplication
{
    public class CustomerService : ICustomerService

    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Create(Customer customer)
        {
            Validator.Validate(customer);

            var savedCustomer = _customerRepository.Save(customer);

            return savedCustomer;
        }


        public Customer Retrieve(int id)
        {
            return _customerRepository.Get(id);
        }


        public Customer Update(Customer customer)
        {
            Validator.Validate(customer);

            var updatedCustomer = _customerRepository.Update(customer);

            return updatedCustomer;
        }


        public Customer Delete(int id)
        {
            return _customerRepository.Delete(id);
        }


        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public List<Customer> GetByName(string name)
        {
            return _customerRepository.GetByName(name);
        }
    }
}

