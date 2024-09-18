using EXL.Functions.Mathematical;

namespace EXL.Tests.Functions.Mathematical
{
    [TestFixture]
    public class AcoshFunctionTests
    {
        private AcoshFunction _acoshFunction;

        [SetUp]
        public void SetUp()
        {
            _acoshFunction = new AcoshFunction();
        }

        [Test]
        public void Execute_WithValidNumber_ReturnsAcoshValue()
        {
            var result = _acoshFunction.Execute(new object[] { 1.5 });
            Assert.AreEqual(Math.Acosh(1.5), result);
        }

        [Test]
        public void Execute_WithNumberLessThanOne_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _acoshFunction.Execute(new object[] { 0.5 }));
        }

        [Test]
        public void Execute_WithInvalidType_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _acoshFunction.Execute(new object[] { "invalid" }));
        }

        [Test]
        public void Execute_WithMultipleArguments_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _acoshFunction.Execute(new object[] { 1.5, 2.0 }));
        }

        [Test]
        public void Execute_WithEmptyArguments_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _acoshFunction.Execute(new object[] { }));
        }
    }
}
