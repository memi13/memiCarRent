using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Services
{
    public interface ICarService
    {
        List<Car> Get();

        Car Get(Guid id);


        void Update(Car car,Guid id);


        void Delete(Guid car);
        void Insert(Car car);
    }
}
