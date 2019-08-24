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

        public Car() : base()
        {

        }
        public Car(Guid id,Model m):base(id)
        {
           
        }
        public CarDTO ToDto()
        {
            var dto=new CarDTO();
            dto.id = this.Id;
            dto.PublicId = this.PublicId;

            return dto;
        }
    }
}
