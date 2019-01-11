using Common;
using Moq;
using NUnit.Framework;
using PersonReader.Decorators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonReader.Decorator.Tests
{
    public class RetryReaderTests
    {
        private IPersonReader GetBrokenReader(int timesBroken)
        {
            int brokenCount = 0;

            IEnumerable<Person> testPeople = new List<Person>()
            {
                new Person() {Id = 1,
                    GivenName = "John", FamilyName = "Smith",
                    Rating = 7, StartDate = new DateTime(2000, 10, 1)},
                new Person() {Id = 2,
                    GivenName = "Mary", FamilyName = "Thomas",
                    Rating = 9, StartDate = new DateTime(1971, 7, 23)},
            };

            var mockReader = new Mock<IPersonReader>();

            mockReader.Setup(r => r.GetPeople()).Returns(
                () =>
                {
                    if (brokenCount < timesBroken)
                    {
                        brokenCount++;
                        throw new Exception("Failed");
                    }
                    return Task.FromResult(testPeople);
                });

            return mockReader.Object;
        }

        [Test]
        public async Task GetPeople_Broken0_ReturnsPeople()
        {
            //var fakeReader = new BrokenReader(0);
            var fakeReader = GetBrokenReader(0);
            var reader = new RetryReader(fakeReader, new TimeSpan(0));

            var result = await reader.GetPeople();

            Assert.IsNotNull(result);
        }

        [Test]
        [Category("Slow")]
        public async Task GetPeople_Broken1_ReturnsPeople()
        {
            //var fakeReader = new BrokenReader(1);
            var fakeReader = GetBrokenReader(1);
            var reader = new RetryReader(fakeReader, new TimeSpan(0));

            var result = await reader.GetPeople();

            Assert.IsNotNull(result);
        }

        [Test]
        [Category("Slow")]
        public async Task GetPeople_Broken3_ThrowsException()
        {
            //var fakeReader = new BrokenReader(3);
            var fakeReader = GetBrokenReader(3);
            var reader = new RetryReader(fakeReader, new TimeSpan(0));

            try
            {
                var result = await reader.GetPeople();
                Assert.Fail("Exception was not thrown");
            }
            catch (Exception)
            {
                Assert.Pass("Exception thrown");
            }
        }
    }
}
