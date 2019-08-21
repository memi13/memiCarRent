using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Domain
{
    public class Car : EntityBase
    {
        private readonly Model _model;

        public Model Model => _model;
    }
}
