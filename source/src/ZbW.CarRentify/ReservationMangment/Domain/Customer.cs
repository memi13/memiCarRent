using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ReservationMangment.Api;

namespace ZbW.CarRentify.ReservationMangment.Domain
{
    public class Customer:EntityBase
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public string Status { get; set; }
        public  string Sex { get; set; }
        public  Customer(Guid id) : base(id) { }
        internal CustomerDto ToDto()
        {
            var customer = new CustomerDto();
            customer.id = Id;
            customer.PublicId = PublicId;
            customer.Birthday = Birthday;
            customer.Name = Name;
            customer.FirstName = FirstName;
            customer.Status = Status;
            customer.Sex = Sex;
            return customer;
        }
        public override string ToString()
        {
            return $"{Id.ToString()};{PublicId.ToString()};{Name};{FirstName};{Birthday};{Status};{Sex};{EditFrom};{Edit};{CreateFrom};{Create}";
        }
    }
}