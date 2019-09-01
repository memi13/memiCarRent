using System;
using ZbW.CarRentify.ReservationMangment.Domain;

namespace ZbW.CarRentify.ReservationMangment.Api
{
    public class EmployeeDto
    {
        public Guid id { get; set; }
        public int PublicId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }

        public string Position { get; set; }
        public string Sex { get; set; }
        internal Employee ToObject()
        {
            var emploeey=new Employee(id);
            emploeey.PublicId = PublicId;
            emploeey.Birthday = Birthday;
            emploeey.Name = Name;
            emploeey.FirstName = FirstName;
            emploeey.Position = Position;
            emploeey.Sex = Sex;
            return emploeey;
        }
    }
}