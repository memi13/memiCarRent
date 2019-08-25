using System;
using System.Collections.Generic;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Services
{
    public interface IBrandService
    {
        List<Brand> Get();

        Brand Get(Guid id);


        void Update(Brand car, Guid id);


        void Delete(Guid car);
        void Insert(Brand car);
    }
}