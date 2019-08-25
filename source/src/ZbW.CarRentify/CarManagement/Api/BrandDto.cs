using System;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Api
{
    public class BrandDto
    {
        public Guid id { get; set; }
        public int PublicId { get; set; }
        public String Name { get; set; }
        public string Country { get; set; }

        public Brand ToObject()
        {
            var obj = new Brand(id);
            obj.Country = Country;
            obj.Name = Name;
            return obj;
        }
    }
}