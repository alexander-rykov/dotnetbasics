using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UsingDelegates.Tests
{
    // NOTE This test class uses MethodName_StateUnderTest_ExpectedBehavior notation for naming test methods.
    // See more: https://dzone.com/articles/7-popular-unit-test-naming
    [TestClass]
    public class MyActionClassTests
    {
        [TestMethod]
        public void SetOneTwoThree_WithoutArguments_SetOneTwoThree()
        {
            // Arrange
            MyActionClass actionClass = new MyActionClass();
            Action action = new Action(actionClass.SetOneTwoThree);

            // Act
            action();

            // Assert
            Assert.AreEqual(123, actionClass.Result);
        }

        [TestMethod]
        public void SetResult_WithTwoThreeFour_SetOneTwoThree()
        {
            // Arrange
            MyActionClass actionClass = new MyActionClass();
            // TODO Create an action for the method under the test.

            // Act
            // TODO Call the action with parameters.

            // Assert
            Assert.AreEqual(234, actionClass.Result);
        }

        [TestMethod]
        public void SubtractAndSet_WithFourThree_SetOne()
        {
            // Arrange
            MyActionClass actionClass = new MyActionClass();
            // TODO Create an action for the method under the test.

            // Act
            // TODO Call the action with parameters.

            // Assert
            Assert.AreEqual(1, actionClass.Result);
        }

        [TestMethod]
        public void SubtractAndSet_WithThreeFour_SetMinusOne()
        {
            // Arrange
            MyActionClass actionClass = new MyActionClass();
            // TODO Create an action for the method under the test.

            // Act
            // TODO Call the action with parameters.

            // Assert
            Assert.AreEqual(-1, actionClass.Result);
        }

        [TestMethod]
        public void SumAndSet_WithOneTwoThree_SetSix()
        {
            // Arrange
            MyActionClass actionClass = new MyActionClass();
            // TODO Create an action for the method under the test.

            // Act
            // TODO Call the action with parameters.

            // Assert
            Assert.AreEqual(6, actionClass.Result);
        }

        [TestMethod]
        public void MultiplyAndSet_WithOneTwoMinusOneTwo_SetMinusFour()
        {
            // Arrange
            MyActionClass actionClass = new MyActionClass();
            // TODO Create an action for the method under the test.

            // Act
            // TODO Call the action with parameters.

            // Assert
            Assert.AreEqual(-4, actionClass.Result);
        }
    }
}
