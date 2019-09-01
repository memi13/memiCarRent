using System;
using ZbW.CarRentify.ReservationMangment.Domain;

namespace ZbW.CarRentify.ReservationMangment.Api
{
    public class CustomerDto
    {
        public Guid id { get; set; }
        public int PublicId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public string Status { get; set; }
        public string Sex { get; set; }
        internal Customer ToObject()
        {
            var customer=new Customer(id);
            customer.PublicId = PublicId;
            customer.Birthday = Birthday;
            customer.Name = Name;
            customer.FirstName = FirstName;
            customer.Status = Status;
            customer.Sex = Sex;
            return customer;
        }
    }
}