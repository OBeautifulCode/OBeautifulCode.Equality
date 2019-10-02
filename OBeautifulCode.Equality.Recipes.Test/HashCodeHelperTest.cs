// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HashCodeHelperTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using FakeItEasy;

    using FluentAssertions;

    using Xunit;

    public static class HashCodeHelperTest
    {
        [Fact]
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_the_value_parameter_is_null_object()
        {
            // Arrange
            var initialize = HashCodeHelper.Initialize();

            double? value = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(value).Value;

            // Assert
            actual.Should().NotBe(initialize.Value);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_value_is_a_null_array()
        {
            // Arrange
            var initialized = HashCodeHelper.Initialize().Value;

            double[] values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(initialized);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_value_is_a_null_ordered_collection()
        {
            // Arrange
            var initialized = HashCodeHelper.Initialize().Value;

            List<double> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(initialized);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_value_is_a_null_unordered_collection()
        {
            // Arrange
            var initialized = HashCodeHelper.Initialize().Value;

            IReadOnlyCollection<double> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(initialized);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_value_is_a_null_dictionary()
        {
            // Arrange
            var initialized = HashCodeHelper.Initialize().Value;

            IDictionary<string, string> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(initialized);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_value_is_a_null_read_only_dictionary()
        {
            // Arrange
            var initialized = HashCodeHelper.Initialize().Value;

            IReadOnlyDictionary<string, string> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(initialized);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_the_value_parameter_is_null_object()
        {
            // Arrange
            double? value = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(value).Value;

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_value_is_a_null_array()
        {
            // Arrange
            double[] values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_value_is_a_null_ordered_collection()
        {
            // Arrange
            IReadOnlyList<double> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_value_is_a_null_unordered_collection()
        {
            // Arrange
            Collection<double> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_value_is_a_null_dictionary()
        {
            // Arrange
            IDictionary<string, string> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_value_is_a_null_read_only_dictionary()
        {
            // Arrange
            ReadOnlyDictionary<string, string> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_hashing_the_same_items_in_the_same_order_but_seeding_Initialize_in_one_case_but_not_the_other()
        {
            // Arrange
            var item1 = A.Dummy<string>();
            var item2 = A.Dummy<string[]>();
            var item3 = A.Dummy<IReadOnlyCollection<string>>();
            var item4 = A.Dummy<IReadOnlyList<string>>();
            var item5 = A.Dummy<IDictionary<string, string>>();
            var item6 = A.Dummy<IReadOnlyDictionary<string, string>>();

            var expected = HashCodeHelper.Initialize().Hash(item1).Hash(item2).Hash(item3).Hash(item4).Hash(item5).Hash(item6).Value;

            // Act
            var actual1 = HashCodeHelper.Initialize(HashCodeHelper.Initialize().Hash(item1).Value).Hash(item2).Hash(item3).Hash(item4).Hash(item5).Hash(item6).Value;
            var actual2 = HashCodeHelper.Initialize(HashCodeHelper.Initialize().Hash(item1).Hash(item2).Value).Hash(item3).Hash(item4).Hash(item5).Hash(item6).Value;
            var actual3 = HashCodeHelper.Initialize(HashCodeHelper.Initialize().Hash(item1).Hash(item2).Hash(item3).Value).Hash(item4).Hash(item5).Hash(item6).Value;
            var actual4 = HashCodeHelper.Initialize(HashCodeHelper.Initialize().Hash(item1).Hash(item2).Hash(item3).Hash(item4).Value).Hash(item5).Hash(item6).Value;
            var actual5 = HashCodeHelper.Initialize(HashCodeHelper.Initialize().Hash(item1).Hash(item2).Hash(item3).Hash(item4).Hash(item5).Value).Hash(item6).Value;
            var actual6 = HashCodeHelper.Initialize(HashCodeHelper.Initialize().Hash(item1).Hash(item2).Hash(item3).Hash(item4).Hash(item5).Hash(item6).Value).Value;

            // Assert
            actual1.Should().Be(expected);
            actual2.Should().Be(expected);
            actual3.Should().Be(expected);
            actual4.Should().Be(expected);
            actual5.Should().Be(expected);
            actual6.Should().Be(expected);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_values_are_objects_hashed_in_same_order()
        {
            // Arrange
            var value1a = "some string";
            var value1b = "some string";

            var value2a = "some other string";
            var value2b = "some other string";

            var expected1 = HashCodeHelper.Initialize().Hash(value1b).Value;
            var expected2 = HashCodeHelper.Initialize().Hash(value1b).Hash(value2b).Value;

            // Act
            var actual1 = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual2 = HashCodeHelper.Initialize().Hash(value1a).Hash(value2a).Value;

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
        }
    }
}
