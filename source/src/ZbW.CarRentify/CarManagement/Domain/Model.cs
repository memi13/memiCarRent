using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ZbW.CarRentify.CarManagement.Api;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Domain
{
    public class Model:EntityBase
    {
        private readonly Brand _brand;
        private readonly CarClass _carClass;
        public Model()
        {
        }
        public Brand Brand => _brand;
        public CarClass CarClass => _carClass;
        public String Name { get; set; }
        public  int Version { get; set; }
        public Model(Guid id) : base(id)
        {

        }

        public Model(Guid id,CarClass carClass,Brand brand) : base(id)
        {
            _carClass = carClass;
            _brand = brand;
        }
        public ModelDto ToDto()
        {
            var dto = new ModelDto();
            dto.id = this.Id;
            dto.PublicId = this.PublicId;
            dto.Name = this.Name;
            dto.Version = this.Version;
            dto.BrandId = this.Brand.Id;
            dto.CarClassId = this.CarClass.Id;
            return dto;
        }
        public override string ToString()
        {
            return $"{Id.ToString()};{PublicId.ToString()};{Name};{Version};{EditFrom};{Edit};{CreateFrom};{Create};{CarClass.Id.ToString()};{Brand.Id.ToString()}";
        }

    }
}
