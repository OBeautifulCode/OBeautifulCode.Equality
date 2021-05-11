// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectEqualityComparerTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using OBeautifulCode.AutoFakeItEasy;

    using Xunit;

    public static class ObjectEqualityComparerTest
    {
        [Fact]
        public static void Equals___Should_return_true___When_both_objects_are_null()
        {
            // Arrange
            object item1 = null;
            object item2 = null;
            var systemUnderTest = new ObjectEqualityComparer();

            // Act
            var actual = systemUnderTest.Equals(item1, item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_one_object_is_null_and_the_other_is_not_null()
        {
            // Arrange
            object item1a = new Version();
            object item1b = null;

            object item2a = null;
            object item2b = new Version();

            var systemUnderTest = new ObjectEqualityComparer();

            // Act
            var actual1 = systemUnderTest.Equals(item1a, item1b);
            var actual2 = systemUnderTest.Equals(item2a, item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_both_objects_are_the_same_object_reference()
        {
            // Arrange
            object item = Some.Dummies<byte>().ToArray();
            var systemUnderTest = new ObjectEqualityComparer();

            // Act
            var actual = systemUnderTest.Equals(item, item);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_objects_have_different_runtime_types()
        {
            // Arrange
            object item1 = Some.Dummies<byte>().ToArray();
            object item2 = new object();

            var systemUnderTest = new ObjectEqualityComparer();

            // Act
            var actual1 = systemUnderTest.Equals(item1, item2);
            var actual2 = systemUnderTest.Equals(item2, item1);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_objects_runtime_types_are_object()
        {
            // Arrange
            var item1 = new object();
            var item2 = new object();

            var systemUnderTest = new ObjectEqualityComparer();

            // Act
            var actual = systemUnderTest.Equals(item1, item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_true___When_objects_are_equal_using_runtime_types_as_declared_type()
        {
            // Arrange
            var item1 = new List<string> { "abc", null, "def" };
            var item2 = new List<string> { "abc", null, "def" };

            var systemUnderTest = new ObjectEqualityComparer();

            // Act
            var actual = systemUnderTest.Equals(item1, item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_true___When_objects_are_not_equal_using_runtime_types_as_declared_type()
        {
            // Arrange
            var item1 = new List<string> { "abc", null, "def" };
            var item2 = new List<string> { "abc", null };

            var systemUnderTest = new ObjectEqualityComparer();

            // Act
            var actual = systemUnderTest.Equals(item1, item2);

            // Assert
            actual.Should().BeFalse();
        }
    }
}
