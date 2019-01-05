using NUnit.Framework;
using PersonReader.Decorators;
using System;
using System.Threading.Tasks;

namespace PersonReader.Decorator.Tests
{
    class CachingReaderTests
    {
        [Test]
        public async Task GetPeople_OnNoCache_CallsReader()
        {
            var counted = new CountedReader();
            var duration = new TimeSpan(0, 0, 1);
            var reader = new CachingReader(counted, duration);

            await reader.GetPeople();

            Assert.AreEqual(1, counted.CallCount);
        }

        [Test]
        public async Task GetPeople_CalledTwice_CallsReaderOnce()
        {
            var counted = new CountedReader();
            var duration = new TimeSpan(0, 0, 1);
            var reader = new CachingReader(counted, duration);

            await reader.GetPeople();
            await reader.GetPeople();

            Assert.AreEqual(1, counted.CallCount);
        }

        [Test]
        [Category("Slow")]
        public async Task GetPeople_OnExpiredCache_CallsReader()
        {
            var counted = new CountedReader();
            var duration = new TimeSpan(0, 0, 1);
            var reader = new CachingReader(counted, duration);

            await reader.GetPeople();
            await Task.Delay(2000);
            await reader.GetPeople();

            Assert.AreEqual(2, counted.CallCount);
        }
    }
}
