using System;
using System.Collections.Generic;
using ZbW.CarRentify.ReservationMangment.Domain;

namespace ZbW.CarRentify.ReservationMangment.Services
{
    public interface ICustomerService
    {
        List<Customer> Get();

        Customer Get(Guid id);


        void Update(Customer customer, Guid id);


        void Delete(Guid id);
        void Insert(Customer customer);
    }
}