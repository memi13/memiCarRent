using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZbW.CarRentify.CarManagement.Api;
using ZbW.CarRentify.ReservationMangment.Services;

namespace ZbW.CarRentify.ReservationMangment.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IEnumerable<ReservationDto> Get()
        {
            var result = _reservationService.Get().Select(x=>x.ToDto());
            return result;
        }

        [HttpGet("{id}", Name = "GetReservation")]
        public ReservationDto Get(Guid id)
        {
            var result = _reservationService.Get(id).ToDto();
            return result;
        }

        [HttpPost]
        public void Post([FromBody] ReservationDto car)
        {
            _reservationService.Insert(car.ToObject());
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ReservationDto car)
        {
            _reservationService.Update(car.ToObject(), id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _reservationService.Delete(id);
        }
    }
}