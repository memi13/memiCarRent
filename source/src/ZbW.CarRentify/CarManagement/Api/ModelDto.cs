using System;
using Newtonsoft.Json;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Api
{
    public class ModelDto
    {
        public Guid id { get; set; }
        public int PublicId { get; set; }
        public String Name { get; set; }
        public int Version { get; set; }

        [JsonProperty("BrandId")]

        public Guid BrandId { get; set; }
        [JsonProperty("CarClassId")]

        public Guid CarClassId { get; set; }
        public Model ToObject()
        {
            var obj = new Model(id, new CarClass(CarClassId), new Brand(BrandId));
            obj.Name = Name;
            obj.Version = Version;
            return obj;
        }
    }
}