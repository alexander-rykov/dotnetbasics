using Xunit;

namespace ValueAndReferenceTypes.Tests
{
    public class EqualsOperator
    {
        [Fact]
        public void EqualsOperator_WithSameClasses_ReturnsTrue()
        {
            var c = new MyClass();

            Assert.Equal(true, c == c);
        }

        [Fact]
        public void EqualsOperator_WithTwoClasses_ReturnsTrue()
        {
            var c1 = new MyClass { Value = 1 };
            var c2 = new MyClass { Value = 1 };

            Assert.Equal(true, c1 == c2);
        }

        [Fact]
        public void EqualsOperator_WithSameAnonymousClasses_ReturnsTrue()
        {
            var c = new { Value = 10 };

            Assert.Equal(true, c == c);
        }

        [Fact]
        public void EqualsOperator_WithTwoAnonymousClasses_ReturnsFalse()
        {
            var c1 = new { Value = 1 };
            var c2 = new { Value = 1 };

            Assert.Equal(false, c1 == c2);
        }
    }
}
