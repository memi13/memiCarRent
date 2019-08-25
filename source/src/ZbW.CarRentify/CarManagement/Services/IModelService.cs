using System;
using System.Collections.Generic;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Services
{
    public interface IModelService
    {
        List<Model> Get();

        Model Get(Guid id);


        void Update(Model car, Guid id);


        void Delete(Guid car);
        void Insert(Model car);
    }
}