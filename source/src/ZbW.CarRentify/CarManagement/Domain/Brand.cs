using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Domain
{
    public class Brand:EntityBase
    {

        private readonly List<Model> _models;

        public IReadOnlyList<Model> Models => _models;

        public Brand()
        {

        }
        public Brand(Guid id):base(id)
        {

        }
    }
}
