using System;
using System.Collections.Generic;
using ZbW.CarRentify.ReservationMangment.Domain;

namespace ZbW.CarRentify.ReservationMangment.Services
{
    public interface IEmploeeyService
    {
        List<Employee> Get();

        Employee Get(Guid id);


        void Update(Employee employee, Guid id);


        void Delete(Guid id);
        void Insert(Employee employee);
    }
}