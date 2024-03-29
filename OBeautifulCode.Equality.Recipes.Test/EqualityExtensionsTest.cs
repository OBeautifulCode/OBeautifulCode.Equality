﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualityExtensionsTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Test
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Linq;

    using FakeItEasy;

    using FluentAssertions;

    using OBeautifulCode.AutoFakeItEasy;

    using Xunit;

    public static class EqualityExtensionsTest
    {
        [Fact]
        public static void IsEqualTo___Should_return_true___When_both_items_are_null()
        {
            // Arrange
            object item1 = null;
            object item2 = null;

            // Act
            var actual = EqualityExtensions.IsEqualTo(item1, item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_one_but_not_both_items_are_null()
        {
            // Arrange
            var item = new object();

            // Act
            var actual1 = EqualityExtensions.IsEqualTo(item, null);
            var actual2 = EqualityExtensions.IsEqualTo(null, item);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_objects_are_the_same_reference()
        {
            // Arrange
            var item1a = new object();
            var item1b = item1a;

            // Act
            var actual1 = item1a.IsEqualTo(item1b);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_objects_are_not_equal()
        {
            // Arrange
            var item1 = "asdf";
            var item2 = "ASDF";

            // Act
            var actual = item1.IsEqualTo(item2);

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_objects_are_equal()
        {
            // Arrange
            var item1a = 5;
            var item1b = 5;

            // Act
            var actual1 = item1a.IsEqualTo(item1b);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_objects_are_equal_using_specified_comparer()
        {
            // Arrange
            var item1a = "asdf";
            var item1b = "ASDF";

            // Act
            var actual1 = item1a.IsEqualTo(item1b, StringComparer.OrdinalIgnoreCase);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_objects_have_different_runtime_types()
        {
            // Arrange
            object item1 = Some.Dummies<byte>().ToArray();
            object item2 = new object();

            // Act
            var actual1 = item1.IsEqualTo(item2);
            var actual2 = item2.IsEqualTo(item1);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_objects_runtime_types_are_object()
        {
            // Arrange
            var item1 = new object();
            var item2 = new object();

            // Act
            var actual = item1.IsEqualTo(item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_objects_are_equal_using_runtime_types_as_declared_type()
        {
            // Arrange
            object item1 = new List<string> { "abc", null, "def" };
            object item2 = new List<string> { "abc", null, "def" };

            // Act
            var actual = item1.IsEqualTo(item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_objects_are_not_equal_using_runtime_types_as_declared_type()
        {
            // Arrange
            object item1 = new List<string> { "abc", null, "def" };
            object item2 = new List<string> { "abc", null };

            // Act
            var actual = item1.IsEqualTo(item2);

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_objects_are_dictionaries_that_are_not_equal()
        {
            IDictionary<string, string> item1a = new Dictionary<string, string>();

            IDictionary<string, string> item1b = new Dictionary<string, string>
            {
                { "abc", "abc" },
            };

            IDictionary<string, string> item2a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> item2b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "aaa", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> item3a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> item3b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> item4a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> item4b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "aaa" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> item5a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> item5b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "GHI", "jkl" },
                { "mno", "pqr" },
            };

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);
            var actual3 = item3a.IsEqualTo(item3b);
            var actual4 = item4a.IsEqualTo(item4b);
            var actual5 = item5a.IsEqualTo(item5b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_dictionaries_are_equal()
        {
            // Arrange
            IDictionary<string, string> item1a = new Dictionary<string, string>();
            IDictionary<string, string> item1b = new Dictionary<string, string>();

            IDictionary<string, string> item2a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> item2b = new Dictionary<string, string>
            {
                { "mno", "pqr" },
                { "ghi", "jkl" },
                { "abc", "def" },
            };

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_objects_are_read_only_dictionaries_that_are_not_equal()
        {
            IReadOnlyDictionary<string, string> item1a = new Dictionary<string, string>();

            IReadOnlyDictionary<string, string> item1b = new Dictionary<string, string>
            {
                { "abc", "abc" },
            };

            IReadOnlyDictionary<string, string> item2a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> item2b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "aaa", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> item3a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> item3b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> item4a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> item4b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "aaa" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> item5a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> item5b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "GHI", "jkl" },
                { "mno", "pqr" },
            };

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);
            var actual3 = item3a.IsEqualTo(item3b);
            var actual4 = item4a.IsEqualTo(item4b);
            var actual5 = item5a.IsEqualTo(item5b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_read_only_dictionaries_are_equal()
        {
            // Arrange
            IReadOnlyDictionary<string, string> item1a = new Dictionary<string, string>();
            IReadOnlyDictionary<string, string> item1b = new Dictionary<string, string>();

            IReadOnlyDictionary<string, string> item2a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> item2b = new Dictionary<string, string>
            {
                { "mno", "pqr" },
                { "ghi", "jkl" },
                { "abc", "def" },
            };

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_one_byte_array_is_null_and_the_other_is_not_null()
        {
            // Arrange
            byte[] byteArray1 = null;
            var byteArray2 = Some.Dummies<byte>().ToArray();

            // Act
            var result1 = byteArray1.IsEqualTo(byteArray2);
            var result2 = byteArray2.IsEqualTo(byteArray1);

            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_both_bytes_arrays_are_the_same_object_reference()
        {
            // Arrange
            var byteArray = Some.Dummies<byte>().ToArray();

            // Act
            var result = byteArray.IsEqualTo(byteArray);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_byte_arrays_are_not_equal()
        {
            // Arrange
            var byteArray1a = Some.Dummies<byte>().ToArray();
            var byteArray1b = byteArray1a.Concat(new[] { A.Dummy<byte>() }).ToArray();

            var byteArray2a = Some.Dummies<byte>().ToArray();
            var byteArray2b = new[] { A.Dummy<byte>() }.Concat(byteArray2a).ToArray();

            var byteArray3a = Some.Dummies<byte>(5).ToArray();
            var byteArray3b = Some.Dummies<byte>(5).ToArray();

            // Act
            var result1 = byteArray1a.IsEqualTo(byteArray1b);
            var result2 = byteArray2a.IsEqualTo(byteArray2b);
            var result3 = byteArray3a.IsEqualTo(byteArray3b);

            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
            result3.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_byte_arrays_are_equal_but_not_the_same_object_reference()
        {
            // Arrange
            var byteArray1 = Some.Dummies<byte>().ToArray();
            var byteArray2 = new byte[byteArray1.Length];
            Buffer.BlockCopy(byteArray1, 0, byteArray2, 0, byteArray1.Length);

            // Act
            var result = byteArray1.IsEqualTo(byteArray2);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_arrays_are_not_equal()
        {
            // Arrange
            var item1a = new[] { "abc", "def" };
            var item1b = new[] { "abc", "def", "ghi" };

            var item2a = new[] { "abc", "def", "ghi" };
            var item2b = new[] { "abc", "def" };

            var item3a = new[] { "abc", "def" };
            var item3b = new[] { "aBc", "dEf" };

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);
            var actual3 = item3a.IsEqualTo(item3b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_arrays_are_equal()
        {
            // Arrange
            var item1a = new[] { "abc", null, "def" };
            var item1b = new[] { "abc", null, "def" };

            var item2a = new string[0];
            var item2b = new string[0];

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_ordered_collections_are_not_equal()
        {
            // Arrange
            var item1a = new List<string> { "abc", "def" };
            var item1b = new List<string> { "abc", "def", "ghi" };

            IReadOnlyList<string> item2a = new List<string> { "abc", "def", "ghi" };
            IReadOnlyList<string> item2b = new List<string> { "abc", "def" };

            IList<string> item3a = new List<string> { "abc", "def" };
            IList<string> item3b = new List<string> { "aBc", "dEf" };

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);
            var actual3 = item3a.IsEqualTo(item3b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_ordered_collections_are_equal()
        {
            // Arrange
            var item1a = new List<string> { "abc", null, "def" };
            var item1b = new List<string> { "abc", null, "def" };

            IReadOnlyList<string> item2a = new string[0];
            IReadOnlyList<string> item2b = new string[0];

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_unordered_collections_are_not_equal()
        {
            // Arrange
            IReadOnlyCollection<string> item1a = new List<string> { "abc", "def" };
            IReadOnlyCollection<string> item1b = new List<string> { "abc", "def", "ghi" };

            ICollection<string> item2a = new List<string> { "abc", "def", "ghi" };
            ICollection<string> item2b = new List<string> { "abc", "def", null };

            ICollection<string> item3a = new List<string> { "abc", "def" };
            ICollection<string> item3b = new List<string> { "aBc", "dEf" };

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);
            var actual3 = item3a.IsEqualTo(item3b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_unordered_collections_are_equal()
        {
            // Arrange
            ICollection<string> item1a = new List<string> { "abc", null, "def" };
            ICollection<string> item1b = new List<string> { "abc", null, "def" };

            IReadOnlyCollection<string> item2a = new string[0];
            IReadOnlyCollection<string> item2b = new string[0];

            ICollection<string> item3a = new List<string> { "abc", null, "def" };
            ICollection<string> item3b = new List<string> { "def", "abc", null };

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);
            var actual3 = item3a.IsEqualTo(item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_enumerables_are_not_equal()
        {
            // Arrange
            IEnumerable<string> item1a = new List<string> { "abc", "def" };
            IEnumerable<string> item1b = new List<string> { "abc", "def", "ghi" };

            IEnumerable<string> item2a = new List<string> { "abc", "def", "ghi" };
            IEnumerable<string> item2b = new List<string> { "abc", "def", null };

            IEnumerable<string> item3a = new List<string> { "abc", "def" };
            IEnumerable<string> item3b = new List<string> { "aBc", "dEf" };

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);
            var actual3 = item3a.IsEqualTo(item3b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_enumerables_are_equal()
        {
            // Arrange
            IEnumerable<string> item1a = new List<string> { "abc", null, "def" };
            IEnumerable<string> item1b = new List<string> { "abc", null, "def" };

            IEnumerable<string> item2a = new string[0];
            IEnumerable<string> item2b = new string[0];

            IEnumerable<string> item3a = new List<string> { "abc", null, "def" };
            IEnumerable<string> item3b = new List<string> { "def", "abc", null };

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);
            var actual3 = item3a.IsEqualTo(item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_multiple_level_data_structures_are_not_equal()
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
            var actual1 = item1a.IsEqualTo(item1b);

            // Assert
            actual1.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_multiple_level_data_structures_are_equal()
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
            var actual1 = item1a.IsEqualTo(item1b);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_generating_collection_using_Some_ReadOnlyDummies()
        {
            // Arrange
            var item1a = Some.Dummies<string>(10);
            var item1b = item1a.ToList();

            var item2a = Some.ReadOnlyDummies<string>(10);
            var item2b = item2a.ToList();

            // Act
            var actual1 = EqualityExtensions.IsEqualTo(item1a, item1b);
            var actual2 = EqualityExtensions.IsEqualTo(item2a, item2b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_two_DateTime_objects_with_the_same_Ticks_have_a_different_Kind()
        {
            // Arrange
            var referenceTime = DateTime.Now;

            var item1 = new DateTime(referenceTime.Ticks, DateTimeKind.Utc);
            var item2 = new DateTime(referenceTime.Ticks, DateTimeKind.Local);
            var item3 = new DateTime(referenceTime.Ticks, DateTimeKind.Unspecified);

            // Act
            var actual1 = item1.IsEqualTo(item2);
            var actual2 = item1.IsEqualTo(item3);
            var actual3 = item2.IsEqualTo(item3);

            // Assert
            // first assert that these are considered equal by .NET
            item1.Should().Be(item2);
            item1.Should().Be(item3);
            item2.Should().Be(item3);

            // now assert that our methods considers them NOT equal
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_two_DateTime_objects_having_the_same_Ticks_have_the_same_Kind()
        {
            // Arrange
            var item1a = DateTime.UtcNow;
            var item1b = item1a.AddMilliseconds(0d);

            var item2a = DateTime.Now;
            var item2b = item2a.AddMilliseconds(0d);

            var item3a = new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified);
            var item3b = item3a.AddMilliseconds(0d);

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);
            var actual3 = item3a.IsEqualTo(item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_two_Nullable_DateTime_objects_with_the_same_Ticks_have_a_different_Kind()
        {
            // Arrange
            var referenceTime = DateTime.Now;

            DateTime? item1 = new DateTime(referenceTime.Ticks, DateTimeKind.Utc);
            DateTime item2 = new DateTime(referenceTime.Ticks, DateTimeKind.Local);
            DateTime item3 = new DateTime(referenceTime.Ticks, DateTimeKind.Unspecified);

            // Act
            var actual1 = item1.IsEqualTo(item2);
            var actual2 = item1.IsEqualTo(item3);
            var actual3 = item2.IsEqualTo(item3);

            // Assert
            // first assert that these are considered equal by .NET
            item1.Should().Be(item2);
            item1.Should().Be(item3);
            item2.Should().Be(item3);

            // now assert that our methods considers them NOT equal
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsEqualTo___Should_return_true___When_two_Nullable_DateTime_objects_having_the_same_Ticks_have_the_same_Kind()
        {
            // Arrange
            DateTime? item1a = DateTime.UtcNow;
            DateTime? item1b = ((DateTime)item1a).AddMilliseconds(0d);

            DateTime? item2a = DateTime.Now;
            DateTime? item2b = ((DateTime)item2a).AddMilliseconds(0d);

            DateTime? item3a = new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified);
            DateTime? item3b = ((DateTime)item3a).AddMilliseconds(0d);

            // Act
            var actual1 = item1a.IsEqualTo(item1b);
            var actual2 = item2a.IsEqualTo(item2b);
            var actual3 = item3a.IsEqualTo(item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_two_Color_objects_are_not_equal()
        {
            // Arrange
            var item1 = Color.FromArgb(255, 255, 218, 185);
            var item2 = Color.FromArgb(254, 255, 218, 185);
            var item3 = Color.FromArgb(255, 254, 218, 185);
            var item4 = Color.FromArgb(255, 255, 219, 185);
            var item5 = Color.FromArgb(255, 255, 218, 184);

            // Act
            var actual1 = item1.IsEqualTo(item2);
            var actual2 = item1.IsEqualTo(item3);
            var actual3 = item1.IsEqualTo(item4);
            var actual4 = item1.IsEqualTo(item5);
            var actual5 = item2.IsEqualTo(item3);
            var actual6 = item2.IsEqualTo(item4);
            var actual7 = item2.IsEqualTo(item5);
            var actual8 = item3.IsEqualTo(item4);
            var actual9 = item3.IsEqualTo(item5);
            var actual10 = item4.IsEqualTo(item5);

            // Assert
            // first assert that these are considered not equal by .NET
            item1.Should().NotBe(item2);
            item1.Should().NotBe(item3);
            item1.Should().NotBe(item4);
            item1.Should().NotBe(item5);
            item2.Should().NotBe(item3);
            item2.Should().NotBe(item4);
            item2.Should().NotBe(item5);
            item3.Should().NotBe(item4);
            item3.Should().NotBe(item5);
            item4.Should().NotBe(item5);

            // now assert that our methods considers them NOT equal
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
        public static void IsEqualTo___Should_return_true___When_two_Color_objects_are_equal()
        {
            // Arrange
            var item1 = Color.FromArgb(255, 218, 185);
            var item2 = Color.PeachPuff;

            // Act
            var actual = item1.IsEqualTo(item2);

            // Assert
            // first assert that these are considered not equal by .NET
            item1.Should().NotBe(item2);

            // now assert that our methods considers them equal
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsEqualTo___Should_return_false___When_two_Nullable_Color_objects_are_not_equal()
        {
            // Arrange
            Color? item1 = Color.FromArgb(255, 255, 218, 185);
            Color? item2 = Color.FromArgb(254, 255, 218, 185);
            Color? item3 = Color.FromArgb(255, 254, 218, 185);
            Color? item4 = Color.FromArgb(255, 255, 219, 185);
            Color? item5 = Color.FromArgb(255, 255, 218, 184);

            // Act
            var actual1 = item1.IsEqualTo(item2);
            var actual2 = item1.IsEqualTo(item3);
            var actual3 = item1.IsEqualTo(item4);
            var actual4 = item1.IsEqualTo(item5);
            var actual5 = item2.IsEqualTo(item3);
            var actual6 = item2.IsEqualTo(item4);
            var actual7 = item2.IsEqualTo(item5);
            var actual8 = item3.IsEqualTo(item4);
            var actual9 = item3.IsEqualTo(item5);
            var actual10 = item4.IsEqualTo(item5);

            // Assert
            // first assert that these are considered not equal by .NET
            item1.Should().NotBe(item2);
            item1.Should().NotBe(item3);
            item1.Should().NotBe(item4);
            item1.Should().NotBe(item5);
            item2.Should().NotBe(item3);
            item2.Should().NotBe(item4);
            item2.Should().NotBe(item5);
            item3.Should().NotBe(item4);
            item3.Should().NotBe(item5);
            item4.Should().NotBe(item5);

            // now assert that our methods considers them NOT equal
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
        public static void IsEqualTo___Should_return_true___When_two_Nullable_Color_objects_are_equal()
        {
            // Arrange
            Color? item1 = Color.FromArgb(255, 218, 185);
            Color? item2 = Color.PeachPuff;

            // Act
            var actual = item1.IsEqualTo(item2);

            // Assert
            // first assert that these are considered not equal by .NET
            item1.Should().NotBe(item2);

            // now assert that our methods considers them equal
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_true___When_both_dictionaries_are_null()
        {
            // Arrange
            IDictionary<string, string> item1 = null;
            IDictionary<string, string> item2 = null;

            // Act
            var actual = EqualityExtensions.IsDictionaryEqualTo(item1, item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_false___When_one_but_not_both_dictionaries_are_null()
        {
            // Arrange
            var notNullDictionary = A.Dummy<IDictionary<string, string>>();

            // Act
            var actual1 = EqualityExtensions.IsDictionaryEqualTo(notNullDictionary, null);
            var actual2 = EqualityExtensions.IsDictionaryEqualTo(null, notNullDictionary);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal()
        {
            // Arrange
            IDictionary<string, string> dictionary1a = new Dictionary<string, string>();

            IDictionary<string, string> dictionary1b = new Dictionary<string, string>
            {
                { "abc", "abc" },
            };

            IDictionary<string, string> dictionary2a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> dictionary2b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "aaa", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> dictionary3a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> dictionary3b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> dictionary4a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> dictionary4b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "aaa" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> dictionary5a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> dictionary5b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "GHI", "jkl" },
                { "mno", "pqr" },
            };

            // Act
            var actual1 = dictionary1a.IsDictionaryEqualTo(dictionary1b);
            var actual2 = dictionary2a.IsDictionaryEqualTo(dictionary2b);
            var actual3 = dictionary3a.IsDictionaryEqualTo(dictionary3b);
            var actual4 = dictionary4a.IsDictionaryEqualTo(dictionary4b);
            var actual5 = dictionary5a.IsDictionaryEqualTo(dictionary5b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal()
        {
            // Arrange
            IDictionary<string, string> dictionary1a = new Dictionary<string, string>();
            IDictionary<string, string> dictionary1b = new Dictionary<string, string>();

            IDictionary<string, string> dictionary2a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> dictionary2b = new Dictionary<string, string>
            {
                { "mno", "pqr" },
                { "ghi", "jkl" },
                { "abc", "def" },
            };

            IDictionary<string, string> dictionary3a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IDictionary<string, string> dictionary3b = new Dictionary<string, string>
            {
                { "mno", "PQR" },
                { "ghi", "JKL" },
                { "abc", "DEF" },
            };

            // Act
            var actual1 = dictionary1a.IsDictionaryEqualTo(dictionary1b);
            var actual2 = dictionary2a.IsDictionaryEqualTo(dictionary2b);
            var actual3 = dictionary3a.IsDictionaryEqualTo(dictionary3b, StringComparer.OrdinalIgnoreCase);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal_and_values_are_dictionaries_themselves()
        {
            // Arrange

            // inner dictionary has different values
            IDictionary<string, IDictionary<string, string>> item1a = new Dictionary<string, IDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "6" },
                    }
                },
            };
            IDictionary<string, IDictionary<string, string>> item1b = new Dictionary<string, IDictionary<string, string>>()
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "7" },
                    }
                },
            };

            // inner dictionary has different keys
            IDictionary<string, IDictionary<string, string>> item2a = new Dictionary<string, IDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "6" },
                    }
                },
            };
            IDictionary<string, IDictionary<string, string>> item2b = new Dictionary<string, IDictionary<string, string>>()
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "4", "6" },
                    }
                },
            };

            // inner dictionary is null in one but not the other
            IDictionary<string, IDictionary<string, string>> item3a = new Dictionary<string, IDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    null
                },
            };
            IDictionary<string, IDictionary<string, string>> item3b = new Dictionary<string, IDictionary<string, string>>()
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "6" },
                    }
                },
            };

            // Act
            var actual1 = item1a.IsDictionaryEqualTo(item1b);
            var actual2 = item2a.IsDictionaryEqualTo(item2b);
            var actual3 = item3a.IsDictionaryEqualTo(item3b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal_and_values_are_dictionaries_themselves()
        {
            // Arrange
            // mix-up order of key/value pairs in dictionaries
            IDictionary<string, IDictionary<string, string>> item1a = new Dictionary<string, IDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "6" },
                    }
                },
            };
            IDictionary<string, IDictionary<string, string>> item1b = new Dictionary<string, IDictionary<string, string>>()
            {
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "5", "6" },
                        { "3", "4" },
                    }
                },
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "2", "3" },
                        { "1", "2" },
                    }
                },
            };

            // use different concrete types
            IDictionary<string, IReadOnlyDictionary<string, string>> item2a = new Dictionary<string, IReadOnlyDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "6" },
                    }
                },
            };
            IDictionary<string, IReadOnlyDictionary<string, string>> item2b = new Dictionary<string, IReadOnlyDictionary<string, string>>
            {
                {
                    "whatever1",
                    new ReadOnlyDictionary<string, string>(
                        new Dictionary<string, string>
                        {
                            { "1", "2" },
                            { "2", "3" },
                        })
                },
                {
                    "whatever2",
                    new ReadOnlyDictionary<string, string>(
                        new Dictionary<string, string>
                        {
                            { "3", "4" },
                            { "5", "6" },
                        })
                },
            };

            // null inner dictionaries
            IDictionary<string, IReadOnlyDictionary<string, string>> item3a = new Dictionary<string, IReadOnlyDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    null
                },
            };
            IDictionary<string, IReadOnlyDictionary<string, string>> item3b = new Dictionary<string, IReadOnlyDictionary<string, string>>
            {
                {
                    "whatever1",
                    new ReadOnlyDictionary<string, string>(
                        new Dictionary<string, string>
                        {
                            { "1", "2" },
                            { "2", "3" },
                        })
                },
                {
                    "whatever2",
                    null
                },
            };

            // Act
            var actual1 = item1a.IsDictionaryEqualTo(item1b);
            var actual2 = item2a.IsDictionaryEqualTo(item2b);
            var actual3 = item3a.IsDictionaryEqualTo(item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal_and_values_are_ordered_collections()
        {
            // Arrange

            // enumerables are ordered differently
            IDictionary<string, IList<string>> item1a = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, IList<string>> item1b = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "jkl", "ghi" }
                },
            };

            // enumerables have different elements
            IDictionary<string, IList<string>> item2a = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, IList<string>> item2b = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi" }
                },
            };

            // Act
            var actual1 = item1a.IsDictionaryEqualTo(item1b);
            var actual2 = item2a.IsDictionaryEqualTo(item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal_and_values_are_ordered_collections()
        {
            // Arrange

            // different kinds of concrete ordered enumerables
            IDictionary<string, IList<string>> item1a = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, IList<string>> item1b = new Dictionary<string, IList<string>>
            {
                {
                    "whatever2",
                    new List<string> { "ghi", "jkl" }
                },
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
            };

            // null and empty enumerables
            IDictionary<string, IList<string>> item2a = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new string[0]
                },
                {
                    "whatever2",
                    null
                },
            };
            IDictionary<string, IList<string>> item2b = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new List<string>()
                },
                {
                    "whatever2",
                    null
                },
            };

            // Act
            var actual1 = item1a.IsDictionaryEqualTo(item1b);
            var actual2 = item2a.IsDictionaryEqualTo(item2b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal_and_values_are_not_ordered_collections()
        {
            // Arrange

            // enumerables have different elements
            IDictionary<string, IReadOnlyCollection<string>> item1a = new Dictionary<string, IReadOnlyCollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, IReadOnlyCollection<string>> item1b = new Dictionary<string, IReadOnlyCollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi" }
                },
            };

            // enumerables have different elements
            IDictionary<string, ICollection<string>> item2a = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, ICollection<string>> item2b = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl", "ghi" }
                },
            };

            // Act
            var actual1 = item1a.IsDictionaryEqualTo(item1b);
            var actual2 = item2a.IsDictionaryEqualTo(item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal_and_values_are_not_ordered_collections()
        {
            // Arrange

            // different kinds of concrete ordered enumerables
            IDictionary<string, ICollection<string>> item1a = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, ICollection<string>> item1b = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new List<string> { "ghi", "jkl" }
                },
            };

            // null and empty enumerables
            IDictionary<string, IReadOnlyCollection<string>> item2a = new Dictionary<string, IReadOnlyCollection<string>>
            {
                {
                    "whatever1",
                    new string[0]
                },
                {
                    "whatever2",
                    null
                },
            };
            IDictionary<string, IReadOnlyCollection<string>> item2b = new Dictionary<string, IReadOnlyCollection<string>>
            {
                {
                    "whatever1",
                    new List<string>()
                },
                {
                    "whatever2",
                    null
                },
            };

            // elements in different order
            IDictionary<string, ICollection<string>> item3a = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, ICollection<string>> item3b = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever2",
                    new[] { "jkl", "ghi" }
                },
                {
                    "whatever1",
                    new[] { "def", "abc" }
                },
            };

            // Act
            var actual1 = item1a.IsDictionaryEqualTo(item1b);
            var actual2 = item2a.IsDictionaryEqualTo(item2b);
            var actual3 = item3a.IsDictionaryEqualTo(item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal_and_values_are_enumerables()
        {
            // Arrange

            // enumerables have different elements
            IDictionary<string, IEnumerable<string>> item1a = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, IEnumerable<string>> item1b = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi" }
                },
            };

            // enumerables have different elements
            IDictionary<string, IEnumerable<string>> item2a = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, IEnumerable<string>> item2b = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl", "ghi" }
                },
            };

            // Act
            var actual1 = item1a.IsDictionaryEqualTo(item1b);
            var actual2 = item2a.IsDictionaryEqualTo(item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal_and_values_are_enumerables()
        {
            // Arrange

            // different kinds of concrete ordered enumerables
            IDictionary<string, IEnumerable<string>> item1a = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, IEnumerable<string>> item1b = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new List<string> { "ghi", "jkl" }
                },
            };

            // null and empty enumerables
            IDictionary<string, IEnumerable<string>> item2a = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new string[0]
                },
                {
                    "whatever2",
                    null
                },
            };
            IDictionary<string, IEnumerable<string>> item2b = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new List<string>()
                },
                {
                    "whatever2",
                    null
                },
            };

            // elements in different order
            IDictionary<string, IEnumerable<string>> item3a = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, IEnumerable<string>> item3b = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever2",
                    new[] { "jkl", "ghi" }
                },
                {
                    "whatever1",
                    new[] { "def", "abc" }
                },
            };

            // Act
            var actual1 = item1a.IsDictionaryEqualTo(item1b);
            var actual2 = item2a.IsDictionaryEqualTo(item2b);
            var actual3 = item3a.IsDictionaryEqualTo(item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_true___When_dictionaries_contain_different_equality_comparers_but_contain_the_same_keys_as_evaluated_by_those_comparers()
        {
            // Arrange
            IDictionary<string, ICollection<string>> item1 = new Dictionary<string, ICollection<string>>(StringComparer.Ordinal)
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, ICollection<string>> item2 = new Dictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };

            // Act
            var actual1 = item1.IsDictionaryEqualTo(item2);
            var actual2 = item2.IsDictionaryEqualTo(item1);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_false___When_dictionaries_contain_different_equality_comparers_and_contain_different_keys_as_evaluated_by_those_comparers()
        {
            // Arrange
            IDictionary<string, ICollection<string>> item1 = new Dictionary<string, ICollection<string>>(StringComparer.Ordinal)
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IDictionary<string, ICollection<string>> item2 = new Dictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "WHATEVER1",
                    new[] { "abc", "def" }
                },
                {
                    "WHATEVER2",
                    new[] { "ghi", "jkl" }
                },
            };

            // Act
            var actual1 = item1.IsDictionaryEqualTo(item2);
            var actual2 = item2.IsDictionaryEqualTo(item1);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_false___When_dictionaries_contain_two_DateTime_values_having_the_same_Ticks_but_different_Kind_for_the_same_keys()
        {
            // Arrange
            var dateTime1 = DateTime.Now;
            var dateTime2 = DateTime.UtcNow;

            IDictionary<string, DateTime> item1 = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    dateTime1
                },
                {
                    "whatever2",
                    dateTime2
                },
            };

            IDictionary<string, DateTime> item2a = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    dateTime1
                },
                {
                    "whatever2",
                    new DateTime(dateTime2.Ticks, DateTimeKind.Local)
                },
            };

            IDictionary<string, DateTime> item2b = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    dateTime1
                },
                {
                    "whatever2",
                    new DateTime(dateTime2.Ticks, DateTimeKind.Unspecified)
                },
            };

            IDictionary<string, DateTime> item2c = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    new DateTime(dateTime1.Ticks, DateTimeKind.Unspecified)
                },
                {
                    "whatever2",
                    dateTime2
                },
            };

            // Act
            var actual1 = item1.IsDictionaryEqualTo(item2a);
            var actual2 = item1.IsDictionaryEqualTo(item2b);
            var actual3 = item1.IsDictionaryEqualTo(item2c);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_true___When_dictionaries_contain_two_DateTime_values_having_the_same_Ticks_and_same_Kind_for_the_same_keys()
        {
            // Arrange
            var dateTime1 = DateTime.Now;
            var dateTime2 = DateTime.UtcNow;
            var dateTime3 = new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified);

            IDictionary<string, DateTime> item1 = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    dateTime1
                },
                {
                    "whatever2",
                    dateTime2
                },
                {
                    "whatever3",
                    dateTime3
                },
            };

            IDictionary<string, DateTime> item2 = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    dateTime1
                },
                {
                    "whatever2",
                    dateTime2
                },
                {
                    "whatever3",
                    dateTime3
                },
            };

            // Act
            var actual = item1.IsDictionaryEqualTo(item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_false___When_dictionaries_contain_two_Color_values_that_are_not_equal()
        {
            // Arrange
            var color1 = Color.FromArgb(255, 218, 185);
            var color2 = Color.FromArgb(255, 218, 184);

            IDictionary<string, Color> item1 = new Dictionary<string, Color>()
            {
                {
                    "whatever1",
                    color1
                },
                {
                    "whatever2",
                    color1
                },
            };

            IDictionary<string, Color> item2 = new Dictionary<string, Color>()
            {
                {
                    "whatever1",
                    color1
                },
                {
                    "whatever2",
                    color2
                },
            };

            // Act
            var actual1 = item1.IsDictionaryEqualTo(item2);

            // Assert
            actual1.Should().BeFalse();
        }

        [Fact]
        public static void IsDictionaryEqualTo___Should_return_true___When_dictionaries_contain_two_Color_values_that_are_equal()
        {
            // Arrange
            var color1 = Color.FromArgb(255, 218, 185);
            var color2 = Color.PeachPuff;

            IDictionary<string, Color> item1 = new Dictionary<string, Color>()
            {
                {
                    "whatever1",
                    color1
                },
                {
                    "whatever2",
                    color2
                },
            };

            IDictionary<string, Color> item2 = new Dictionary<string, Color>()
            {
                {
                    "whatever1",
                    color2
                },
                {
                    "whatever2",
                    color1
                },
            };

            // Act
            var actual = item1.IsDictionaryEqualTo(item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_both_read_only_dictionaries_are_null()
        {
            // Arrange
            IReadOnlyDictionary<string, string> item1 = null;
            IReadOnlyDictionary<string, string> item2 = null;

            // Act
            var actual = EqualityExtensions.IsReadOnlyDictionaryEqualTo(item1, item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_one_but_not_both_read_only_dictionaries_are_null()
        {
            // Arrange
            var notNullDictionary = A.Dummy<IReadOnlyDictionary<string, string>>();

            // Act
            var actual1 = EqualityExtensions.IsReadOnlyDictionaryEqualTo<string, string>(notNullDictionary, null);
            var actual2 = EqualityExtensions.IsReadOnlyDictionaryEqualTo<string, string>(null, notNullDictionary);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_read_only_dictionaries_are_not_equal()
        {
            // Arrange
            IReadOnlyDictionary<string, string> dictionary1a = new Dictionary<string, string>();

            IReadOnlyDictionary<string, string> dictionary1b = new Dictionary<string, string>
            {
                { "abc", "abc" },
            };

            IReadOnlyDictionary<string, string> dictionary2a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> dictionary2b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "aaa", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> dictionary3a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> dictionary3b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> dictionary4a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> dictionary4b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "aaa" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> dictionary5a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> dictionary5b = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "GHI", "jkl" },
                { "mno", "pqr" },
            };

            // Act
            var actual1 = dictionary1a.IsReadOnlyDictionaryEqualTo(dictionary1b);
            var actual2 = dictionary2a.IsReadOnlyDictionaryEqualTo(dictionary2b);
            var actual3 = dictionary3a.IsReadOnlyDictionaryEqualTo(dictionary3b);
            var actual4 = dictionary4a.IsReadOnlyDictionaryEqualTo(dictionary4b);
            var actual5 = dictionary5a.IsReadOnlyDictionaryEqualTo(dictionary5b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_read_only_dictionaries_are_equal()
        {
            // Arrange
            IReadOnlyDictionary<string, string> dictionary1a = new Dictionary<string, string>();
            IReadOnlyDictionary<string, string> dictionary1b = new Dictionary<string, string>();

            IReadOnlyDictionary<string, string> dictionary2a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> dictionary2b = new Dictionary<string, string>
            {
                { "mno", "pqr" },
                { "ghi", "jkl" },
                { "abc", "def" },
            };

            IReadOnlyDictionary<string, string> dictionary3a = new Dictionary<string, string>
            {
                { "abc", "def" },
                { "ghi", "jkl" },
                { "mno", "pqr" },
            };

            IReadOnlyDictionary<string, string> dictionary3b = new Dictionary<string, string>
            {
                { "mno", "PQR" },
                { "ghi", "JKL" },
                { "abc", "DEF" },
            };

            // Act
            var actual1 = dictionary1a.IsReadOnlyDictionaryEqualTo(dictionary1b);
            var actual2 = dictionary2a.IsReadOnlyDictionaryEqualTo(dictionary2b);
            var actual3 = dictionary3a.IsReadOnlyDictionaryEqualTo(dictionary3b, StringComparer.OrdinalIgnoreCase);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_read_only_dictionaries_are_not_equal_and_values_are_read_only_dictionaries_themselves()
        {
            // Arrange

            // inner dictionary has different values
            IReadOnlyDictionary<string, IDictionary<string, string>> item1a = new Dictionary<string, IDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "6" },
                    }
                },
            };
            IReadOnlyDictionary<string, IDictionary<string, string>> item1b = new Dictionary<string, IDictionary<string, string>>()
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "7" },
                    }
                },
            };

            // inner dictionary has different keys
            IReadOnlyDictionary<string, IDictionary<string, string>> item2a = new Dictionary<string, IDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "6" },
                    }
                },
            };
            IReadOnlyDictionary<string, IDictionary<string, string>> item2b = new Dictionary<string, IDictionary<string, string>>()
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "4", "6" },
                    }
                },
            };

            // inner dictionary is null in one but not the other
            IReadOnlyDictionary<string, IDictionary<string, string>> item3a = new Dictionary<string, IDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    null
                },
            };
            IReadOnlyDictionary<string, IDictionary<string, string>> item3b = new Dictionary<string, IDictionary<string, string>>()
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "6" },
                    }
                },
            };

            // Act
            var actual1 = item1a.IsReadOnlyDictionaryEqualTo(item1b);
            var actual2 = item2a.IsReadOnlyDictionaryEqualTo(item2b);
            var actual3 = item3a.IsReadOnlyDictionaryEqualTo(item3b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_read_only_dictionaries_are_equal_and_values_are_read_only_dictionaries_themselves()
        {
            // Arrange
            // mix-up order of key/value pairs in dictionaries
            IReadOnlyDictionary<string, IDictionary<string, string>> item1a = new Dictionary<string, IDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "6" },
                    }
                },
            };
            IReadOnlyDictionary<string, IDictionary<string, string>> item1b = new Dictionary<string, IDictionary<string, string>>()
            {
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "5", "6" },
                        { "3", "4" },
                    }
                },
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "2", "3" },
                        { "1", "2" },
                    }
                },
            };

            // use different concrete types
            IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> item2a = new Dictionary<string, IReadOnlyDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    new Dictionary<string, string>
                    {
                        { "3", "4" },
                        { "5", "6" },
                    }
                },
            };
            IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> item2b = new Dictionary<string, IReadOnlyDictionary<string, string>>
            {
                {
                    "whatever1",
                    new ReadOnlyDictionary<string, string>(
                        new Dictionary<string, string>
                        {
                            { "1", "2" },
                            { "2", "3" },
                        })
                },
                {
                    "whatever2",
                    new ReadOnlyDictionary<string, string>(
                        new Dictionary<string, string>
                        {
                            { "3", "4" },
                            { "5", "6" },
                        })
                },
            };

            // null inner dictionaries
            IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> item3a = new Dictionary<string, IReadOnlyDictionary<string, string>>
            {
                {
                    "whatever1",
                    new Dictionary<string, string>
                    {
                        { "1", "2" },
                        { "2", "3" },
                    }
                },
                {
                    "whatever2",
                    null
                },
            };
            IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> item3b = new Dictionary<string, IReadOnlyDictionary<string, string>>
            {
                {
                    "whatever1",
                    new ReadOnlyDictionary<string, string>(
                        new Dictionary<string, string>
                        {
                            { "1", "2" },
                            { "2", "3" },
                        })
                },
                {
                    "whatever2",
                    null
                },
            };

            // Act
            var actual1 = item1a.IsReadOnlyDictionaryEqualTo(item1b);
            var actual2 = item2a.IsReadOnlyDictionaryEqualTo(item2b);
            var actual3 = item3a.IsReadOnlyDictionaryEqualTo(item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_read_only_dictionaries_are_not_equal_and_values_are_ordered_collections()
        {
            // Arrange

            // enumerables are ordered differently
            IReadOnlyDictionary<string, IList<string>> item1a = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, IList<string>> item1b = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "jkl", "ghi" }
                },
            };

            // enumerables have different elements
            IReadOnlyDictionary<string, IList<string>> item2a = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, IList<string>> item2b = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi" }
                },
            };

            // Act
            var actual1 = item1a.IsReadOnlyDictionaryEqualTo(item1b);
            var actual2 = item2a.IsReadOnlyDictionaryEqualTo(item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_read_only_dictionaries_are_equal_and_values_are_ordered_collections()
        {
            // Arrange

            // different kinds of concrete ordered enumerables
            IReadOnlyDictionary<string, IList<string>> item1a = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, IList<string>> item1b = new Dictionary<string, IList<string>>
            {
                {
                    "whatever2",
                    new List<string> { "ghi", "jkl" }
                },
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
            };

            // null and empty enumerables
            IReadOnlyDictionary<string, IList<string>> item2a = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new string[0]
                },
                {
                    "whatever2",
                    null
                },
            };
            IReadOnlyDictionary<string, IList<string>> item2b = new Dictionary<string, IList<string>>
            {
                {
                    "whatever1",
                    new List<string>()
                },
                {
                    "whatever2",
                    null
                },
            };

            // Act
            var actual1 = item1a.IsReadOnlyDictionaryEqualTo(item1b);
            var actual2 = item2a.IsReadOnlyDictionaryEqualTo(item2b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_read_only_dictionaries_are_not_equal_and_values_are_not_ordered_collections()
        {
            // Arrange

            // enumerables have different elements
            IReadOnlyDictionary<string, IReadOnlyCollection<string>> item1a = new Dictionary<string, IReadOnlyCollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, IReadOnlyCollection<string>> item1b = new Dictionary<string, IReadOnlyCollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi" }
                },
            };

            // enumerables have different elements
            IReadOnlyDictionary<string, ICollection<string>> item2a = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, ICollection<string>> item2b = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl", "ghi" }
                },
            };

            // Act
            var actual1 = item1a.IsReadOnlyDictionaryEqualTo(item1b);
            var actual2 = item2a.IsReadOnlyDictionaryEqualTo(item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_read_only_dictionaries_are_equal_and_values_are_not_ordered_collections()
        {
            // Arrange

            // different kinds of concrete ordered enumerables
            IReadOnlyDictionary<string, ICollection<string>> item1a = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, ICollection<string>> item1b = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new List<string> { "ghi", "jkl" }
                },
            };

            // null and empty enumerables
            IReadOnlyDictionary<string, IReadOnlyCollection<string>> item2a = new Dictionary<string, IReadOnlyCollection<string>>
            {
                {
                    "whatever1",
                    new string[0]
                },
                {
                    "whatever2",
                    null
                },
            };
            IReadOnlyDictionary<string, IReadOnlyCollection<string>> item2b = new Dictionary<string, IReadOnlyCollection<string>>
            {
                {
                    "whatever1",
                    new List<string>()
                },
                {
                    "whatever2",
                    null
                },
            };

            // elements in different order
            IReadOnlyDictionary<string, ICollection<string>> item3a = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, ICollection<string>> item3b = new Dictionary<string, ICollection<string>>
            {
                {
                    "whatever2",
                    new[] { "jkl", "ghi" }
                },
                {
                    "whatever1",
                    new[] { "def", "abc" }
                },
            };

            // Act
            var actual1 = item1a.IsReadOnlyDictionaryEqualTo(item1b);
            var actual2 = item2a.IsReadOnlyDictionaryEqualTo(item2b);
            var actual3 = item3a.IsReadOnlyDictionaryEqualTo(item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_read_only_dictionaries_are_not_equal_and_values_are_enumerables()
        {
            // Arrange

            // enumerables have different elements
            IReadOnlyDictionary<string, IEnumerable<string>> item1a = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, IEnumerable<string>> item1b = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi" }
                },
            };

            // enumerables have different elements
            IReadOnlyDictionary<string, IEnumerable<string>> item2a = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, IEnumerable<string>> item2b = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl", "ghi" }
                },
            };

            // Act
            var actual1 = item1a.IsReadOnlyDictionaryEqualTo(item1b);
            var actual2 = item2a.IsReadOnlyDictionaryEqualTo(item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_read_only_dictionaries_are_equal_and_values_are_enumerables()
        {
            // Arrange

            // different kinds of concrete ordered enumerables
            IReadOnlyDictionary<string, IEnumerable<string>> item1a = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, IEnumerable<string>> item1b = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new List<string> { "ghi", "jkl" }
                },
            };

            // null and empty enumerables
            IReadOnlyDictionary<string, IEnumerable<string>> item2a = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new string[0]
                },
                {
                    "whatever2",
                    null
                },
            };
            IReadOnlyDictionary<string, IEnumerable<string>> item2b = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new List<string>()
                },
                {
                    "whatever2",
                    null
                },
            };

            // elements in different order
            IReadOnlyDictionary<string, IEnumerable<string>> item3a = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, IEnumerable<string>> item3b = new Dictionary<string, IEnumerable<string>>
            {
                {
                    "whatever2",
                    new[] { "jkl", "ghi" }
                },
                {
                    "whatever1",
                    new[] { "def", "abc" }
                },
            };

            // Act
            var actual1 = item1a.IsReadOnlyDictionaryEqualTo(item1b);
            var actual2 = item2a.IsReadOnlyDictionaryEqualTo(item2b);
            var actual3 = item3a.IsReadOnlyDictionaryEqualTo(item3b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_dictionaries_contain_different_equality_comparers_but_contain_the_same_keys_as_evaluated_by_those_comparers()
        {
            // Arrange
            IReadOnlyDictionary<string, ICollection<string>> item1 = new Dictionary<string, ICollection<string>>(StringComparer.Ordinal)
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, ICollection<string>> item2 = new Dictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };

            // Act
            var actual1 = item1.IsReadOnlyDictionaryEqualTo(item2);
            var actual2 = item2.IsReadOnlyDictionaryEqualTo(item1);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_dictionaries_contain_different_equality_comparers_and_contain_different_keys_as_evaluated_by_those_comparers()
        {
            // Arrange
            IReadOnlyDictionary<string, ICollection<string>> item1 = new Dictionary<string, ICollection<string>>(StringComparer.Ordinal)
            {
                {
                    "whatever1",
                    new[] { "abc", "def" }
                },
                {
                    "whatever2",
                    new[] { "ghi", "jkl" }
                },
            };
            IReadOnlyDictionary<string, ICollection<string>> item2 = new Dictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "WHATEVER1",
                    new[] { "abc", "def" }
                },
                {
                    "WHATEVER2",
                    new[] { "ghi", "jkl" }
                },
            };

            // Act
            var actual1 = item1.IsReadOnlyDictionaryEqualTo(item2);
            var actual2 = item2.IsReadOnlyDictionaryEqualTo(item1);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_dictionaries_contain_two_DateTime_values_having_the_same_Ticks_but_different_Kind_for_the_same_keys()
        {
            // Arrange
            var dateTime1 = DateTime.Now;
            var dateTime2 = DateTime.UtcNow;

            IReadOnlyDictionary<string, DateTime> item1 = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    dateTime1
                },
                {
                    "whatever2",
                    dateTime2
                },
            };

            IReadOnlyDictionary<string, DateTime> item2a = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    dateTime1
                },
                {
                    "whatever2",
                    new DateTime(dateTime2.Ticks, DateTimeKind.Local)
                },
            };

            IReadOnlyDictionary<string, DateTime> item2b = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    dateTime1
                },
                {
                    "whatever2",
                    new DateTime(dateTime2.Ticks, DateTimeKind.Unspecified)
                },
            };

            IReadOnlyDictionary<string, DateTime> item2c = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    new DateTime(dateTime1.Ticks, DateTimeKind.Unspecified)
                },
                {
                    "whatever2",
                    dateTime2
                },
            };

            // Act
            var actual1 = item1.IsReadOnlyDictionaryEqualTo(item2a);
            var actual2 = item1.IsReadOnlyDictionaryEqualTo(item2b);
            var actual3 = item1.IsReadOnlyDictionaryEqualTo(item2c);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_dictionaries_contain_two_DateTime_values_having_the_same_Ticks_and_same_Kind_for_the_same_keys()
        {
            // Arrange
            var dateTime1 = DateTime.Now;
            var dateTime2 = DateTime.UtcNow;
            var dateTime3 = new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified);

            IReadOnlyDictionary<string, DateTime> item1 = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    dateTime1
                },
                {
                    "whatever2",
                    dateTime2
                },
                {
                    "whatever3",
                    dateTime3
                },
            };

            IReadOnlyDictionary<string, DateTime> item2 = new Dictionary<string, DateTime>()
            {
                {
                    "whatever1",
                    dateTime1
                },
                {
                    "whatever2",
                    dateTime2
                },
                {
                    "whatever3",
                    dateTime3
                },
            };

            // Act
            var actual = item1.IsReadOnlyDictionaryEqualTo(item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_dictionaries_contain_two_Color_values_that_are_not_equal()
        {
            // Arrange
            var color1 = Color.FromArgb(255, 218, 185);
            var color2 = Color.FromArgb(255, 217, 185);

            IReadOnlyDictionary<string, Color> item1 = new Dictionary<string, Color>()
            {
                {
                    "whatever1",
                    color1
                },
                {
                    "whatever2",
                    color1
                },
            };

            IReadOnlyDictionary<string, Color> item2 = new Dictionary<string, Color>()
            {
                {
                    "whatever1",
                    color1
                },
                {
                    "whatever2",
                    color2
                },
            };

            // Act
            var actual1 = item1.IsReadOnlyDictionaryEqualTo(item2);

            // Assert
            actual1.Should().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_dictionaries_contain_two_Color_values_that_are_equal()
        {
            // Arrange
            var color1 = Color.FromArgb(255, 218, 185);
            var color2 = Color.PeachPuff;

            IReadOnlyDictionary<string, Color> item1 = new Dictionary<string, Color>()
            {
                {
                    "whatever1",
                    color1
                },
                {
                    "whatever2",
                    color2
                },
            };

            IReadOnlyDictionary<string, Color> item2 = new Dictionary<string, Color>()
            {
                {
                    "whatever1",
                    color2
                },
                {
                    "whatever2",
                    color1
                },
            };

            // Act
            var actual = item1.IsReadOnlyDictionaryEqualTo(item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_true___When_both_sequences_are_null()
        {
            // Arrange, Act
            var actual = EqualityExtensions.IsSequenceEqualTo<object>(null, null);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_true___When_one_but_not_both_sequences_are_null()
        {
            // Arrange
            var notNullSequence = A.Dummy<List<string>>();

            // Act
            var actual1 = EqualityExtensions.IsSequenceEqualTo<object>(notNullSequence, null);
            var actual2 = EqualityExtensions.IsSequenceEqualTo<object>(null, notNullSequence);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_same_result_as_SequenceEqual___When_both_sequences_are_not_null()
        {
            // Arrange
            var sequence1 = new[] { "abc", "def" };
            var sequence2 = new[] { "abc", "def" };
            var sequence3 = new[] { "abc", "def", "ghi" };
            var sequence4 = new string[0];
            var sequence5 = new string[0];
            var sequence6 = new[] { "aBc", "dEf" };

            // Act
            var actual1 = sequence1.SequenceEqual(sequence2);
            var actual2 = sequence2.SequenceEqual(sequence3);
            var actual3 = sequence3.SequenceEqual(sequence2);
            var actual4 = sequence4.SequenceEqual(sequence5);
            var actual5 = sequence1.SequenceEqual(sequence6);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeTrue();
            actual5.Should().BeFalse();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_same_result_as_SequenceEqual___When_both_sequences_are_not_null_and_equality_comparer_is_specified()
        {
            // Arrange
            var sequence1 = new[] { "abc", "def" };
            var sequence2 = new[] { "abc", "def" };
            var sequence3 = new[] { "abc", "def", "ghi" };
            var sequence4 = new string[0];
            var sequence5 = new string[0];
            var sequence6 = new[] { "aBc", "dEf" };

            // Act
            var actual1 = sequence1.IsSequenceEqualTo(sequence2, StringComparer.CurrentCultureIgnoreCase);
            var actual2 = sequence2.IsSequenceEqualTo(sequence3, StringComparer.CurrentCultureIgnoreCase);
            var actual3 = sequence3.IsSequenceEqualTo(sequence2, StringComparer.CurrentCultureIgnoreCase);
            var actual4 = sequence4.IsSequenceEqualTo(sequence5, StringComparer.CurrentCultureIgnoreCase);
            var actual5 = sequence1.IsSequenceEqualTo(sequence6, StringComparer.CurrentCultureIgnoreCase);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeTrue();
            actual5.Should().BeTrue();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_false___When_sets_contains_collections_and_sets_are_not_equal()
        {
            // sub-enumerables have items in different order and order matters
            var item1a = new List<List<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", "pqr" },
            };
            var item1b = new List<List<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "jkl", "ghi" },
                new List<string> { "mno", "pqr" },
            };

            // sub-enumerables have different items in different order, but order doesn't matter
            var item2a = new List<IReadOnlyCollection<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", "pqr" },
            };
            var item2b = new List<IReadOnlyCollection<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl", "ghi" },
                new List<string> { "mno", "pqr" },
            };

            // Act
            var actual1 = item1a.IsSequenceEqualTo(item1b);
            var actual2 = item2a.IsSequenceEqualTo(item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_true___When_sets_contain_collections_and_sets_are_equal()
        {
            // Arrange

            // sub-enumerables have same items in same order
            var item1a = new List<List<string>>
            {
                new List<string> { "abc", null, "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", "pqr" },
            };
            var item1b = new List<List<string>>
            {
                new List<string> { "abc", null, "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", "pqr" },
            };

            // sub-enumerables have same items in different order, but order doesn't matter
            var item2a = new List<IReadOnlyCollection<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", null, "pqr" },
            };
            var item2b = new List<IReadOnlyCollection<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "def", "abc" },
                new List<string> { "jkl", "ghi" },
                new List<string> { "mno", "pqr", null },
            };

            // Act
            var actual1 = item1a.IsSequenceEqualTo(item1b);
            var actual2 = item2a.IsSequenceEqualTo(item2b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_false___When_sets_contains_enumerables_and_sets_are_not_equal()
        {
            // sub-enumerables have different items in different order, but order doesn't matter
            var item1a = new List<IEnumerable<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", "pqr" },
            };
            var item1b = new List<IEnumerable<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl", "ghi" },
                new List<string> { "mno", "pqr" },
            };

            // Act
            var actual1 = item1a.IsSequenceEqualTo(item1b);

            // Assert
            actual1.Should().BeFalse();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_true___When_sets_contain_enumerables_and_sets_are_equal()
        {
            // Arrange

            // sub-enumerables have same items in different order, but order doesn't matter
            var item1a = new List<IEnumerable<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", null, "pqr" },
            };
            var item1b = new List<IEnumerable<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "def", "abc" },
                new List<string> { "jkl", "ghi" },
                new List<string> { "mno", "pqr", null },
            };

            // Act
            var actual1 = item1a.IsSequenceEqualTo(item1b);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_false___When_sets_contains_arrays_and_sets_are_not_equal()
        {
            // sub-enumerables have items in different order and order matters
            var item1a = new List<string[]>
            {
                new string[] { "abc", "def" },
                new string[] { "ghi", "jkl" },
                new string[] { "mno", "pqr" },
            };
            var item1b = new List<string[]>
            {
                new string[] { "abc", "def" },
                new string[] { "jkl", "ghi" },
                new string[] { "mno", "pqr" },
            };

            // Act
            var actual1 = item1a.IsSequenceEqualTo(item1b);

            // Assert
            actual1.Should().BeFalse();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_true___When_sets_contain_arrays_and_sets_are_equal()
        {
            // Arrange

            // sub-enumerables have same items in same order
            var item1a = new List<string[]>
            {
                new string[] { "abc", null, "def" },
                new string[] { "ghi", "jkl" },
                new string[] { "mno", "pqr" },
            };
            var item1b = new List<string[]>
            {
                new string[] { "abc", null, "def" },
                new string[] { "ghi", "jkl" },
                new string[] { "mno", "pqr" },
            };

            // Act
            var actual1 = item1a.IsSequenceEqualTo(item1b);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_false___When_sets_contain_dictionaries_and_sets_are_not_equal()
        {
            // Arrange
            var item1a = new List<IReadOnlyDictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "abc", "def" },
                    { "ghi", "jkl" },
                },
                new Dictionary<string, string>
                {
                    { "abc", "def" },
                    { "ghi", "jkl" },
                },
                new Dictionary<string, string>
                {
                    { "1", "3" },
                    { "2", "5" },
                },
            };
            var item1b = new List<IReadOnlyDictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "abc", "def" },
                    { "ghi", "jkl" },
                },
                new Dictionary<string, string>
                {
                    { "abc", "def" },
                    { "ghi", "jkl" },
                },
                new Dictionary<string, string>
                {
                    { "1", "3" },
                    { "2", "4" },
                },
            };

            // Act
            var actual1 = item1a.IsSequenceEqualTo(item1b);

            // Assert
            actual1.Should().BeFalse();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_false___When_sets_contain_dictionaries_and_sets_are_equal()
        {
            // Arrange
            var item1a = new List<IReadOnlyDictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "ghi", "jkl" },
                    { "abc", "def" },
                },
                new Dictionary<string, string>
                {
                    { "1", "2" },
                    { "3", "4" },
                },
            };
            var item1b = new List<IReadOnlyDictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "abc", "def" },
                    { "ghi", "jkl" },
                },
                new Dictionary<string, string>
                {
                    { "3", "4" },
                    { "1", "2" },
                },
            };

            // Act
            var actual1 = item1a.IsSequenceEqualTo(item1b);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_false___When_sets_contain_DateTime_objects_with_the_same_Ticks_but_different_Kind()
        {
            // Arrange
            var utcDateTime = DateTime.UtcNow;
            var localDateTime = DateTime.Now;

            var item1 = new List<DateTime>
            {
                utcDateTime,
                localDateTime,
            };

            var item2a = new List<DateTime>
            {
                new DateTime(utcDateTime.Ticks, DateTimeKind.Local),
                localDateTime,
            };

            var item2b = new List<DateTime>
            {
                new DateTime(utcDateTime.Ticks, DateTimeKind.Unspecified),
                localDateTime,
            };

            var item2c = new List<DateTime>
            {
                utcDateTime,
                new DateTime(localDateTime.Ticks, DateTimeKind.Unspecified),
            };

            // Act
            var actual1 = item1.IsSequenceEqualTo(item2a);
            var actual2 = item1.IsSequenceEqualTo(item2b);
            var actual3 = item1.IsSequenceEqualTo(item2c);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_true___When_sets_contain_DateTime_objects_with_the_same_Ticks_and_same_Kind()
        {
            // Arrange
            var utcDateTime = DateTime.UtcNow;
            var localDateTime = DateTime.Now;
            var unspecifiedDateTime = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);

            var item1 = new List<DateTime>
            {
                utcDateTime,
                localDateTime,
                unspecifiedDateTime,
            };

            var item2 = new List<DateTime>
            {
                utcDateTime,
                localDateTime,
                unspecifiedDateTime,
            };

            // Act
            var actual = item1.IsSequenceEqualTo(item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_false___When_sets_contain_different_Color_values()
        {
            // Arrange
            var color1 = Color.FromArgb(255, 255, 218, 185);
            var color2 = Color.FromArgb(123, 255, 218, 184);

            var item1 = new List<Color>
            {
                color1,
                color2,
            };

            var item2 = new List<Color>
            {
                color2,
                color1,
            };

            // Act
            var actual = item1.IsSequenceEqualTo(item2);

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void IsSequenceEqualTo___Should_return_true___When_sets_contain_the_same_Color_values()
        {
            // Arrange
            var color1 = Color.FromArgb(255, 218, 185);
            var color2 = Color.PeachPuff;

            var item1 = new List<Color>
            {
                Color.AliceBlue,
                color1,
                Color.DarkBlue,
            };

            var item2 = new List<Color>
            {
                Color.AliceBlue,
                color2,
                Color.DarkBlue,
            };

            // Act
            var actual = item1.IsSequenceEqualTo(item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_true___When_both_sequences_are_null()
        {
            // Arrange, Act
            var actual = EqualityExtensions.IsUnorderedEqualTo<object>(null, null);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_true___When_one_but_not_both_sequences_are_null()
        {
            // Arrange
            var notNullSequence = A.Dummy<List<string>>();

            // Act
            var actual1 = EqualityExtensions.IsUnorderedEqualTo(notNullSequence, null);
            var actual2 = EqualityExtensions.IsUnorderedEqualTo(null, notNullSequence);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_true___When_both_sets_are_empty()
        {
            // Arrange
            var item1 = new List<string>();
            var item2 = new List<string>();

            // Act
            var actual = item1.IsUnorderedEqualTo(item2, StringComparer.CurrentCulture);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_true___When_sets_are_the_same()
        {
            // Arrange
            var item1a = new List<string> { "abc" };
            var item1b = new List<string> { "abc" };

            var item2a = new List<string> { "abc", "DEF" };
            var item2b = new List<string> { "abc", "DEF" };

            var item3a = new List<string> { "DEF", "abc" };
            var item3b = new List<string> { "abc", "DEF" };

            var item4a = new List<string> { "abc", "def", "ghi", "jkl" };
            var item4b = new List<string> { "ghi", "abc", "jkl", "def" };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);
            var actual2 = item2a.IsUnorderedEqualTo(item2b);
            var actual3 = item3a.IsUnorderedEqualTo(item3b);
            var actual4 = item4a.IsUnorderedEqualTo(item4b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
            actual4.Should().BeTrue();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_false___When_one_set_is_empty_and_the_other_is_not()
        {
            // Arrange
            var item1a = new List<string>();
            var item1b = new List<string> { "abc" };

            var item2a = new List<string> { "abc", "DEF" };
            var item2b = new List<string>();

            var item3a = new List<string>();
            var item3b = new List<string> { "abc", "DEF" };

            var item4a = new List<string> { "abc", "def", "ghi", "jkl" };
            var item4b = new List<string>();

            var item5a = new List<string>();
            var item5b = new List<string> { "abc", "def", "ghi", "jkl" };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);
            var actual2 = item2a.IsUnorderedEqualTo(item2b);
            var actual3 = item3a.IsUnorderedEqualTo(item3b);
            var actual4 = item4a.IsUnorderedEqualTo(item4b);
            var actual5 = item5a.IsUnorderedEqualTo(item5b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_false___When_sets_have_one_or_more_differences()
        {
            // Arrange
            var item1a = new List<string> { "def" };
            var item1b = new List<string> { "abc" };

            var item2a = new List<string> { "abc", "DEF" };
            var item2b = new List<string> { "ghi" };

            var item3a = new List<string> { "DEF" };
            var item3b = new List<string> { "abc", "DEF" };

            var item4a = new List<string> { "abc", "def", "ghi", "jkl" };
            var item4b = new List<string> { "pqr", "def", "jkl", "mno" };

            var item5a = new List<string> { "ABC", "DEF", "GHI", "JKL" };
            var item5b = new List<string> { "abc", "def", "ghi", "jkl" };

            var item6a = new List<string> { "abc", "def", "ghi", "jkl" };
            var item6b = new List<string> { "abc", "def", "ghi", "jkl", "abc" };

            var item7a = new List<string> { "abc", "def", "ghi", "jkl", null };
            var item7b = new List<string> { "abc", "def", "ghi", "jkl" };

            var item8a = new List<string> { "abc", "def", "ghi", "jkl", null };
            var item8b = new List<string> { "abc", "def", "ghi", "jkl", null, null };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);
            var actual2 = item2a.IsUnorderedEqualTo(item2b);
            var actual3 = item3a.IsUnorderedEqualTo(item3b);
            var actual4 = item4a.IsUnorderedEqualTo(item4b);
            var actual5 = item5a.IsUnorderedEqualTo(item5b);
            var actual6 = item6a.IsUnorderedEqualTo(item6b);
            var actual7 = item7a.IsUnorderedEqualTo(item7b);
            var actual8 = item8a.IsUnorderedEqualTo(item8b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
            actual6.Should().BeFalse();
            actual7.Should().BeFalse();
            actual8.Should().BeFalse();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_false___When_called_with_case_insensitive_comparer_and_sets_have_one_or_more_differences()
        {
            // Arrange
            var item1a = new List<string> { "def" };
            var item1b = new List<string> { "abc" };

            var item2a = new List<string> { "abc", "DEF" };
            var item2b = new List<string> { "ghi" };

            var item3a = new List<string> { "DEF" };
            var item3b = new List<string> { "abc", "def" };

            var item4a = new List<string> { "abc", "DEF", "ghi", "jkl" };
            var item4b = new List<string> { "pqr", "def", "JKL", "mno" };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b, StringComparer.CurrentCultureIgnoreCase);
            var actual2 = item2a.IsUnorderedEqualTo(item2b, StringComparer.CurrentCultureIgnoreCase);
            var actual3 = item3a.IsUnorderedEqualTo(item3b, StringComparer.CurrentCultureIgnoreCase);
            var actual4 = item4a.IsUnorderedEqualTo(item4b, StringComparer.CurrentCultureIgnoreCase);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_true___When_called_with_case_insensitive_comparer_and_sets_are_equal()
        {
            // Arrange
            var item1a = new List<string> { "ABC", "DEF", null, "GHI", "JKL", "abc", "ghI" };
            var item1b = new List<string> { "abc", "def", "gHi", "aBc", "jkl", "ghi", null };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b, StringComparer.CurrentCultureIgnoreCase);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_false___When_sets_contain_collections_themselves_and_sets_have_one_or_more_differences()
        {
            // Arrange

            // sub-enumerables have items in different order and order matters
            var item1a = new List<List<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", "pqr" },
            };
            var item1b = new List<List<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "jkl", "ghi" },
                new List<string> { "mno", "pqr" },
            };

            // sub-enumerables have different items in different order, but order doesn't matter
            var item2a = new List<IReadOnlyCollection<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", "pqr" },
            };
            var item2b = new List<IReadOnlyCollection<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl", "ghi" },
                new List<string> { "mno", "pqr" },
            };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);
            var actual2 = item2a.IsUnorderedEqualTo(item2b);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_true___When_sets_contain_collections_themselves_and_sets_are_equal()
        {
            // Arrange

            // sub-enumerables have same items in same order, and order matters
            var item1a = new List<List<string>>
            {
                new List<string> { "abc", null, "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", "pqr" },
                new List<string> { "ghi", "jkl" },
            };
            var item1b = new List<List<string>>
            {
                new List<string> { "mno", "pqr" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "abc", null, "def" },
            };

            // sub-enumerables have same items in different order, but order doesn't matter
            var item2a = new List<IReadOnlyCollection<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", null, "pqr" },
            };
            var item2b = new List<IReadOnlyCollection<string>>
            {
                new List<string> { null, "mno", "pqr" },
                new List<string> { "jkl", "ghi" },
                new List<string> { "def", "abc" },
            };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);
            var actual2 = item2a.IsUnorderedEqualTo(item2b);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_false___When_sets_contain_enumerables_themselves_and_sets_have_one_or_more_differences()
        {
            // Arrange

            // sub-enumerables have different items in different order, but order doesn't matter
            var item1a = new List<IEnumerable<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", "pqr" },
            };
            var item1b = new List<IEnumerable<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl", "ghi" },
                new List<string> { "mno", "pqr" },
            };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);

            // Assert
            actual1.Should().BeFalse();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_true___When_sets_contain_enumerables_themselves_and_sets_are_equal()
        {
            // Arrange

            // sub-enumerables have same items in different order, but order doesn't matter
            var item1a = new List<IEnumerable<string>>
            {
                new List<string> { "abc", "def" },
                new List<string> { "ghi", "jkl" },
                new List<string> { "mno", null, "pqr" },
            };
            var item1b = new List<IEnumerable<string>>
            {
                new List<string> { null, "mno", "pqr" },
                new List<string> { "jkl", "ghi" },
                new List<string> { "def", "abc" },
            };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_false___When_sets_contain_arrays_and_sets_have_one_or_more_differences()
        {
            // Arrange

            // sub-enumerables have items in different order and order matters
            var item1a = new List<string[]>
            {
                new string[] { "abc", "def" },
                new string[] { "ghi", "jkl" },
                new string[] { "mno", "pqr" },
            };
            var item1b = new List<string[]>
            {
                new string[] { "abc", "def" },
                new string[] { "jkl", "ghi" },
                new string[] { "mno", "pqr" },
            };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);

            // Assert
            actual1.Should().BeFalse();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_true___When_sets_contain_arrays_and_sets_are_equal()
        {
            // Arrange

            // sub-enumerables have same items in same order, and order matters
            var item1a = new List<string[]>
            {
                new string[] { "abc", null, "def" },
                new string[] { "ghi", "jkl" },
                new string[] { "mno", "pqr" },
                new string[] { "ghi", "jkl" },
            };
            var item1b = new List<string[]>
            {
                new string[] { "mno", "pqr" },
                new string[] { "ghi", "jkl" },
                new string[] { "ghi", "jkl" },
                new string[] { "abc", null, "def" },
            };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_false___When_sets_contain_dictionaries_and_sets_have_one_or_more_differences()
        {
            // Arrange
            var item1a = new List<IReadOnlyDictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "abc", "def" },
                    { "ghi", "jkl" },
                },
                new Dictionary<string, string>
                {
                    { "abc", "def" },
                    { "ghi", "jkl" },
                },
                new Dictionary<string, string>
                {
                    { "1", "3" },
                    { "2", "5" },
                },
            };
            var item1b = new List<IReadOnlyDictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "abc", "def" },
                    { "ghi", "jkl" },
                },
                new Dictionary<string, string>
                {
                    { "1", "3" },
                    { "2", "4" },
                },
                new Dictionary<string, string>
                {
                    { "abc", "def" },
                    { "ghi", "jkl" },
                },
            };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);

            // Assert
            actual1.Should().BeFalse();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_true___When_sets_contain_dictionaries_and_sets_are_equal()
        {
            // Arrange
            var item1a = new List<IReadOnlyDictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "abc", "def" },
                    { "ghi", "jkl" },
                },
                new Dictionary<string, string>
                {
                    { "1", "2" },
                    { "3", "4" },
                },
            };
            var item1b = new List<IReadOnlyDictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "3", "4" },
                    { "1", "2" },
                },
                new Dictionary<string, string>
                {
                    { "ghi", "jkl" },
                    { "abc", "def" },
                },
            };

            // Act
            var actual1 = item1a.IsUnorderedEqualTo(item1b);

            // Assert
            actual1.Should().BeTrue();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_false___When_sets_contain_DateTime_objects_with_the_same_Ticks_but_different_Kind()
        {
            // Arrange
            var utcDateTime = DateTime.UtcNow;
            var localDateTime = DateTime.Now;

            var item1 = new List<DateTime>
            {
                utcDateTime,
                localDateTime,
            };

            var item2a = new List<DateTime>
            {
                new DateTime(utcDateTime.Ticks, DateTimeKind.Local),
                localDateTime,
            };

            var item2b = new List<DateTime>
            {
                new DateTime(utcDateTime.Ticks, DateTimeKind.Unspecified),
                localDateTime,
            };

            var item2c = new List<DateTime>
            {
                utcDateTime,
                new DateTime(localDateTime.Ticks, DateTimeKind.Unspecified),
            };

            // Act
            var actual1 = item1.IsUnorderedEqualTo(item2a);
            var actual2 = item1.IsUnorderedEqualTo(item2b);
            var actual3 = item1.IsUnorderedEqualTo(item2c);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_true___When_sets_contain_DateTime_objects_with_the_same_Ticks_and_same_Kind()
        {
            // Arrange
            var utcDateTime = DateTime.UtcNow;
            var localDateTime = DateTime.Now;
            var unspecifiedDateTime = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);

            var item1 = new List<DateTime>
            {
                utcDateTime,
                localDateTime,
                unspecifiedDateTime,
            };

            var item2 = new List<DateTime>
            {
                localDateTime,
                unspecifiedDateTime,
                utcDateTime,
            };

            // Act
            var actual = item1.IsUnorderedEqualTo(item2);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_false___When_sets_contain_different_Color_values()
        {
            // Arrange
            var color1 = Color.FromArgb(253, 218, 185);
            var color2 = Color.FromArgb(255, 218, 184);

            var item1 = new List<Color>
            {
                color1,
                color1,
            };

            var item2 = new List<Color>
            {
                color1,
                color2,
            };

            // Act
            var actual = item1.IsUnorderedEqualTo(item2);

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void IsUnorderedEqualTo___Should_return_false___When_sets_contain_the_same_Color_values()
        {
            // Arrange
            var color1 = Color.FromArgb(255, 218, 185);
            var color2 = Color.PeachPuff;

            var item1 = new List<Color>
            {
                Color.AliceBlue,
                Color.DarkBlue,
                color1,
            };

            var item2 = new List<Color>
            {
                Color.DarkBlue,
                color2,
                Color.AliceBlue,
            };

            // Act
            var actual = item1.IsUnorderedEqualTo(item2);

            // Assert
            actual.Should().BeTrue();
        }
    }
}
