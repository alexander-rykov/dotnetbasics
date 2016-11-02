using Xunit;

namespace ValueAndReferenceTypes.Tests
{
    public class InstanceEqualsTests
    {
        [Fact]
        public void InstanceEquals_WithSameStructs_ReturnsTrue()
        {
            var s = new MyStruct();

            Assert.Equal(true, s.Equals(s));
        }

        [Fact]
        public void InstanceEquals_WithTwoStructs_ReturnsFalse()
        {
            var s1 = new MyStruct { Value = 1 };
            var s2 = new MyStruct { Value = 1 };

            Assert.Equal(false, s1.Equals(s2));
        }

        [Fact]
        public void InstanceEquals_WithSameClasses_ReturnsTrue()
        {
            var c = new MyClass();

            Assert.Equal(true, c.Equals(c));
        }

        [Fact]
        public void InstanceEquals_WithTwoClasses_ReturnsTrue()
        {
            var c1 = new MyClass { Value = 1 };
            var c2 = new MyClass { Value = 1 };

            Assert.Equal(true, c1.Equals(c2));
        }

        [Fact]
        public void InstanceEquals_WithSameAnonymousClasses_ReturnsTrue()
        {
            var c = new { Value = 10 };

            Assert.Equal(true, c.Equals(c));
        }

        [Fact]
        public void InstanceEquals_WithTwoAnonymousClasses_ReturnsFalse()
        {
            var c1 = new { Value = 1 };
            var c2 = new { Value = 1 };

            Assert.Equal(false, c1.Equals(c2));
        }
    }
}
