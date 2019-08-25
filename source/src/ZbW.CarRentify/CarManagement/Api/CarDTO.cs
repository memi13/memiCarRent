using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Api
{
    public class CarDto
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("InOperationSince")]
        public DateTime InOperationSince { get; set; }
        public Guid id { get; set; }
        public  int PublicId { get; set; }
        [JsonProperty("HorsePower")]
        public  int HorsePower { get; set; }
        [JsonProperty("ModelId")]

        public Guid ModelId { get; set; }
        public Car ToObject()
        {
            var car=new Car(id,new Model(ModelId));
            car.Description = Description;
            car.InOperationSince = InOperationSince;
            car.PublicId = PublicId;
            car.HorsPower = HorsePower;
            return car;
        }
    }
}
