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
    public class CarClassController : ControllerBase
    {
        private readonly ICarClassService _carClassService;

        public CarClassController(ICarClassService carClassService)
        {
            _carClassService = carClassService;
        }

        [HttpGet]
        public IEnumerable<CarClassDto> Get()
        {
            var result = _carClassService.Get().Select(x => x.ToDto());
            return result.ToList();
        }

        [HttpGet("{id}", Name = "GetCarClass")]
        public CarClassDto Get(Guid id)
        {
            var result = _carClassService.Get(id);
            return result.ToDto();
        }

        [HttpPost]
        public void Post([FromBody] CarClassDto car)
        {
           _carClassService.Insert(car.ToObject());
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarClassDto carClass)
        {
            _carClassService.Update(carClass.ToObject(),id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
           _carClassService.Delete(id);
        }
    }
}