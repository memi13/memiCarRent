using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Services
{
    public class CarService : ICarService
    {
        private readonly ILogger<CarService> _logger;
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository, ILogger<CarService> logger)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        public List<Car> Get()
        {
            var result = _carRepository.GetAll();
            return result.ToList();
        }

        public Car Get(Guid id)
        {
            var result=new Car();
            return result;
        }

        public void Update(Car car,Guid id)
        {
           if(car.Id.Equals(id))
               _carRepository.Update(car);
           throw new GuidNotEqualException();
        }

        public void Delete(Guid id)
        {
            var car=new Car(id);
        
            _carRepository.Delete(car);
        }

        public void Insert(Car car)
        {
            _carRepository.Insert(car);
        }
    }
}
