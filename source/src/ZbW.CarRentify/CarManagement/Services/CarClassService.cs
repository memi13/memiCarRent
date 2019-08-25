using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using Microsoft.Extensions.Logging;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Services
{
    public class CarClassService:ICarClassService
    {
        private readonly ILogger<CarClassService> _logger;
        private readonly ICarClassRepository _carClassRepository;

        public CarClassService(ICarClassRepository carClassService, ILogger<CarClassService> logger)
        {
            _logger = logger;
            _carClassRepository = carClassService;
        }
        public List<CarClass> Get()
        {
            var result = _carClassRepository.GetAll();
            return result.ToList();
        }

        public CarClass Get(Guid id)
        {
            var result = _carClassRepository.Get(id);
            return result;
        }

        public void Update(CarClass carClass, Guid id)
        {
            if(!id.Equals(carClass.Id))
                throw new GuidNotEqualException();
        }

        public void Delete(Guid id)
        {
            _carClassRepository.Delete(new CarClass(id));
        }

        public void Insert(CarClass carClass)
        {
            _carClassRepository.Insert(carClass);
        }
    }
}