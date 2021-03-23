// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ByteArrayEqualityComparerTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System;
    using System.Linq;

    using FakeItEasy;

    using FluentAssertions;

    using OBeautifulCode.AutoFakeItEasy;

    using Xunit;

    public static class ByteArrayEqualityComparerTest
    {
        [Fact]
        public static void Equals___Should_return_true___When_both_arrays_are_null()
        {
            // Arrange
            byte[] byteArray1 = null;
            byte[] byteArray2 = null;
            var systemUnderTest = new ByteArrayEqualityComparer();

            // Act
            var result = systemUnderTest.Equals(byteArray1, byteArray2);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_one_byte_array_is_null_and_the_other_is_not_null()
        {
            // Arrange
            byte[] byteArray1 = null;
            var byteArray2 = Some.Dummies<byte>().ToArray();
            var systemUnderTest = new ByteArrayEqualityComparer();

            // Act
            var result1 = systemUnderTest.Equals(byteArray1, byteArray2);
            var result2 = systemUnderTest.Equals(byteArray2, byteArray1);

            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_both_bytes_arrays_are_the_same_object_reference()
        {
            // Arrange
            var byteArray = Some.Dummies<byte>().ToArray();
            var systemUnderTest = new ByteArrayEqualityComparer();

            // Act
            var result = systemUnderTest.Equals(byteArray, byteArray);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_byte_arrays_are_different()
        {
            // Arrange
            var byteArray1a = Some.Dummies<byte>().ToArray();
            var byteArray1b = byteArray1a.Concat(new[] { A.Dummy<byte>() }).ToArray();

            var byteArray2a = Some.Dummies<byte>().ToArray();
            var byteArray2b = new[] { A.Dummy<byte>() }.Concat(byteArray2a).ToArray();

            var byteArray3a = Some.Dummies<byte>(5).ToArray();
            var byteArray3b = Some.Dummies<byte>(5).ToArray();

            var systemUnderTest = new ByteArrayEqualityComparer();

            // Act
            var result1 = systemUnderTest.Equals(byteArray1a, byteArray1b);
            var result2 = systemUnderTest.Equals(byteArray2a, byteArray2b);
            var result3 = systemUnderTest.Equals(byteArray3a, byteArray3b);

            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
            result3.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_byte_arrays_are_equal_but_not_the_same_object_reference()
        {
            // Arrange
            var byteArray1 = Some.Dummies<byte>().ToArray();
            var byteArray2 = new byte[byteArray1.Length];
            Buffer.BlockCopy(byteArray1, 0, byteArray2, 0, byteArray1.Length);

            var systemUnderTest = new ByteArrayEqualityComparer();

            // Act
            var result = systemUnderTest.Equals(byteArray1, byteArray2);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public static void GetHashCode___Should_not_throw___When_byte_array_is_null()
        {
            // Arrange
            var systemUnderTest = new ByteArrayEqualityComparer();

            // Act
            var hash = Record.Exception(() => systemUnderTest.GetHashCode(null));

            // Assert
            hash.Should().BeNull();
        }

        [Fact]
        public static void GetHashCode___Should_return_same_hash_code___When_called_twice_with_null()
        {
            // Arrange
            var systemUnderTest = new ByteArrayEqualityComparer();

            // Act
            var hash1 = Record.Exception(() => systemUnderTest.GetHashCode(null));
            var hash2 = Record.Exception(() => systemUnderTest.GetHashCode(null));

            // Assert
            hash1.Should().Be(hash2);
        }

        [Fact]
        public static void GetHashCode___Should_return_same_hash_code___When_called_twice_on_same_object_reference()
        {
            // Arrange
            var byteArray = Some.Dummies<byte>().ToArray();
            var systemUnderTest = new ByteArrayEqualityComparer();

            // Act
            var hash1 = systemUnderTest.GetHashCode(byteArray);
            var hash2 = systemUnderTest.GetHashCode(byteArray);

            // Assert
            hash1.Should().Be(hash2);
        }

        [Fact]
        public static void GetHashCode___Should_return_different_hash_code___For_different_byte_arrays()
        {
            // Arrange
            var byteArray1a = Some.Dummies<byte>().ToArray();
            var byteArray1b = byteArray1a.Concat(new[] { A.Dummy<byte>() }).ToArray();

            var byteArray2a = Some.Dummies<byte>().ToArray();
            var byteArray2b = new[] { A.Dummy<byte>() }.Concat(byteArray2a).ToArray();

            var byteArray3a = Some.Dummies<byte>(5).ToArray();
            var byteArray3b = Some.Dummies<byte>(5).ToArray();

            var systemUnderTest = new ByteArrayEqualityComparer();

            // Act
            var hash1a = systemUnderTest.GetHashCode(byteArray1a);
            var hash1b = systemUnderTest.GetHashCode(byteArray1b);
            var hash2a = systemUnderTest.GetHashCode(byteArray2a);
            var hash2b = systemUnderTest.GetHashCode(byteArray2b);
            var hash3a = systemUnderTest.GetHashCode(byteArray3a);
            var hash3b = systemUnderTest.GetHashCode(byteArray3b);

            // Assert
            hash1a.Should().NotBe(hash1b);
            hash2a.Should().NotBe(hash2b);
            hash3a.Should().NotBe(hash3b);
        }

        [Fact]
        public static void GetHashCode___Should_return_same_hash_code___For_two_byte_arrays_that_are_equal()
        {
            // Arrange
            var byteArray1 = Some.Dummies<byte>().ToArray();
            var byteArray2 = new byte[byteArray1.Length];
            Buffer.BlockCopy(byteArray1, 0, byteArray2, 0, byteArray1.Length);

            var systemUnderTest = new ByteArrayEqualityComparer();

            // Act
            var hash1 = systemUnderTest.GetHashCode(byteArray1);
            var hash2 = systemUnderTest.GetHashCode(byteArray2);

            // Assert
            hash1.Should().Be(hash2);
        }
    }
}
