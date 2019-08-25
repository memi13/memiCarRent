using System;
using System.Collections.Generic;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Services
{
    public interface ICarClassService
    {
        List<CarClass> Get();

        CarClass Get(Guid id);


        void Update(CarClass car, Guid id);


        void Delete(Guid car);
        void Insert(CarClass car);
    }
}