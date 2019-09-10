using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ZbW.CarRentify.CarManagement.Api;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.CarManagement.Services;

namespace Zbw.Mime.TestsCarRent
{
    [TestFixture]
    public class TestCar
    {
        [Test]
        public void CarController_GetAll_FirstTestAuto()
        {
            var newList=new List<Car>();
            var car = new Car(new Guid(), new Model(new Guid()));
            car.Description = "Test Auto";
            newList.Add(car);         
             var foo = A.Fake<ICarService>(x => x.Strict());
             A.CallTo(() => foo.Get()).Returns(newList);
             var t = new CarController(foo);
             var dd= t.Get().First();
            Assert.That(dd.Description, Is.EqualTo("Test Auto"));
        }

    }
}