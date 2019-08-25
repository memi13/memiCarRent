using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZbW.CarRentify.CarManagement.Api;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Domain
{
    public class Brand : EntityBase
    {

        private readonly List<Model> _models;

        public IReadOnlyList<Model> Models => _models;
        public String Name { get; set; }
        public string Country { get; set; }

        public Brand()
        {

        }

        public Brand(Guid id) : base(id)
        {
        }

        public BrandDto ToDto()
        {
            var dto = new BrandDto();
            dto.id = this.Id;
            dto.PublicId = this.PublicId;
            dto.Country = this.Country;
            dto.Name = this.Name;
            return dto;
        }

        public override string ToString()
        {
            return $"{Id.ToString()};{PublicId.ToString()};{Name};{Country};{EditFrom};{Edit};{CreateFrom};{Create}";
        }
    }
}
