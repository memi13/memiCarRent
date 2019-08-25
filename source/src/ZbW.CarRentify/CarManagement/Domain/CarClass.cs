using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZbW.CarRentify.CarManagement.Api;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Domain
{
    public class CarClass:EntityBase
    {
        private readonly string _name;

        private readonly decimal _dailyFee;

        public CarClass()
        {
        }
        public CarClass(Guid id) : base(id)
        {
        }
        public CarClass(Guid id,string name,decimal daileFee) : base(id)
        {
            _name = name;
            _dailyFee = daileFee;
        }

        public CarClassDto ToDto()
        {
            var dto = new CarClassDto();
            dto.id = this.Id;
            dto.PublicId = this.PublicId;
            dto.Name = this._name;
            dto.DailyFee = this._dailyFee;

            return dto;
        }
        public override string ToString()
        {
            return $"{Id.ToString()};{PublicId.ToString()};{_name};{_dailyFee};{EditFrom};{Edit};{CreateFrom};{Create}";
        }
    }
}
