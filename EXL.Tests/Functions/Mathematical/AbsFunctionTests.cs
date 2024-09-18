using EXL.Functions.Mathematical;

namespace EXL.Tests.Functions.Mathematical
{
    [TestFixture]
    public class AbsFunctionTests
    {
        private AbsFunction _absFunction;

        [SetUp]
        public void SetUp()
        {
            _absFunction = new AbsFunction();
        }

        [Test]
        public void Execute_WithSingleDoubleValue_ReturnsAbsoluteValue()
        {
            var result = _absFunction.Execute(-5.5);
            Assert.That(result, Is.EqualTo(5.5));
        }

        [Test]
        public void Execute_WithSingleIntValue_ReturnsAbsoluteValue()
        {
            var result = _absFunction.Execute(-5);
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void Execute_WithArray_ReturnsArrayOfAbsoluteValues()
        {
            var result = _absFunction.Execute(new double[] { -1.0, -2.5, 3.0 }) as double[];
            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new double[] { 1.0, 2.5, 3.0 }, result);
        }

        [Test]
        public void Execute_WithInvalidType_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _absFunction.Execute("invalid"));
        }

        [Test]
        public void Execute_WithMultipleArguments_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _absFunction.Execute(1, 2));
        }

        [Test]
        public void Execute_WithEmptyArguments_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _absFunction.Execute());
        }
    }
}
