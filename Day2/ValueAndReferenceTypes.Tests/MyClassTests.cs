using Xunit;

namespace ValueAndReferenceTypes.Tests
{
    public class ValueAndReferenceTypesTests
    {
        // TODO: [TASK] This unit test failed because SetStructValue method doesn't work properly. Modify the method to make it work as SetClassValue method.
        [Theory]
        [InlineData(123, 234)]
        public void SetStructValue_ValueFieldIsSet(int myStructValue, int argument)
        {
            // Arrange
            var myStruct = new MyStruct
            {
                Value = myStructValue
            };

            // Act
            MyClass.SetStructValue(myStruct, argument);

            // Assert
            Assert.Equal(argument, myStruct.Value);
        }

        [Theory]
        [InlineData(123, 234)]
        public void SetClassValue_ValueFieldIsSet(int myClassValue, int argument)
        {
            // Arrange
            var myClass = new MyClass
            {
                Value = myClassValue
            };

            // Act
            MyClass.SetClassValue(myClass, argument);

            // Assert
            Assert.Equal(argument, myClass.Value);
        }
    }
}
