using OnlineStore.Models;
using OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Service
{
    public class CustomerService :ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer Create(Customer customer)
        {
            return customerRepository.Create(customer);
        }

        public void Delete(int id)
        {
            customerRepository.Delete(id);
        }

        public Customer FindById(int id)
        {
            return customerRepository.FindById(id);
        }

        public Customer Update(Customer customer)
        {
            return customerRepository.Update(customer);
        }

        public List<Customer> GetAll()
        {
            return customerRepository.GetAll();

        }

        public bool Exists(int id)
        {
            return customerRepository.Exists(id);
        }

        public Customer Login(string username, string password)
        {
            var user = customerRepository.FindByUsername(username);
            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }
    }
}
