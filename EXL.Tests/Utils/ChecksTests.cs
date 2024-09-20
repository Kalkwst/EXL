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
            Assert.Throws<InvalidCastException>(() => Checks.CanConvertToDouble("invalid", "Exception Message", out var result));
        }

        [Test]
        public void CanConvertToDouble_WithNonNumericObject_ThrowsInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Checks.CanConvertToDouble(new object(), "Exception Message", out var result));
        }

        [Test]
        public void TryConvertToDouble_WithValidDoubleString_ReturnsTrue()
        {
            var success = Checks.TryConvertToDouble("123.45", out var result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.EqualTo(123.45));
            });
        }

        [Test]
        public void TryConvertToDouble_WithValidIntString_ReturnsTrue()
        {
            var success = Checks.TryConvertToDouble("123", out var result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.EqualTo(123));
            });
        }

        [Test]
        public void TryConvertToDouble_WithInvalidString_ReturnsFalse()
        {
            var success = Checks.TryConvertToDouble("invalid", out var result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.False);
                Assert.That(result, Is.EqualTo(0));
            });
        }

        [Test]
        public void TryConvertToDouble_WithNullValue_ReturnsFalse()
        {
            var success = Checks.TryConvertToDouble(null, out var result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.False);
                Assert.That(result, Is.EqualTo(0));
            });
        }

        [Test]
        public void TryConvertToDouble_WithNonNumericObject_ReturnsFalse()
        {
            var success = Checks.TryConvertToDouble(new object(), out var result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.False);
                Assert.That(result, Is.EqualTo(0));
            });
        }
    }
}
