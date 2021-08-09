// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceEqualityComparerTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System;
    using System.Linq;

    using FluentAssertions;

    using OBeautifulCode.AutoFakeItEasy;

    using Xunit;

    public static class ReferenceEqualityComparerTest
    {
        [Fact]
        public static void Equals___Should_return_true___When_both_objects_are_null()
        {
            // Arrange
            object item1 = null;
            object item2 = null;
            var systemUnderTest = new ReferenceEqualityComparer<object>();

            // Act
            var actual = systemUnderTest.Equals(item1, item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_one_object_is_null_and_the_other_is_not_null()
        {
            // Arrange
            var item1a = new Version();
            Version item1b = null;

            Version item2a = null;
            var item2b = new Version();

            var systemUnderTest = new ReferenceEqualityComparer<Version>();

            // Act
            var actual1 = systemUnderTest.Equals(item1a, item1b);
            var actual2 = systemUnderTest.Equals(item2a, item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_false___When_objects_are_not_the_same_reference_and_not_equal()
        {
            // Arrange
            var item1 = new object();
            var item2 = new object();

            var systemUnderTest = new ReferenceEqualityComparer<object>();

            // Act
            var actual = systemUnderTest.Equals(item1, item2);

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_false___When_objects_are_not_the_same_reference_and_equal()
        {
            // Arrange
            var item1 = new Version(1, 2, 3, 4);
            var item2 = new Version(1, 2, 3, 4);

            var systemUnderTest = new ReferenceEqualityComparer<object>();

            // Act
            var actual = systemUnderTest.Equals(item1, item2);

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_both_objects_are_the_same_reference()
        {
            // Arrange
            var item = Some.Dummies<byte>().ToArray();
            var systemUnderTest = new ReferenceEqualityComparer<byte[]>();

            // Act
            var actual = systemUnderTest.Equals(item, item);

            // Assert
            actual.Should().BeTrue();
        }
    }
}
