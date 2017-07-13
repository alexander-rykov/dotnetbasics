using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ValueAndReferenceTypes.Tests
{
    public class ClassWithCounterTests
    {
        // TODO: [TASK] This unit test failed. Use dotPeek or ILSpy to find out the problem.
        [Fact]
        public void ClassWithCounter_IncrementFirstCounter_CounterIsIncremented()
        {
            // Arrange
            var classWithCounter = new ClassWithCounter();

            // Act
            classWithCounter.IncrementFirstCounter();

            // Assert
            Assert.Equal(1, classWithCounter.FirstCounter.Value);
        }

        [Fact]
        public void ClassWithCounter_IncrementSecondCounter_CounterIsIncremented()
        {
            // Arrange
            var classWithCounter = new ClassWithCounter();

            // Act
            classWithCounter.IncrementSecondCounter();

            // Assert
            Assert.Equal(1, classWithCounter.SecondCounter.Value);
        }
    }
}
