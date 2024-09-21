using EXL.Functions.Mathematical;

namespace EXL.Tests.Functions.Mathematical
{
    [TestFixture]
    internal class AcosFunctionTests
    {
        private AcosFunction acosFunction;
        internal static readonly object[] args = [];

        [SetUp]
        public void SetUp()
        {
            acosFunction = new AcosFunction();
        }

        [Test]
        public void Execute_WithValidNumber_ReturnsAcosValue()
        {
            var result = acosFunction.Execute([0.5]);
            Assert.That(result, Is.EqualTo(Math.Acos(0.5)));
        }

        [Test]
        public void Execute_WithNumberOutOfRange_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => acosFunction.Execute([2]));
        }

        [Test]
        public void Execute_WithInvalidType_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => acosFunction.Execute(["invalid"]));
        }

        [Test]
        public void Execute_WithMultipleArguments_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => acosFunction.Execute([0.5, 0.5]));
        }

        [Test]
        public void Execute_WithEmptyArguments_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => acosFunction.Execute(args));
        }
    }
}
