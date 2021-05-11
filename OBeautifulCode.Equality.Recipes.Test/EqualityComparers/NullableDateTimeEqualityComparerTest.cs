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
    }
}
