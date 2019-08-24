using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZbW.CarRentify.CarManagement.Services;

namespace ZbW.CarRentify.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IEnumerable<CarDTO> Get()
        {
            var result = _carService.Get().Select(x=>x.ToDto());
            return result;
        }

        [HttpGet("{id}", Name = "GetCar")]
        public CarDTO Get(Guid id)
        {
            var result = _carService.Get(id).ToDto();
            return result;
        }

        [HttpPost]
        public void Post([FromBody] CarDTO car)
        {
            _carService.Insert(car.ToObject());
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarDTO car)
        {
            _carService.Update(car.ToObject(),id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _carService.Delete(id);
        }
    }
}
