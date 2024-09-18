using EXL.Functions.Mathematical;
using NUnit.Framework;

namespace EXL.Tests.Functions.Mathematical
{
    [TestFixture]
    internal class AcosFunctionTests
    {
        private AcosFunction _acosFunction;

        [SetUp]
        public void SetUp()
        {
            _acosFunction = new AcosFunction();
        }

        [Test]
        public void Execute_WithValidNumber_ReturnsAcosValue()
        {
            var result = _acosFunction.Execute(new object[] { 0.5 });
            Assert.AreEqual(Math.Acos(0.5), result);
        }

        [Test]
        public void Execute_WithNumberOutOfRange_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _acosFunction.Execute(new object[] { 2 }));
        }

        [Test]
        public void Execute_WithInvalidType_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _acosFunction.Execute(new object[] { "invalid" }));
        }

        [Test]
        public void Execute_WithMultipleArguments_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _acosFunction.Execute(new object[] { 0.5, 0.5 }));
        }

        [Test]
        public void Execute_WithEmptyArguments_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _acosFunction.Execute(new object[] { }));
        }
    }
}
