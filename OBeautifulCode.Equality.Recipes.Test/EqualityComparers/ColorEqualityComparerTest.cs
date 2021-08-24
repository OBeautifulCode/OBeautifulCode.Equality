// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorEqualityComparerTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System.Drawing;

    using FluentAssertions;

    using Xunit;

    public static class ColorEqualityComparerTest
    {
        [Fact]
        public static void Equals___Should_return_true___When_both_items_are_the_same_object_reference()
        {
            // Arrange
            var systemUnderTest = new ColorEqualityComparer();

            var item1 = Color.FromArgb(255, 218, 185);
            var item2 = Color.PeachPuff;

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
            var systemUnderTest = new ColorEqualityComparer();

            var item1 = Color.FromArgb(255, 255, 218, 185);
            var item2 = Color.FromArgb(255, 218, 185);
            var item3 = Color.PeachPuff;

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
            var systemUnderTest = new ColorEqualityComparer();

            var item1 = Color.FromArgb(255, 255, 218, 185);
            var item2 = Color.FromArgb(254, 255, 218, 185);
            var item3 = Color.FromArgb(255, 254, 218, 185);
            var item4 = Color.FromArgb(255, 255, 219, 185);
            var item5 = Color.FromArgb(255, 255, 218, 184);

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
        public static void GetHashCode___Should_return_same_hash_code___When_called_twice_on_same_object_reference()
        {
            // Arrange
            var item1 = Color.FromArgb(255, 218, 185);
            var item2 = Color.PeachPuff;

            var systemUnderTest = new ColorEqualityComparer();

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
            var item1 = Color.FromArgb(255, 255, 218, 185);
            var item2 = Color.FromArgb(254, 255, 218, 185);
            var item3 = Color.FromArgb(255, 254, 218, 185);
            var item4 = Color.FromArgb(255, 255, 219, 185);
            var item5 = Color.FromArgb(255, 255, 218, 184);

            var systemUnderTest = new ColorEqualityComparer();

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
            var item1 = Color.FromArgb(255, 255, 218, 185);
            var item2 = Color.FromArgb(255, 218, 185);
            var item3 = Color.PeachPuff;

            var systemUnderTest = new ColorEqualityComparer();

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
