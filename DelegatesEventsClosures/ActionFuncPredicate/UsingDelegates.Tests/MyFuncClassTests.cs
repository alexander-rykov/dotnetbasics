using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UsingDelegates.Tests
{
    // NOTE This test class uses MethodName_ExpectedBehavior_StateUnderTest notation for naming test methods.
    // See more: https://dzone.com/articles/7-popular-unit-test-naming
    [TestClass]
    public class MyFuncClassTests
    {
        [TestMethod]
        public void Zero_ReturnsZero_WithoutArguments()
        {
            // Arrange
            // TODO Create a func delegate variable and tie it with relevant method under the test.

            // Act
            // TODO Modify the next line to invoke func delegate without parameters and save result.
            int result = 0;

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Double_ReturnsZero_WithZero()
        {
            // Arrange
            // TODO Create a func delegate variable and tie it with relevant method under the test.

            // Act
            // TODO Modify the next line to invoke func delegate without parameters and save result.
            string result = string.Empty;

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void Double_ReturnsFour_WithTwo()
        {
            // Arrange
            // TODO Create a func delegate variable and tie it with relevant method under the test.

            // Act
            // TODO Modify the next line to invoke func delegate without parameters and save result.
            string result = string.Empty;

            // Assert
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public void Sum_ReturnsTwo_WithOneOne()
        {
            // Arrange
            // TODO Create a func delegate variable and tie it with relevant method under the test.

            // Act
            // TODO Modify the next line to invoke func delegate without parameters and save result.
            double result = 0.0;

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Sum_ReturnsZero_WithOneMinusOne()
        {
            // Arrange
            // TODO Create a func delegate variable and tie it with relevant method under the test.

            // Act
            // TODO Modify the next line to invoke func delegate without parameters and save result.
            double result = 0.0;

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
