using NUnit.Framework;
using PersonReader.Decorators;
using System;
using System.Threading.Tasks;

namespace PersonReader.Decorator.Tests
{
    public class ExceptionLoggingReaderTests
    {
        [Test]
        public async Task GetPeople_OnNoException_NothingLogged()
        {
            var wrapped = new BrokenReader(0);
            var logger = new StringLogger();
            var reader = new ExceptionLoggingReader(wrapped, logger);

            await reader.GetPeople();

            Assert.IsEmpty(logger.Log);
        }

        [Test]
        public async Task GetPeople_OnException_ExceptionLogged()
        {
            var wrapped = new BrokenReader(1);
            var logger = new StringLogger();
            var reader = new ExceptionLoggingReader(wrapped, logger);
            var expectedMessage = "INVALIDEXCEPTIONMESSAGE";

            try
            {
                await reader.GetPeople();
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                expectedMessage = ex.Message;
            }

            Assert.That(() => logger.Log.Contains(expectedMessage));
        }
    }
}
