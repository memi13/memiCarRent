using System;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Api
{
    public class CarClassDto
    {
        public Guid id { get; set; }
        public int PublicId { get; set; }
        public string Name { get; set; }

        public decimal DailyFee {get; set; }
        public CarClass ToObject()
        {
            var obj = new CarClass(id,Name, DailyFee);
            return obj;
        }
    }
}