using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZbW.CarRentify.CarManagement.Domain
{
    public class Brand
    {
        private readonly List<Model> _models;

        public IReadOnlyList<Model> Models => _models;
    }
}
