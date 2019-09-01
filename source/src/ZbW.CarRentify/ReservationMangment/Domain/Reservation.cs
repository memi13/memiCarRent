using System;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ReservationMangment.Api;

namespace ZbW.CarRentify.ReservationMangment.Domain
{
    public class Reservation:EntityBase
    {
        private Car _car;
        public Car Car => _car;
        public DateTime From { get; set; }
        public  DateTime UnTil { get; set; }
        public string Description { get; set; }

        public Reservation() : base(new Guid())
        {

        }

        public Reservation(Guid id) : base(id)
        {

        }
        public Reservation(Guid id,Car car) : base(id)
        {
            _car = car;
        }

        public ReservationDto ToDto()
        {
            return ToDto();
        }
    }
}