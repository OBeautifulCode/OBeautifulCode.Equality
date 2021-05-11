// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HashCodeHelperTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using FakeItEasy;

    using FluentAssertions;

    using Xunit;

    public static class HashCodeHelperTest
    {
        [Fact]
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_item_is_a_null_object()
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
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_item_is_a_null_array()
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
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_item_is_a_null_ordered_collection()
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
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_item_is_a_null_unordered_collection()
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
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_item_is_a_null_dictionary()
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
        public static void Hash___Should_return_different_hash_code_than_Initialize___When_parameter_item_is_a_null_read_only_dictionary()
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
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_item_is_a_null_object()
        {
            // Arrange
            double? value = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(value).Value;

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_item_is_a_null_array()
        {
            // Arrange
            double[] values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_item_is_a_null_ordered_collection()
        {
            // Arrange
            IReadOnlyList<double> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_item_is_a_null_unordered_collection()
        {
            // Arrange
            Collection<double> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_item_is_a_null_dictionary()
        {
            // Arrange
            IDictionary<string, string> values = null;

            // Act
            var actual = HashCodeHelper.Initialize().Hash(values);

            // Assert
            actual.Should().NotBe(0);
        }

        [Fact]
        public static void Hash___Should_return_nonzero_hash_code___When_parameter_item_is_a_null_read_only_dictionary()
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
            var item1 = A.Dummy<HashCodeTestClass>();
            var item2 = A.Dummy<HashCodeTestClass[]>();
            var item3 = A.Dummy<IReadOnlyCollection<HashCodeTestClass>>();
            var item4 = A.Dummy<IReadOnlyList<HashCodeTestClass>>();
            var item5 = A.Dummy<IDictionary<string, HashCodeTestClass>>();
            var item6 = A.Dummy<IReadOnlyDictionary<string, HashCodeTestClass>>();

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
        public static void Hash___Should_return_the_same_hash_code___When_hashing_objects_that_are_equal_in_the_same_order()
        {
            // Arrange
            var value1a = new HashCodeTestClass(A.Dummy<string>(), A.Dummy<int>());
            var value1b = new HashCodeTestClass(value1a.StringProperty, value1a.IntProperty);

            var value2a = new HashCodeTestClass(A.Dummy<string>(), A.Dummy<int>());
            var value2b = new HashCodeTestClass(value2a.StringProperty, value2a.IntProperty);

            var expected1 = HashCodeHelper.Initialize().Hash(value1a).Value;
            var expected2 = HashCodeHelper.Initialize().Hash(value1a).Hash(value2a).Value;

            // Act
            var actual1 = HashCodeHelper.Initialize().Hash(value1b).Value;
            var actual2 = HashCodeHelper.Initialize().Hash(value1b).Hash(value2b).Value;

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_objects_that_are_not_equal()
        {
            // Arrange
            var value1a = A.Dummy<HashCodeTestClass>();
            var value1b = A.Dummy<HashCodeTestClass>();

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_items_are_objects_that_are_equal()
        {
            // Arrange
            var value1a = A.Dummy<HashCodeTestClass>();
            var value1b = new HashCodeTestClass(value1a.StringProperty, value1a.IntProperty);

            var expected1 = HashCodeHelper.Initialize().Hash(value1a).Value;

            // Act
            var actual1 = HashCodeHelper.Initialize().Hash(value1b).Value;

            // Assert
            actual1.Should().Be(expected1);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_arrays_that_are_not_equal()
        {
            // Arrange
            var value1a = A.Dummy<HashCodeTestClass[]>();
            var value1b = A.Dummy<HashCodeTestClass[]>();

            var value2a = A.Dummy<HashCodeTestClass[]>();
            var value2b = value2a.Concat(new[] { A.Dummy<HashCodeTestClass>() }).ToArray();

            var value3a = new[] { A.Dummy<HashCodeTestClass>(), A.Dummy<HashCodeTestClass>(), A.Dummy<HashCodeTestClass>() };
            var value3b = value3a.Take(2).ToArray();

            var value4a = new[] { A.Dummy<HashCodeTestClass>(), null, A.Dummy<HashCodeTestClass>() };
            var value4b = new[] { value4a[0], value4a[2] };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            var actual2a = HashCodeHelper.Initialize().Hash(value2a).Value;
            var actual2b = HashCodeHelper.Initialize().Hash(value2b).Value;

            var actual3a = HashCodeHelper.Initialize().Hash(value3a).Value;
            var actual3b = HashCodeHelper.Initialize().Hash(value3b).Value;

            var actual4a = HashCodeHelper.Initialize().Hash(value4a).Value;
            var actual4b = HashCodeHelper.Initialize().Hash(value4b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
            actual2a.Should().NotBe(actual2b);
            actual3a.Should().NotBe(actual3b);
            actual4a.Should().NotBe(actual4b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_items_are_arrays_that_are_equal()
        {
            // Arrange
            var value1a = new HashCodeTestClass[] { };
            var value1b = new HashCodeTestClass[] { };

            var value2a = new HashCodeTestClass[] { null };
            var value2b = new HashCodeTestClass[] { null };

            var value3a = new[] { A.Dummy<HashCodeTestClass>(), null, A.Dummy<HashCodeTestClass>() };
            var value3b = value3a.ToArray();

            var value4a = new[] { A.Dummy<HashCodeTestClass>(), null, A.Dummy<HashCodeTestClass>() };
            var value4b = new[] { new HashCodeTestClass(value4a[0].StringProperty, value4a[0].IntProperty), null, new HashCodeTestClass(value4a[2].StringProperty, value4a[2].IntProperty) };

            var expected1 = HashCodeHelper.Initialize().Hash(value1a).Value;
            var expected2 = HashCodeHelper.Initialize().Hash(value2a).Value;
            var expected3 = HashCodeHelper.Initialize().Hash(value3a).Value;
            var expected4 = HashCodeHelper.Initialize().Hash(value4a).Value;

            // Act
            var actual1 = HashCodeHelper.Initialize().Hash(value1b).Value;
            var actual2 = HashCodeHelper.Initialize().Hash(value2b).Value;
            var actual3 = HashCodeHelper.Initialize().Hash(value3b).Value;
            var actual4 = HashCodeHelper.Initialize().Hash(value4b).Value;

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
            actual3.Should().Be(expected3);
            actual4.Should().Be(expected4);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_ordered_collections_that_are_not_equal()
        {
            // Arrange
            var value1a = A.Dummy<List<HashCodeTestClass>>();
            var value1b = A.Dummy<IReadOnlyList<HashCodeTestClass>>();

            var value2a = A.Dummy<List<HashCodeTestClass>>();
            var value2b = value2a.Concat(new[] { A.Dummy<HashCodeTestClass>() }).ToList();

            var value3a = new List<HashCodeTestClass> { A.Dummy<HashCodeTestClass>(), A.Dummy<HashCodeTestClass>(), A.Dummy<HashCodeTestClass>() };
            var value3b = value3a.Take(2).ToList();

            var value4a = new Collection<HashCodeTestClass> { A.Dummy<HashCodeTestClass>(), null, A.Dummy<HashCodeTestClass>() };
            var value4b = new List<HashCodeTestClass> { value4a[0], value4a[2] };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            var actual2a = HashCodeHelper.Initialize().Hash(value2a).Value;
            var actual2b = HashCodeHelper.Initialize().Hash(value2b).Value;

            var actual3a = HashCodeHelper.Initialize().Hash(value3a).Value;
            var actual3b = HashCodeHelper.Initialize().Hash(value3b).Value;

            var actual4a = HashCodeHelper.Initialize().Hash(value4a).Value;
            var actual4b = HashCodeHelper.Initialize().Hash(value4b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
            actual2a.Should().NotBe(actual2b);
            actual3a.Should().NotBe(actual3b);
            actual4a.Should().NotBe(actual4b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_items_are_ordered_collections_that_are_equal()
        {
            // Arrange
            var value1a = new Collection<HashCodeTestClass> { };
            var value1b = new List<HashCodeTestClass> { };

            var value2a = new List<HashCodeTestClass> { null };
            var value2b = new List<HashCodeTestClass> { null };

            var value3a = new Collection<HashCodeTestClass> { A.Dummy<HashCodeTestClass>(), null, A.Dummy<HashCodeTestClass>() };
            var value3b = value3a.ToList();

            var value4a = new List<HashCodeTestClass> { A.Dummy<HashCodeTestClass>(), null, A.Dummy<HashCodeTestClass>() };
            var value4b = new List<HashCodeTestClass> { new HashCodeTestClass(value4a[0].StringProperty, value4a[0].IntProperty), null, new HashCodeTestClass(value4a[2].StringProperty, value4a[2].IntProperty) };

            var expected1 = HashCodeHelper.Initialize().Hash(value1a).Value;
            var expected2 = HashCodeHelper.Initialize().Hash(value2a).Value;
            var expected3 = HashCodeHelper.Initialize().Hash(value3a).Value;
            var expected4 = HashCodeHelper.Initialize().Hash(value4a).Value;

            // Act
            var actual1 = HashCodeHelper.Initialize().Hash(value1b).Value;
            var actual2 = HashCodeHelper.Initialize().Hash(value2b).Value;
            var actual3 = HashCodeHelper.Initialize().Hash(value3b).Value;
            var actual4 = HashCodeHelper.Initialize().Hash(value4b).Value;

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
            actual3.Should().Be(expected3);
            actual4.Should().Be(expected4);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_unordered_collections_whose_elements_are_not_IComparable_and_having_different_number_of_elements()
        {
            // Arrange
            ICollection<HashCodeTestClass> value1a = new List<HashCodeTestClass> { A.Dummy<HashCodeTestClass>(), A.Dummy<HashCodeTestClass>() };
            IReadOnlyCollection<HashCodeTestClass> value1b = new List<HashCodeTestClass> { A.Dummy<HashCodeTestClass>() };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_items_are_unordered_collections_whose_elements_are_not_IComparable_and_having_the_same_number_of_elements()
        {
            // Arrange
            ICollection<HashCodeTestClass> value1a = new List<HashCodeTestClass> { };
            IReadOnlyCollection<HashCodeTestClass> value1b = new HashCodeTestClass[] { };

            ICollection<HashCodeTestClass> value2a = new List<HashCodeTestClass> { A.Dummy<HashCodeTestClass>(), A.Dummy<HashCodeTestClass>() };
            IReadOnlyCollection<HashCodeTestClass> value2b = new[] { A.Dummy<HashCodeTestClass>(), A.Dummy<HashCodeTestClass>() };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            var actual2a = HashCodeHelper.Initialize().Hash(value2a).Value;
            var actual2b = HashCodeHelper.Initialize().Hash(value2b).Value;

            // Assert
            actual1a.Should().Be(actual1b);
            actual2a.Should().Be(actual2b);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_unordered_collections_whose_elements_are_IComparable_but_are_not_equal()
        {
            // Arrange
            IReadOnlyCollection<string> value1a = A.Dummy<List<string>>();
            IReadOnlyCollection<string> value1b = A.Dummy<IReadOnlyList<string>>();

            IReadOnlyCollection<string> value2a = A.Dummy<List<string>>();
            IReadOnlyCollection<string> value2b = value2a.Concat(new[] { A.Dummy<string>() }).ToList();

            IReadOnlyCollection<string> value3a = new List<string> { A.Dummy<string>(), A.Dummy<string>(), A.Dummy<string>() };
            IReadOnlyCollection<string> value3b = value3a.Take(2).ToList();

            IReadOnlyCollection<string> value4a = new Collection<string> { A.Dummy<string>(), null, A.Dummy<string>() };
            IReadOnlyCollection<string> value4b = new List<string> { value4a.First(), value4a.Last() };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            var actual2a = HashCodeHelper.Initialize().Hash(value2a).Value;
            var actual2b = HashCodeHelper.Initialize().Hash(value2b).Value;

            var actual3a = HashCodeHelper.Initialize().Hash(value3a).Value;
            var actual3b = HashCodeHelper.Initialize().Hash(value3b).Value;

            var actual4a = HashCodeHelper.Initialize().Hash(value4a).Value;
            var actual4b = HashCodeHelper.Initialize().Hash(value4b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
            actual2a.Should().NotBe(actual2b);
            actual3a.Should().NotBe(actual3b);
            actual4a.Should().NotBe(actual4b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_items_are_unordered_collections_whose_elements_are_IComparable_and_equal()
        {
            // Arrange
            IReadOnlyCollection<string> value1a = new Collection<string> { };
            IReadOnlyCollection<string> value1b = new List<string> { };

            IReadOnlyCollection<string> value2a = new List<string> { null };
            IReadOnlyCollection<string> value2b = new List<string> { null };

            IReadOnlyCollection<string> value3a = new Collection<string> { A.Dummy<string>(), null, A.Dummy<string>() };
            IReadOnlyCollection<string> value3b = value3a.ToList();

            IReadOnlyCollection<string> value4a = new List<string> { A.Dummy<string>(), null, A.Dummy<string>() };
            IReadOnlyCollection<string> value4b = new List<string> { value4a.First(), null, value4a.Last() };

            IReadOnlyCollection<string> value5a = new List<string> { A.Dummy<string>(), null, A.Dummy<string>() };
            IReadOnlyCollection<string> value5b = new List<string> { null, value5a.Last(), value5a.First() };

            var expected1 = HashCodeHelper.Initialize().Hash(value1a).Value;
            var expected2 = HashCodeHelper.Initialize().Hash(value2a).Value;
            var expected3 = HashCodeHelper.Initialize().Hash(value3a).Value;
            var expected4 = HashCodeHelper.Initialize().Hash(value4a).Value;
            var expected5 = HashCodeHelper.Initialize().Hash(value5a).Value;

            // Act
            var actual1 = HashCodeHelper.Initialize().Hash(value1b).Value;
            var actual2 = HashCodeHelper.Initialize().Hash(value2b).Value;
            var actual3 = HashCodeHelper.Initialize().Hash(value3b).Value;
            var actual4 = HashCodeHelper.Initialize().Hash(value4b).Value;
            var actual5 = HashCodeHelper.Initialize().Hash(value5b).Value;

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
            actual3.Should().Be(expected3);
            actual4.Should().Be(expected4);
            actual5.Should().Be(expected5);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_dictionaries_whose_keys_are_not_IComparable_and_having_a_different_number_of_keys()
        {
            // Arrange
            IDictionary<HashCodeTestClass, string> value1a = new Dictionary<HashCodeTestClass, string>
            {
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
            };
            IDictionary<HashCodeTestClass, string> value1b = new Dictionary<HashCodeTestClass, string>
            {
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
            };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_items_are_dictionaries_whose_keys_are_not_IComparable_and_having_the_same_number_of_keys()
        {
            // Arrange
            IDictionary<HashCodeTestClass, string> value1a = new Dictionary<HashCodeTestClass, string>
            {
            };
            IDictionary<HashCodeTestClass, string> value1b = new Dictionary<HashCodeTestClass, string>
            {
            };

            IDictionary<HashCodeTestClass, string> value2a = new Dictionary<HashCodeTestClass, string>
            {
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
            };
            IDictionary<HashCodeTestClass, string> value2b = new Dictionary<HashCodeTestClass, string>
            {
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
            };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            var actual2a = HashCodeHelper.Initialize().Hash(value2a).Value;
            var actual2b = HashCodeHelper.Initialize().Hash(value2b).Value;

            // Assert
            actual1a.Should().Be(actual1b);
            actual2a.Should().Be(actual2b);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_dictionaries_whose_keys_are_IComparable_and_the_keys_are_not_equal()
        {
            // Arrange
            var hashCodeTestClass = A.Dummy<HashCodeTestClass>();

            IDictionary<string, HashCodeTestClass> value1a = new Dictionary<string, HashCodeTestClass>
            {
                { A.Dummy<string>(), hashCodeTestClass },
                { A.Dummy<string>(), hashCodeTestClass },
            };

            IDictionary<string, HashCodeTestClass> value1b = new Dictionary<string, HashCodeTestClass>
            {
                { A.Dummy<string>(), hashCodeTestClass },
                { A.Dummy<string>(), hashCodeTestClass },
            };

            IDictionary<string, HashCodeTestClass> value2a = new Dictionary<string, HashCodeTestClass>
            {
                { A.Dummy<string>(), hashCodeTestClass },
                { A.Dummy<string>(), hashCodeTestClass },
            };

            IDictionary<string, HashCodeTestClass> value2b = value2a.Take(1).ToDictionary(_ => _.Key, _ => _.Value);

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            var actual2a = HashCodeHelper.Initialize().Hash(value2a).Value;
            var actual2b = HashCodeHelper.Initialize().Hash(value2b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
            actual2a.Should().NotBe(actual2b);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_dictionaries_whose_keys_are_not_IComparable_where_the_keys_are_equal_but_the_values_are_not()
        {
            // Arrange
            var hashCodeTestClass = A.Dummy<HashCodeTestClass>();

            IDictionary<string, HashCodeTestClass> value1a = new Dictionary<string, HashCodeTestClass>
            {
                { A.Dummy<string>(), hashCodeTestClass },
                { A.Dummy<string>(), hashCodeTestClass },
            };

            IDictionary<string, HashCodeTestClass> value1b = value1a.ToDictionary(_ => _.Key, _ => A.Dummy<HashCodeTestClass>());

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_codes___When_the_items_are_dictionaries_whose_keys_are_not_IComparable_where_the_keys_are_equal_and_the_values_are_equal()
        {
            // Arrange
            var hashCodeTestClass = A.Dummy<HashCodeTestClass>();

            IDictionary<string, HashCodeTestClass> value1a = new Dictionary<string, HashCodeTestClass>
            {
                { A.Dummy<string>(), hashCodeTestClass },
                { A.Dummy<string>(), hashCodeTestClass },
            };

            IDictionary<string, HashCodeTestClass> value1b = value1a.ToDictionary(_ => _.Key, _ => new HashCodeTestClass(_.Value.StringProperty, _.Value.IntProperty));

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            // Assert
            actual1a.Should().Be(actual1b);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_read_only_dictionaries_whose_keys_are_not_IComparable_and_having_a_different_number_of_keys()
        {
            // Arrange
            IReadOnlyDictionary<HashCodeTestClass, string> value1a = new Dictionary<HashCodeTestClass, string>
            {
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
            };
            IReadOnlyDictionary<HashCodeTestClass, string> value1b = new Dictionary<HashCodeTestClass, string>
            {
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
            };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_items_are_read_only_dictionaries_whose_keys_are_not_IComparable_and_having_the_same_number_of_keys()
        {
            // Arrange
            IReadOnlyDictionary<HashCodeTestClass, string> value1a = new Dictionary<HashCodeTestClass, string>
            {
            };
            IReadOnlyDictionary<HashCodeTestClass, string> value1b = new Dictionary<HashCodeTestClass, string>
            {
            };

            IReadOnlyDictionary<HashCodeTestClass, string> value2a = new Dictionary<HashCodeTestClass, string>
            {
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
            };
            IReadOnlyDictionary<HashCodeTestClass, string> value2b = new Dictionary<HashCodeTestClass, string>
            {
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
                { A.Dummy<HashCodeTestClass>(), A.Dummy<string>() },
            };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            var actual2a = HashCodeHelper.Initialize().Hash(value2a).Value;
            var actual2b = HashCodeHelper.Initialize().Hash(value2b).Value;

            // Assert
            actual1a.Should().Be(actual1b);
            actual2a.Should().Be(actual2b);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_read_only_dictionaries_whose_keys_are_IComparable_and_the_keys_are_not_equal()
        {
            // Arrange
            var hashCodeTestClass = A.Dummy<HashCodeTestClass>();

            IReadOnlyDictionary<string, HashCodeTestClass> value1a = new Dictionary<string, HashCodeTestClass>
            {
                { A.Dummy<string>(), hashCodeTestClass },
                { A.Dummy<string>(), hashCodeTestClass },
            };

            IReadOnlyDictionary<string, HashCodeTestClass> value1b = new Dictionary<string, HashCodeTestClass>
            {
                { A.Dummy<string>(), hashCodeTestClass },
                { A.Dummy<string>(), hashCodeTestClass },
            };

            IReadOnlyDictionary<string, HashCodeTestClass> value2a = new Dictionary<string, HashCodeTestClass>
            {
                { A.Dummy<string>(), hashCodeTestClass },
                { A.Dummy<string>(), hashCodeTestClass },
            };

            IReadOnlyDictionary<string, HashCodeTestClass> value2b = value2a.Take(1).ToDictionary(_ => _.Key, _ => _.Value);

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            var actual2a = HashCodeHelper.Initialize().Hash(value2a).Value;
            var actual2b = HashCodeHelper.Initialize().Hash(value2b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
            actual2a.Should().NotBe(actual2b);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_read_only_dictionaries_whose_keys_are_not_IComparable_where_the_keys_are_equal_but_the_values_are_not()
        {
            // Arrange
            var hashCodeTestClass = A.Dummy<HashCodeTestClass>();

            IReadOnlyDictionary<string, HashCodeTestClass> value1a = new Dictionary<string, HashCodeTestClass>
            {
                { A.Dummy<string>(), hashCodeTestClass },
                { A.Dummy<string>(), hashCodeTestClass },
            };

            IReadOnlyDictionary<string, HashCodeTestClass> value1b = value1a.ToDictionary(_ => _.Key, _ => A.Dummy<HashCodeTestClass>());

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_codes___When_the_items_are_read_only_dictionaries_whose_keys_are_not_IComparable_where_the_keys_are_equal_and_the_values_are_equal()
        {
            // Arrange
            var hashCodeTestClass = A.Dummy<HashCodeTestClass>();

            IReadOnlyDictionary<string, HashCodeTestClass> value1a = new Dictionary<string, HashCodeTestClass>
            {
                { A.Dummy<string>(), hashCodeTestClass },
                { A.Dummy<string>(), hashCodeTestClass },
            };

            IReadOnlyDictionary<string, HashCodeTestClass> value1b = value1a.ToDictionary(_ => _.Key, _ => new HashCodeTestClass(_.Value.StringProperty, _.Value.IntProperty));

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            // Assert
            actual1a.Should().Be(actual1b);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_DateTime_objects_that_are_not_equal()
        {
            // Arrange
            var value1a = DateTime.UtcNow;
            var value1b = value1a.AddTicks(1);

            var value2a = DateTime.Now;
            var value2b = value2a.AddTicks(1);

            var value3a = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);
            var value3b = value3a.AddTicks(1);

            var value4a = DateTime.UtcNow;
            var value4b = new DateTime(value4a.Ticks, DateTimeKind.Local);

            var value5a = DateTime.UtcNow;
            var value5b = new DateTime(value5a.Ticks, DateTimeKind.Unspecified);

            var value6a = DateTime.Now;
            var value6b = new DateTime(value6a.Ticks, DateTimeKind.Unspecified);

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            var actual2a = HashCodeHelper.Initialize().Hash(value2a).Value;
            var actual2b = HashCodeHelper.Initialize().Hash(value2b).Value;

            var actual3a = HashCodeHelper.Initialize().Hash(value3a).Value;
            var actual3b = HashCodeHelper.Initialize().Hash(value3b).Value;

            var actual4a = HashCodeHelper.Initialize().Hash(value4a).Value;
            var actual4b = HashCodeHelper.Initialize().Hash(value4b).Value;

            var actual5a = HashCodeHelper.Initialize().Hash(value5a).Value;
            var actual5b = HashCodeHelper.Initialize().Hash(value5b).Value;

            var actual6a = HashCodeHelper.Initialize().Hash(value6a).Value;
            var actual6b = HashCodeHelper.Initialize().Hash(value6b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
            actual2a.Should().NotBe(actual2b);
            actual3a.Should().NotBe(actual3b);
            actual4a.Should().NotBe(actual4b);
            actual5a.Should().NotBe(actual5b);
            actual6a.Should().NotBe(actual6b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_items_are_DateTime_objects_that_are_equal()
        {
            // Arrange
            var value1a = DateTime.UtcNow;
            var value1b = new DateTime(value1a.Ticks, value1a.Kind);

            var value2a = DateTime.Now;
            var value2b = new DateTime(value2a.Ticks, value2a.Kind);

            var value3a = new DateTime(1345342, DateTimeKind.Unspecified);
            var value3b = new DateTime(value3a.Ticks, value3a.Kind);

            var expected1 = HashCodeHelper.Initialize().Hash(value1a).Value;
            var expected2 = HashCodeHelper.Initialize().Hash(value2a).Value;
            var expected3 = HashCodeHelper.Initialize().Hash(value3a).Value;

            // Act
            var actual1 = HashCodeHelper.Initialize().Hash(value1b).Value;
            var actual2 = HashCodeHelper.Initialize().Hash(value2b).Value;
            var actual3 = HashCodeHelper.Initialize().Hash(value3b).Value;

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
            actual3.Should().Be(expected3);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_Nullable_DateTime_objects_that_are_not_equal()
        {
            // Arrange
            DateTime? value1a = DateTime.UtcNow;
            DateTime value1b = ((DateTime)value1a).AddTicks(1);

            DateTime? value2a = DateTime.Now;
            DateTime? value2b = ((DateTime)value2a).AddTicks(1);

            DateTime? value3a = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);
            DateTime? value3b = ((DateTime)value3a).AddTicks(1);

            DateTime? value4a = DateTime.UtcNow;
            DateTime? value4b = new DateTime(((DateTime)value4a).Ticks, DateTimeKind.Local);

            DateTime? value5a = DateTime.UtcNow;
            DateTime? value5b = new DateTime(((DateTime)value5a).Ticks, DateTimeKind.Unspecified);

            DateTime? value6a = DateTime.Now;
            DateTime? value6b = new DateTime(((DateTime)value6a).Ticks, DateTimeKind.Unspecified);

            DateTime? value7a = null;
            DateTime? value7b = DateTime.UtcNow;

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(value1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(value1b).Value;

            var actual2a = HashCodeHelper.Initialize().Hash(value2a).Value;
            var actual2b = HashCodeHelper.Initialize().Hash(value2b).Value;

            var actual3a = HashCodeHelper.Initialize().Hash(value3a).Value;
            var actual3b = HashCodeHelper.Initialize().Hash(value3b).Value;

            var actual4a = HashCodeHelper.Initialize().Hash(value4a).Value;
            var actual4b = HashCodeHelper.Initialize().Hash(value4b).Value;

            var actual5a = HashCodeHelper.Initialize().Hash(value5a).Value;
            var actual5b = HashCodeHelper.Initialize().Hash(value5b).Value;

            var actual6a = HashCodeHelper.Initialize().Hash(value6a).Value;
            var actual6b = HashCodeHelper.Initialize().Hash(value6b).Value;

            var actual7a = HashCodeHelper.Initialize().Hash(value7a).Value;
            var actual7b = HashCodeHelper.Initialize().Hash(value7b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
            actual2a.Should().NotBe(actual2b);
            actual3a.Should().NotBe(actual3b);
            actual4a.Should().NotBe(actual4b);
            actual5a.Should().NotBe(actual5b);
            actual6a.Should().NotBe(actual6b);
            actual7a.Should().NotBe(actual7b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_items_are_Nullable_DateTime_objects_that_are_equal()
        {
            // Arrange
            DateTime? value1a = DateTime.UtcNow;
            DateTime? value1b = new DateTime(((DateTime)value1a).Ticks, ((DateTime)value1a).Kind);

            DateTime? value2a = DateTime.Now;
            DateTime? value2b = new DateTime(((DateTime)value2a).Ticks, ((DateTime)value2a).Kind);

            DateTime? value3a = new DateTime(1345342, DateTimeKind.Unspecified);
            DateTime? value3b = new DateTime(((DateTime)value3a).Ticks, ((DateTime)value3a).Kind);

            DateTime? value4a = null;
            DateTime? value4b = null;

            var expected1 = HashCodeHelper.Initialize().Hash(value1a).Value;
            var expected2 = HashCodeHelper.Initialize().Hash(value2a).Value;
            var expected3 = HashCodeHelper.Initialize().Hash(value3a).Value;
            var expected4 = HashCodeHelper.Initialize().Hash(value4a).Value;

            // Act
            var actual1 = HashCodeHelper.Initialize().Hash(value1b).Value;
            var actual2 = HashCodeHelper.Initialize().Hash(value2b).Value;
            var actual3 = HashCodeHelper.Initialize().Hash(value3b).Value;
            var actual4 = HashCodeHelper.Initialize().Hash(value4b).Value;

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
            actual3.Should().Be(expected3);
            actual4.Should().Be(expected4);
        }

        [Fact]
        public static void Hash___Should_return_different_hash_codes___When_the_items_are_multiple_level_data_structures_that_are_not_equal()
        {
            // Arrange
            IReadOnlyDictionary<string, IReadOnlyList<IReadOnlyCollection<string>>> item1a = new Dictionary<string, IReadOnlyList<IReadOnlyCollection<string>>>
            {
                {
                    "abc",
                    new IReadOnlyCollection<string>[]
                    {
                        new List<string> { "1", "2", null, "3" },
                        null,
                        new List<string> { null, null, "4", "5" },
                    }
                },
                {
                    "def",
                    null
                },
                {
                    "ghi",
                    new List<IReadOnlyCollection<string>>
                    {
                        new List<string> { "6", "7" },
                        new List<string> { "8", "9" },
                        null,
                    }
                },
                {
                    "jkl",
                    new List<IReadOnlyCollection<string>>
                    {
                    }
                },
            };

            IReadOnlyDictionary<string, IReadOnlyList<IReadOnlyCollection<string>>> item1b = new Dictionary<string, IReadOnlyList<IReadOnlyCollection<string>>>
            {
                {
                    "abc",
                    new IReadOnlyCollection<string>[]
                    {
                        new List<string> { "1", "2", null, "3" },
                        null,
                        new List<string> { null, null, "4", "5" },
                    }
                },
                {
                    "def",
                    null
                },
                {
                    "ghi",
                    new List<IReadOnlyCollection<string>>
                    {
                        new List<string> { "6", "7" },
                        new List<string> { "8", "9" },
                        null,
                    }
                },
                {
                    "jkl",
                    new List<IReadOnlyCollection<string>>
                    {
                        null,
                    }
                },
            };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(item1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(item1b).Value;

            // Assert
            actual1a.Should().NotBe(actual1b);
        }

        [Fact]
        public static void Hash___Should_return_the_same_hash_code___When_the_items_are_multiple_level_data_structures_that_are_equal()
        {
            // Arrange
            IReadOnlyDictionary<string, IReadOnlyList<IReadOnlyCollection<string>>> item1a = new Dictionary<string, IReadOnlyList<IReadOnlyCollection<string>>>
            {
                {
                    "abc",
                    new IReadOnlyCollection<string>[]
                    {
                        new List<string> { "1", "2", null, "3" },
                        null,
                        new List<string> { null, null, "4", "5" },
                    }
                },
                {
                    "def",
                    null
                },
                {
                    "ghi",
                    new List<IReadOnlyCollection<string>>
                    {
                        new List<string> { "6", "7" },
                        new List<string> { "8", "9" },
                        null,
                    }
                },
                {
                    "jkl",
                    new List<IReadOnlyCollection<string>>
                    {
                    }
                },
            };

            IReadOnlyDictionary<string, IReadOnlyList<IReadOnlyCollection<string>>> item1b = new Dictionary<string, IReadOnlyList<IReadOnlyCollection<string>>>
            {
                {
                    "jkl",
                    new List<IReadOnlyCollection<string>>
                    {
                    }
                },
                {
                    "def",
                    null
                },
                {
                    "abc",
                    new IReadOnlyCollection<string>[]
                    {
                        new List<string> { "1", "3", "2", null, },
                        null,
                        new List<string> { "4", null, null, "5" },
                    }
                },
                {
                    "ghi",
                    new List<IReadOnlyCollection<string>>
                    {
                        new List<string> { "7", "6" },
                        new List<string> { "9", "8" },
                        null,
                    }
                },
            };

            // Act
            var actual1a = HashCodeHelper.Initialize().Hash(item1a).Value;
            var actual1b = HashCodeHelper.Initialize().Hash(item1b).Value;

            // Assert
            actual1a.Should().Be(actual1b);
        }

        private class HashCodeTestClass : IEquatable<HashCodeTestClass>
        {
            public HashCodeTestClass(
                string stringProperty,
                int intProperty)
            {
                this.StringProperty = stringProperty;
                this.IntProperty = intProperty;
            }

            public string StringProperty { get; }

            public int IntProperty { get; }

            public static bool operator ==(
                HashCodeTestClass left,
                HashCodeTestClass right)
            {
                if (ReferenceEquals(left, right))
                {
                    return true;
                }

                if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                {
                    return false;
                }

                var result =
                    (left.StringProperty == right.StringProperty) &&
                    (left.IntProperty == right.IntProperty);

                return result;
            }

            public static bool operator !=(
                HashCodeTestClass left,
                HashCodeTestClass right)
                => !(left == right);

            /// <inheritdoc />
            public bool Equals(HashCodeTestClass other) => this == other;

            /// <inheritdoc />
            public override bool Equals(object obj) => this == (obj as HashCodeTestClass);

            /// <inheritdoc />
            public override int GetHashCode() => Tuple.Create(this.StringProperty, this.IntProperty).GetHashCode();
        }
    }
}
