using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZbW.CarRentify.CarManagement.Api;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Domain
{
    public class Car : EntityBase
    {
        private readonly Model _model;

        public Model Model => _model;
        public int HorsPower { get; set; }
        public  DateTime InOperationSince { get; set; }
        public  string Description { get; set; }
        public Car() : base()
        {

        }
        public Car(Guid id) : base(id)
        {

        }
        public Car(Guid id,Model m):base(id)
        {
            _model = m;
        }

        public CarDto ToDto()
        {
            var dto=new CarDto();
            dto.id = this.Id;
            dto.PublicId = this.PublicId;
            dto.HorsePower = this.HorsPower;
            dto.Description = this.Description;
            dto.InOperationSince = this.InOperationSince;
            dto.ModelId = _model.Id;

            return dto;
        }

        public override string ToString()
        {
            return $"{Id.ToString()};{PublicId.ToString()};{Description};{HorsPower};{InOperationSince.ToString()};{EditFrom};{Edit};{CreateFrom};{Create}";
        }
    }
}
