using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Api
{
    public class CarDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        public Guid id { get; set; }
        public  int PublicId { get; set; }


        public Car ToObject()
        {
            return new Car();
        }
    }
}
