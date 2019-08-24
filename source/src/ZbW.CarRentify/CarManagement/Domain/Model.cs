using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Domain
{
    public class Model:EntityBase
    {
        public Model()
        {
        }

        public Model(Guid id) : base(id)
        {

        }
    }
}
