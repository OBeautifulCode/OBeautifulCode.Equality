// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullableDateTimeEqualityComparerTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System;

    using FluentAssertions;

    using Xunit;

    public static class NullableDateTimeEqualityComparerTest
    {
        [Fact]
        public static void Equals___Should_return_true___When_item1_and_item2_are_null()
        {
            // Arrange
            var systemUnderTest = new NullableDateTimeEqualityComparer();

            DateTime? item1 = null;
            DateTime? item2 = null;

            // Act
            var actual = systemUnderTest.Equals(item1, item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_item1_is_null_and_item2_is_not_or_vice_versa()
        {
            // Arrange
            var systemUnderTest = new NullableDateTimeEqualityComparer();

            DateTime? item1a = null;
            DateTime? item1b = DateTime.UtcNow;

            DateTime? item2a = DateTime.Now;
            DateTime? item2b = null;

            // Act
            var actual1 = systemUnderTest.Equals(item1a, item1b);
            var actual2 = systemUnderTest.Equals(item2a, item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_item1_and_item2_have_the_same_Ticks_and_same_Kind()
        {
            // Arrange
            var systemUnderTest = new NullableDateTimeEqualityComparer();

            DateTime? utcDateTime = DateTime.UtcNow;
            DateTime? localDateTime = DateTime.Now;
            DateTime? unspecifiedDateTime = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);

            // Act
            var actual1 = systemUnderTest.Equals(utcDateTime, utcDateTime);
            var actual2 = systemUnderTest.Equals(localDateTime, localDateTime);
            var actual3 = systemUnderTest.Equals(unspecifiedDateTime, unspecifiedDateTime);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_item1_and_item2_have_different_Ticks_and_same_Kind()
        {
            // Arrange
            var systemUnderTest = new NullableDateTimeEqualityComparer();

            DateTime? utcDateTime1 = DateTime.UtcNow;
            DateTime? localDateTime1 = DateTime.Now;
            DateTime? unspecifiedDateTime1 = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);

            DateTime? utcDateTime2 = ((DateTime)utcDateTime1).AddTicks(1);
            DateTime? localDateTime2 = ((DateTime)localDateTime1).AddTicks(1);
            DateTime? unspecifiedDateTime2 = ((DateTime)unspecifiedDateTime1).AddTicks(1);

            // Act
            var actual1 = systemUnderTest.Equals(utcDateTime1, utcDateTime2);
            var actual2 = systemUnderTest.Equals(localDateTime1, localDateTime2);
            var actual3 = systemUnderTest.Equals(unspecifiedDateTime1, unspecifiedDateTime2);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_false___When_item1_and_item2_have_the_same_Ticks_but_different_Kind()
        {
            // Arrange
            var systemUnderTest = new NullableDateTimeEqualityComparer();

            DateTime? utcDateTime = DateTime.UtcNow;
            DateTime? localDateTime = new DateTime(((DateTime)utcDateTime).Ticks, DateTimeKind.Local);
            DateTime? unspecifiedDateTime = new DateTime(((DateTime)utcDateTime).Ticks, DateTimeKind.Unspecified);

            // Act
            var actual1 = systemUnderTest.Equals(utcDateTime, localDateTime);
            var actual2 = systemUnderTest.Equals(utcDateTime, unspecifiedDateTime);
            var actual3 = systemUnderTest.Equals(localDateTime, unspecifiedDateTime);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void GetHashCode___Should_not_throw___When_Nullable_DateTime_is_null()
        {
            // Arrange
            var systemUnderTest = new NullableDateTimeEqualityComparer();

            // Act
            var hash = Record.Exception(() => systemUnderTest.GetHashCode(null));

            // Assert
            hash.Should().BeNull();
        }

        [Fact]
        public static void GetHashCode___Should_return_same_hash_code___When_called_twice_with_null()
        {
            // Arrange
            var systemUnderTest = new NullableDateTimeEqualityComparer();

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
            DateTime? dateTime = DateTime.UtcNow;
            var systemUnderTest = new NullableDateTimeEqualityComparer();

            // Act
            var hash1 = systemUnderTest.GetHashCode(dateTime);
            var hash2 = systemUnderTest.GetHashCode(dateTime);

            // Assert
            hash1.Should().Be(hash2);
        }

        [Fact]
        public static void GetHashCode___Should_return_different_hash_code___For_different_DateTime_objects()
        {
            // Arrange
            DateTime? item1a = DateTime.UtcNow;
            DateTime? item1b = ((DateTime)item1a).AddTicks(1);

            DateTime? item2a = DateTime.Now;
            DateTime? item2b = ((DateTime)item2a).AddTicks(1);

            DateTime? item3a = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);
            DateTime? item3b = ((DateTime)item3a).AddTicks(1);

            DateTime? item4a = DateTime.UtcNow;
            DateTime? item4b = new DateTime(((DateTime)item4a).Ticks, DateTimeKind.Local);

            DateTime? item5a = DateTime.UtcNow;
            DateTime? item5b = new DateTime(((DateTime)item5a).Ticks, DateTimeKind.Unspecified);

            DateTime? item6a = DateTime.Now;
            DateTime? item6b = new DateTime(((DateTime)item6a).Ticks, DateTimeKind.Unspecified);

            var systemUnderTest = new NullableDateTimeEqualityComparer();

            // Act
            var hash1a = systemUnderTest.GetHashCode(item1a);
            var hash1b = systemUnderTest.GetHashCode(item1b);
            var hash2a = systemUnderTest.GetHashCode(item2a);
            var hash2b = systemUnderTest.GetHashCode(item2b);
            var hash3a = systemUnderTest.GetHashCode(item3a);
            var hash3b = systemUnderTest.GetHashCode(item3b);
            var hash4a = systemUnderTest.GetHashCode(item4a);
            var hash4b = systemUnderTest.GetHashCode(item4b);
            var hash5a = systemUnderTest.GetHashCode(item5a);
            var hash5b = systemUnderTest.GetHashCode(item5b);
            var hash6a = systemUnderTest.GetHashCode(item6a);
            var hash6b = systemUnderTest.GetHashCode(item6b);

            // Assert
            hash1a.Should().NotBe(hash1b);
            hash2a.Should().NotBe(hash2b);
            hash3a.Should().NotBe(hash3b);
            hash4a.Should().NotBe(hash4b);
            hash5a.Should().NotBe(hash5b);
            hash6a.Should().NotBe(hash6b);
        }

        [Fact]
        public static void GetHashCode___Should_return_same_hash_code___For_DateTime_objects_that_are_equal()
        {
            // Arrange
            DateTime? item1 = DateTime.UtcNow;
            DateTime? item2 = new DateTime(((DateTime)item1).Ticks, ((DateTime)item1).Kind);

            var systemUnderTest = new NullableDateTimeEqualityComparer();

            // Act
            var hash1 = systemUnderTest.GetHashCode(item1);
            var hash2 = systemUnderTest.GetHashCode(item2);

            // Assert
            hash1.Should().Be(hash2);
        }
    }
}
