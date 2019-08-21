using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZbW.CarRentify.Common
{
    public abstract class EntityBase : IEquatable<EntityBase>
    {
        private readonly Guid _id;

        protected EntityBase()
        {
            _id = Guid.NewGuid();
        }

        public Guid Id => _id;

        public override bool Equals(object obj)
        {
            return Equals(obj as EntityBase);
        }

        public bool Equals(EntityBase other)
        {
            return other != null && _id.Equals(other._id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id);
        }
    }
}
