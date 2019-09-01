using System;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.ReservationMangment.Domain
{
    public class Car:EntityBase
    {
        public Car(Guid id) : base(id)
        {

        }

        public Car() : base(new Guid())
        {

        }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string ModelName { get; set; }
    }
}