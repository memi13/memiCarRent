using FakeItEasy;
using NUnit.Framework;

namespace Zbw.Mime.Tests
{
    [TestFixture]
    public class TestCar
    {
        [Test]
        public void Test1()
        {
            var foo = A.Fake<ICarService>(x => x.Strict());
        }
    }
}