using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ContractManagment.Domain;
using ZbW.CarRentify.ContractManagment.Services;
using ZbW.CarRentify.ReservationMangment.Domain;

namespace ZbW.CarRentify.ReservationMangment.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }
        public void Delete(Guid id)
        {
            _customerRepository.Delete(new Customer(id));
        }

        public List<Customer> Get()
        {
            var result= _customerRepository.GetAll();
            return result.ToList();
        }

        public Customer Get(Guid id)
        {
            var result = _customerRepository.Get(id);
            return result;
        }

        public void Insert(Customer customer)
        {
            _customerRepository.Insert(customer);
        }

        public void Update(Customer customer, Guid id)
        {
            if(!id.Equals(customer.Id))
                throw new GuidNotEqualException();
            _customerRepository.Update(customer);
        }
    }
}