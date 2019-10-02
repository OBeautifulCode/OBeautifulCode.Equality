// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualityExtensionsTest.cs" company="OBeautifulCode">
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

    public static class EqualityExtensionsTest
    {
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
        public static void IsDictionaryEqualTo___Should_return_true___When_one_but_not_both_dictionaries_are_null()
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
        public static void IsDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal_and_values_are_ordered_enumerables()
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
        public static void IsDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal_and_values_are_ordered_enumerables()
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
        public static void IsDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal_and_values_are_not_ordered_enumerables()
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
        public static void IsDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal_and_values_are_not_ordered_enumerables()
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
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_both_dictionaries_are_null()
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
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_one_but_not_both_dictionaries_are_null()
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
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal()
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
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal()
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
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal_and_values_are_dictionaries_themselves()
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
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal_and_values_are_dictionaries_themselves()
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
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal_and_values_are_ordered_enumerables()
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
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal_and_values_are_ordered_enumerables()
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
        public static void IsReadOnlyDictionaryEqualTo___Should_return_false___When_dictionaries_are_not_equal_and_values_are_not_ordered_enumerables()
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
        public static void IsReadOnlyDictionaryEqualTo___Should_return_true___When_dictionaries_are_equal_and_values_are_not_ordered_enumerables()
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
        public static void IsSequenceEqualTo___Should_return_false___When_sets_contains_IEnumerables_and_sets_are_not_equal()
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
        public static void IsSequenceEqualTo___Should_return_true___When_sets_contain_IEnumerables_and_sets_are_equal()
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
        public static void IsUnorderedEqualTo___Should_return_false___When_sets_contain_IEnumerables_themselves_and_sets_have_one_or_more_differences()
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
        public static void IsUnorderedEqualTo___Should_return_true___When_sets_contain_IEnumerables_themselves_and_sets_are_equal()
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
    }
}
