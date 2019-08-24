using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
