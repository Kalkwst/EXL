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
            Assert.DoesNotThrow(() => Checks.CanConvertToDouble("123.45", "Exception Message", out result));
            Assert.That(result, Is.EqualTo(123.45));
        }

        [Test]
        public void CanConvertToDouble_WithValidIntString_ReturnsTrue()
        {
            double result = 0;
            Assert.DoesNotThrow(() => Checks.CanConvertToDouble("123", "Exception Message", out result));
            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void CanConvertToDouble_WithInvalidString_ThrowsInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Checks.CanConvertToDouble("invalid", "Exception Message", out double result));
        }

        [Test]
        public void CanConvertToDouble_WithNonNumericObject_ThrowsInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Checks.CanConvertToDouble(new object(), "Exception Message", out double result));
        }
    }
}
