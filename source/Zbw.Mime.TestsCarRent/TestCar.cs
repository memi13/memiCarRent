using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
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
        public void Test1()
        {
            var newList=new List<Car>();
            newList.Add(new Car());
            
             var foo = A.Fake<ICarService>(x => x.Strict());
             A.CallTo(() => foo.Get()).Returns(newList);
             var t = new CarController(foo);
             var dd= t.Get().First();

            Assert.That(dd, Is.Empty);
        }

    }
}