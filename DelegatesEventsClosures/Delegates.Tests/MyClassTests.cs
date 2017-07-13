using Xunit;

namespace Delegates.Tests
{
    public class MyClassTests
    {
        [Fact]
        public void MyUsageMethod1_ReturnsDelegate()
        {
            var @delegate = MyClass.MyUsageMethod1();
            var result = @delegate();

            Assert.Equal(0, result);
        }
    }
}
