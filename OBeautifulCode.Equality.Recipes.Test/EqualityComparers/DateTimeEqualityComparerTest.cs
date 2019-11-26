// --------------------------------------------------------------------------------------------------------------------
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
        public static void Equals___Should_return_true___When_item1_and_item2_have_the_same_Ticks_and_same_Kind()
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
    }
}
