using NUnit.Framework;
using PersonReader.Decorators;
using System;
using System.Threading.Tasks;

namespace PersonReader.Decorator.Tests
{
    public class RetryReaderTests
    {
        [Test]
        public async Task GetPeople_Broken0_ReturnsPeople()
        {
            var fakeReader = new BrokenReader(0);
            var reader = new RetryReader(fakeReader);

            var result = await reader.GetPeople();

            Assert.IsNotNull(result);
        }

        [Test]
        [Category("Slow")]
        public async Task GetPeople_Broken1_ReturnsPeople()
        {
            var fakeReader = new BrokenReader(1);
            var reader = new RetryReader(fakeReader);

            var result = await reader.GetPeople();

            Assert.IsNotNull(result);
        }

        [Test]
        [Category("Slow")]
        public async Task GetPeople_Broken3_ThrowsException()
        {
            var fakeReader = new BrokenReader(3);
            var reader = new RetryReader(fakeReader);

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
