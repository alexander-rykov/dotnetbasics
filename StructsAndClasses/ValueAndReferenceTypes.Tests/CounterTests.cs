using System.Linq;
using Xunit;

namespace ValueAndReferenceTypes.Tests
{
    // TODO: [TASK] These unit tests failed. Use dotPeek or ILSpy to find out what the problem.
    public class CounterTests
    {
        [Fact]
        public void IncrementCounters_CounterList_ValuesAreIncremented()
        {
            // Arrange
            var list = Counter.CreateListOfMutableStructs(10);

            // Act
            Counter.IncrementCounters(list);

            // Assert
            Assert.Equal(10, list.Count(i => i.Value > 0));
        }

        [Fact]
        public void DecrementCounters_CounterList_ValuesAreDecremented()
        {
            // Arrange
            var list = Counter.CreateListOfMutableStructs(10);

            // Act
            Counter.DecrementCounters(list);

            // Assert
            Assert.Equal(10, list.Count(i => i.Value < 0));
        }
    }
}
