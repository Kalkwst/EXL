using EXL.Utils;

namespace EXL.Tests.Utils
{
    [TestFixture]
    public class ChecksTests
    {
        [Test]
        public void CanConvertToDouble_WithValidDoubleString_ReturnsTrue()
        {
            double result = 0;
            Assert.DoesNotThrow(() => Checks.CanConvertToDouble("123.45", out result));
            Assert.That(result, Is.EqualTo(123.45));
        }

        [Test]
        public void CanConvertToDouble_WithValidIntString_ReturnsTrue()
        {
            double result = 0;
            Assert.DoesNotThrow(() => Checks.CanConvertToDouble("123", out result));
            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void CanConvertToDouble_WithInvalidString_ThrowsInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Checks.CanConvertToDouble("invalid", out double result));
        }

        [Test]
        public void CanConvertToDouble_WithNullValue_ThrowsInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Checks.CanConvertToDouble(null, out double result));
        }

        [Test]
        public void CanConvertToDouble_WithNonNumericObject_ThrowsInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Checks.CanConvertToDouble(new object(), out double result));
        }
    }
}
