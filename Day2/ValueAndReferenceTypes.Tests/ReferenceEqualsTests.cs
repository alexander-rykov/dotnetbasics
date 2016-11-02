using System;
using Xunit;

namespace ValueAndReferenceTypes.Tests
{
    public class ReferenceEqualsTests
    {
        [Fact]
        public void ReferenceEquals_WithSameStructs_ReturnsTrue()
        {
            var s = new MyStruct();

            Assert.Equal(true, Object.ReferenceEquals(s, s));
        }

        [Fact]
        public void ReferenceEquals_WithTwoStructs_ReturnsFalse()
        {
            var s1 = new MyStruct { Value = 1 };
            var s2 = new MyStruct { Value = 1 };

            Assert.Equal(false, Object.ReferenceEquals(s1, s2));
        }

        [Fact]
        public void ReferenceEquals_WithSameClasses_ReturnsTrue()
        {
            var c = new MyClass();

            Assert.Equal(true, Object.ReferenceEquals(c, c));
        }

        [Fact]
        public void ReferenceEquals_WithTwoClasses_ReturnsFalse()
        {
            var c1 = new MyClass { Value = 1 };
            var c2 = new MyClass { Value = 1 };

            Assert.Equal(false, Object.ReferenceEquals(c1, c2));
        }

        [Fact]
        public void ReferenceEquals_WithSameAnonymousClasses_ReturnsTrue()
        {
            var c = new { Value = 1 };

            Assert.Equal(true, Object.ReferenceEquals(c, c));
        }

        [Fact]
        public void ReferenceEquals_WithTwoAnonymousClasses_ReturnsFalse()
        {
            var c1 = new { Value = 1 };
            var c2 = new { Value = 1 };

            Assert.Equal(false, Object.ReferenceEquals(c1, c2));
        }
    }
}
