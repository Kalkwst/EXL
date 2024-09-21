using EXL.Functions.Mathematical;

namespace EXL.Tests.Functions.Mathematical
{
    [TestFixture]
    public class AcoshFunctionTests
    {
        private AcoshFunction acoshFunction;
        private static readonly object[] Args = [];

        [SetUp]
        public void SetUp()
        {
            acoshFunction = new AcoshFunction();
        }

        [Test]
        public void Execute_WithValidNumber_ReturnsAcoshValue()
        {
            var result = acoshFunction.Execute([1.5]);
            Assert.That(result, Is.EqualTo(Math.Acosh(1.5)));
        }

        [Test]
        public void Execute_WithNumberLessThanOne_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => acoshFunction.Execute([0.5]));
        }

        [Test]
        public void Execute_WithInvalidType_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => acoshFunction.Execute(["invalid"]));
        }

        [Test]
        public void Execute_WithMultipleArguments_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => acoshFunction.Execute([1.5, 2.0]));
        }

        [Test]
        public void Execute_WithEmptyArguments_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => acoshFunction.Execute(Args));
        }
    }
}
