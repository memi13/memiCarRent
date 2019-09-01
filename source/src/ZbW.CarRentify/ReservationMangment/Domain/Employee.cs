using System;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ReservationMangment.Api;

namespace ZbW.CarRentify.ReservationMangment.Domain
{
    public class Employee: EntityBase
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }

        public string Position { get; set; }
        public string Sex { get; set; }
        public Employee(Guid id) : base(id)
        {

        }
        internal EmployeeDto ToDto()
        {
            var emploeey = new EmployeeDto();
            emploeey.id = Id;
            emploeey.PublicId = PublicId;
            emploeey.Birthday = Birthday;
            emploeey.Name = Name;
            emploeey.FirstName = FirstName;
            emploeey.Position = Position;
            emploeey.Sex = Sex;
            return emploeey;
        }
        public override string ToString()
        {
            return $"{Id.ToString()};{PublicId.ToString()};{Name};{FirstName};{Birthday};{Position};{Sex};{EditFrom};{Edit};{CreateFrom};{Create}";
        }
    }
}