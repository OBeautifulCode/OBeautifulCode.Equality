// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullableColorEqualityComparerTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System.Drawing;

    using FluentAssertions;

    using Xunit;

    public static class NullableColorEqualityComparerTest
    {
        [Fact]
        public static void Equals___Should_return_true___When_item1_and_item2_are_null()
        {
            // Arrange
            var systemUnderTest = new NullableColorEqualityComparer();

            Color? item1 = null;
            Color? item2 = null;

            // Act
            var actual = systemUnderTest.Equals(item1, item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_item1_is_null_and_item2_is_not_or_vice_versa()
        {
            // Arrange
            var systemUnderTest = new NullableColorEqualityComparer();

            Color? item1a = null;
            Color? item1b = Color.PeachPuff;

            Color? item2a = Color.PeachPuff;
            Color? item2b = null;

            // Act
            var actual1 = systemUnderTest.Equals(item1a, item1b);
            var actual2 = systemUnderTest.Equals(item2a, item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_both_items_are_the_same_object_reference()
        {
            // Arrange
            var systemUnderTest = new NullableColorEqualityComparer();

            Color? item1 = Color.FromArgb(255, 218, 185);
            Color? item2 = Color.PeachPuff;

            // Act
            var actual1 = systemUnderTest.Equals(item1, item1);
            var actual2 = systemUnderTest.Equals(item2, item2);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_true___When_item1_and_item2_have_the_same_ARGB()
        {
            // Arrange
            var systemUnderTest = new NullableColorEqualityComparer();

            Color? item1 = Color.FromArgb(255, 255, 218, 185);
            Color? item2 = Color.FromArgb(255, 218, 185);
            Color? item3 = Color.PeachPuff;

            // Act
            var actual1 = systemUnderTest.Equals(item1, item2);
            var actual2 = systemUnderTest.Equals(item1, item3);
            var actual3 = systemUnderTest.Equals(item2, item3);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_item1_and_item2_have_different_ARGB()
        {
            // Arrange
            var systemUnderTest = new NullableColorEqualityComparer();

            Color? item1 = Color.FromArgb(255, 255, 218, 185);
            Color? item2 = Color.FromArgb(254, 255, 218, 185);
            Color? item3 = Color.FromArgb(255, 254, 218, 185);
            Color? item4 = Color.FromArgb(255, 255, 219, 185);
            Color? item5 = Color.FromArgb(255, 255, 218, 184);

            // Act
            var actual1 = systemUnderTest.Equals(item1, item2);
            var actual2 = systemUnderTest.Equals(item1, item3);
            var actual3 = systemUnderTest.Equals(item1, item4);
            var actual4 = systemUnderTest.Equals(item1, item5);
            var actual5 = systemUnderTest.Equals(item2, item3);
            var actual6 = systemUnderTest.Equals(item2, item4);
            var actual7 = systemUnderTest.Equals(item2, item5);
            var actual8 = systemUnderTest.Equals(item3, item4);
            var actual9 = systemUnderTest.Equals(item3, item5);
            var actual10 = systemUnderTest.Equals(item4, item5);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
            actual6.Should().BeFalse();
            actual7.Should().BeFalse();
            actual8.Should().BeFalse();
            actual9.Should().BeFalse();
            actual10.Should().BeFalse();
        }

        [Fact]
        public static void GetHashCode___Should_not_throw___When_Nullable_Color_is_null()
        {
            // Arrange
            var systemUnderTest = new NullableColorEqualityComparer();

            // Act
            var hash = Record.Exception(() => systemUnderTest.GetHashCode(null));

            // Assert
            hash.Should().BeNull();
        }

        [Fact]
        public static void GetHashCode___Should_return_same_hash_code___When_called_twice_with_null()
        {
            // Arrange
            var systemUnderTest = new NullableColorEqualityComparer();

            // Act
            var hash1 = systemUnderTest.GetHashCode(null);
            var hash2 = systemUnderTest.GetHashCode(null);

            // Assert
            hash1.Should().Be(hash2);
        }

        [Fact]
        public static void GetHashCode___Should_return_same_hash_code___When_called_twice_on_same_object_reference()
        {
            // Arrange
            Color? item1 = Color.FromArgb(255, 218, 185);
            Color? item2 = Color.PeachPuff;

            var systemUnderTest = new NullableColorEqualityComparer();

            // Act
            var hash1a = systemUnderTest.GetHashCode(item1);
            var hash1b = systemUnderTest.GetHashCode(item1);

            var hash2a = systemUnderTest.GetHashCode(item2);
            var hash2b = systemUnderTest.GetHashCode(item2);

            // Assert
            hash1a.Should().Be(hash1b);
            hash2a.Should().Be(hash2b);
        }

        [Fact]
        public static void GetHashCode___Should_return_different_hash_code___For_different_Color_objects()
        {
            // Arrange
            Color? item1 = Color.FromArgb(255, 255, 218, 185);
            Color? item2 = Color.FromArgb(254, 255, 218, 185);
            Color? item3 = Color.FromArgb(255, 254, 218, 185);
            Color? item4 = Color.FromArgb(255, 255, 219, 185);
            Color? item5 = Color.FromArgb(255, 255, 218, 184);

            var systemUnderTest = new NullableColorEqualityComparer();

            // Act
            var hash1 = systemUnderTest.GetHashCode(item1);
            var hash2 = systemUnderTest.GetHashCode(item2);
            var hash3 = systemUnderTest.GetHashCode(item3);
            var hash4 = systemUnderTest.GetHashCode(item4);
            var hash5 = systemUnderTest.GetHashCode(item5);

            // Assert
            hash1.Should().NotBe(hash2);
            hash1.Should().NotBe(hash3);
            hash1.Should().NotBe(hash4);
            hash1.Should().NotBe(hash5);
            hash2.Should().NotBe(hash3);
            hash2.Should().NotBe(hash4);
            hash2.Should().NotBe(hash5);
            hash3.Should().NotBe(hash4);
            hash3.Should().NotBe(hash5);
            hash4.Should().NotBe(hash5);
        }

        [Fact]
        public static void GetHashCode___Should_return_same_hash_code___For_Color_objects_that_are_equal()
        {
            // Arrange
            Color? item1 = Color.FromArgb(255, 255, 218, 185);
            Color? item2 = Color.FromArgb(255, 218, 185);
            Color? item3 = Color.PeachPuff;

            var systemUnderTest = new NullableColorEqualityComparer();

            // Act
            var hash1 = systemUnderTest.GetHashCode(item1);
            var hash2 = systemUnderTest.GetHashCode(item2);
            var hash3 = systemUnderTest.GetHashCode(item3);

            // Assert
            hash1.Should().Be(hash2);
            hash2.Should().Be(hash3);
        }
    }
}
