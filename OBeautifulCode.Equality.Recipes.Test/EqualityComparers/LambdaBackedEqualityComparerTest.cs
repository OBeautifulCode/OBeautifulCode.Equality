// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LambdaBackedEqualityComparerTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System;
    using System.Linq;

    using FakeItEasy;

    using FluentAssertions;

    using Xunit;

    public static class LambdaBackedEqualityComparerTest
    {
        [Fact]
        public static void Constructor___Should_throw_ArgumentNullException___When_parameter_equalsFunc_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => new LambdaBackedEqualityComparer<string>(null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("equalsFunc");
        }

        [Fact]
        public static void Equals___Should_return_true___When_equalsFunc_returns_true_for_the_same_inputs()
        {
            // Arrange
            var systemUnderTest = new LambdaBackedEqualityComparer<string>((x, y) => x.First() == y.First());

            // Act
            var actual = systemUnderTest.Equals("abc", "aed");

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_equalsFunc_returns_false_for_the_same_inputs()
        {
            // Arrange
            var systemUnderTest = new LambdaBackedEqualityComparer<string>((x, y) => x.First() == y.First());

            // Act
            var actual = systemUnderTest.Equals("abc", "def");

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void GetHashCode___Should_throw_NotSupportedException___When_constructed_with_null_getHashCodeFunc()
        {
            // Arrange
            var systemUnderTest = new LambdaBackedEqualityComparer<string>((x, y) => x.First() == y.First(), getHashCodeFunc: null);

            // Act
            var actual = Record.Exception(() => systemUnderTest.GetHashCode("abc"));

            // Assert
            actual.Should().BeOfType<NotSupportedException>();
        }

        [Fact]
        public static void GetHashCode___Should_use_getHashCodeFunc___When_called()
        {
            // Arrange
            var hashCode = A.Dummy<int>();

            var systemUnderTest = new LambdaBackedEqualityComparer<string>(
                (x, y) => x.First() == y.First(),
                obj => hashCode);

            // Act
            var actual = systemUnderTest.GetHashCode(A.Dummy<string>());

            // Assert
            actual.Should().Be(hashCode);
        }
    }
}
