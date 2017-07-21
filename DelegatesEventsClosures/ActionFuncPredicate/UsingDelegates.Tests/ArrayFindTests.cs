using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UsingDelegates.Tests
{
    // NOTE This test class uses Should_ExpectedBehavior_When_StateUnderTest notation for naming test methods.
    // See more: https://dzone.com/articles/7-popular-unit-test-naming
    [TestClass]
    public class ArrayFindTests
    {
        private int[] _intArray;
        private char[] _charArray;

        [TestInitialize]
        public void TestInitialize()
        {
            _intArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _charArray = new[] { 'a', 'c', 'k', 'z', 'f', 'o' };
        }

        [TestMethod]
        public void Should_ReturnFour_When_ArrayHasFour()
        {
            // Arrange
            // TODO Use anonymous method syntax (delegate (i) {...}) to create a new delegate that compares "i == 4". Change type of the predicate.
            Predicate<object> predicate;

            // Act
            // TODO Pass a predicate as a parameter.
            int result = Array.Find(_intArray, null);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Should_ReturnDefaultChar_When_CharIsNotInArray()
        {
            // Arrange
            // TODO Use anonymous method syntax (delegate (c) {...}) to create a new delegate that compares "c == 'j'". Change type of the predicate.
            Predicate<object> predicate;

            // Act
            // TODO Pass a predicate as a parameter.
            char result = Array.Find(_charArray, null);

            // Assert
            Assert.AreEqual(default(char), result);
        }

        [TestMethod]
        public void Should_ReturnFourElements_When_FindEven()
        {
            // Arrange
            // TODO Use lambda statement syntax ((i) => {...}) to create a new delegate that compares "(i % 2) == 0". Change type of the predicate.
            Predicate<object> isEven;

            // Act
            // TODO Pass a predicate as a parameter.
            var result = Array.FindAll(_intArray, null);

            // Assert
            Assert.AreEqual(4, result.Length);
        }

        [TestMethod]
        public void Should_ReturnSixElements_When_FindOdd()
        {
            // Arrange
            // TODO Use lambda syntax (i => ...) to create a new delegate that compares "(i % 2) != 0". Change type of the predicate.
            Predicate<object> isOdd;

            // Act
            // TODO Pass a predicate as a parameter.
            var result = Array.FindAll(_intArray, null);

            // Assert
            Assert.AreEqual(6, result.Length);
        }
    }
}
