﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeEqualityComparerTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System;

    using FluentAssertions;

    using Xunit;

    public static class DateTimeEqualityComparerTest
    {
        [Fact]
        public static void Equals___Should_return_true___When_both_items_are_the_same_object_reference()
        {
            // Arrange
            var systemUnderTest = new DateTimeEqualityComparer();

            var utcDateTime = DateTime.UtcNow;
            var localDateTime = DateTime.Now;
            var unspecifiedDateTime = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);

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
        public static void Equals___Should_return_true___When_item1_and_item2_have_the_same_Ticks_and_same_Kind()
        {
            // Arrange
            var systemUnderTest = new DateTimeEqualityComparer();

            var item1a = DateTime.UtcNow;
            var item1b = new DateTime(item1a.Ticks, item1a.Kind);

            var item2a = DateTime.Now;
            var item2b = new DateTime(item2a.Ticks, item2a.Kind);

            var item3a = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);
            var item3b = new DateTime(item3a.Ticks, item3a.Kind);

            // Act
            var actual1 = systemUnderTest.Equals(item1a, item1b);
            var actual2 = systemUnderTest.Equals(item2a, item2b);
            var actual3 = systemUnderTest.Equals(item3a, item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_item1_and_item2_have_different_Ticks_and_same_Kind()
        {
            // Arrange
            var systemUnderTest = new DateTimeEqualityComparer();

            var utcDateTime1 = DateTime.UtcNow;
            var localDateTime1 = DateTime.Now;
            var unspecifiedDateTime1 = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);

            var utcDateTime2 = utcDateTime1.AddTicks(1);
            var localDateTime2 = localDateTime1.AddTicks(1);
            var unspecifiedDateTime2 = unspecifiedDateTime1.AddTicks(1);

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
            var systemUnderTest = new DateTimeEqualityComparer();

            var utcDateTime = DateTime.UtcNow;
            var localDateTime = new DateTime(utcDateTime.Ticks, DateTimeKind.Local);
            var unspecifiedDateTime = new DateTime(utcDateTime.Ticks, DateTimeKind.Unspecified);

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
        public static void GetHashCode___Should_return_same_hash_code___When_called_twice_on_same_object_reference()
        {
            // Arrange
            var dateTime = DateTime.UtcNow;
            var systemUnderTest = new DateTimeEqualityComparer();

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
            var item1a = DateTime.UtcNow;
            var item1b = item1a.AddTicks(1);

            var item2a = DateTime.Now;
            var item2b = item2a.AddTicks(1);

            var item3a = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);
            var item3b = item3a.AddTicks(1);

            var item4a = DateTime.UtcNow;
            var item4b = new DateTime(item4a.Ticks, DateTimeKind.Local);

            var item5a = DateTime.UtcNow;
            var item5b = new DateTime(item5a.Ticks, DateTimeKind.Unspecified);

            var item6a = DateTime.Now;
            var item6b = new DateTime(item6a.Ticks, DateTimeKind.Unspecified);

            var systemUnderTest = new DateTimeEqualityComparer();

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
            var item1 = DateTime.UtcNow;
            var item2 = new DateTime(item1.Ticks, item1.Kind);

            var systemUnderTest = new DateTimeEqualityComparer();

            // Act
            var hash1 = systemUnderTest.GetHashCode(item1);
            var hash2 = systemUnderTest.GetHashCode(item2);

            // Assert
            hash1.Should().Be(hash2);
        }
    }
}
