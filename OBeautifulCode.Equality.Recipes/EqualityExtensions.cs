﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in OBeautifulCode.Equality.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using OBeautifulCode.Type.Recipes;

    /// <summary>
    /// Extension methods that test for equality between two objects.
    /// </summary>
#if !OBeautifulCodeEqualityRecipesProject
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("OBeautifulCode.Equality.Recipes", "See package version number")]
    internal
#else
    public
#endif
    static class EqualityExtensions
    {
        /// <summary>
        /// Compares objects for equality.
        /// </summary>
        /// <typeparam name="T">The type of objects to compare.</typeparam>
        /// <param name="item1">The first object to compare.</param>
        /// <param name="item2">The second object to compare.</param>
        /// <param name="comparer">Optional equality comparer to use to compare the objects.  Default is to call <see cref="GetEqualityComparerToUse{T}(IEqualityComparer{T})"/>.</param>
        /// <returns>
        /// - true if the two objects are equal
        /// - otherwise, false.
        /// </returns>
        public static bool IsEqualTo<T>(
            this T item1,
            T item2,
            IEqualityComparer<T> comparer = null)
        {
            if (ReferenceEquals(item1, item2))
            {
                return true;
            }

            if (ReferenceEquals(item1, null) || ReferenceEquals(item2, null))
            {
                return false;
            }

            var equalityComparerToUse = GetEqualityComparerToUse(comparer);

            var result = equalityComparerToUse.Equals(item1, item2);

            return result;
        }

        /// <summary>
        /// Compares two dictionaries for equality.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionaries.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionaries.</typeparam>
        /// <param name="item1">The first <see cref="IReadOnlyDictionary{TKey, TValue}"/> to compare.</param>
        /// <param name="item2">The second <see cref="IReadOnlyDictionary{TKey, TValue}"/> to compare.</param>
        /// <param name="valueComparer">Optional equality comparer to use to compare values.  Default is to call <see cref="GetEqualityComparerToUse{T}(IEqualityComparer{T})"/>.</param>
        /// <returns>
        /// - true if the two source dictionaries are null.
        /// - false if one or the other is null.
        /// - false if the dictionaries are of different length.
        /// - true if the two dictionaries are of equal length and their values are equal for the same keys.
        /// - otherwise, false.
        /// </returns>
        public static bool IsDictionaryEqualTo<TKey, TValue>(
            this IDictionary<TKey, TValue> item1,
            IDictionary<TKey, TValue> item2,
            IEqualityComparer<TValue> valueComparer = null)
        {
            if (ReferenceEquals(item1, item2))
            {
                return true;
            }

            if (ReferenceEquals(item1, null) || ReferenceEquals(item2, null))
            {
                return false;
            }

            if (item1.Keys.Count != item2.Keys.Count)
            {
                return false;
            }

            IEqualityComparer<TValue> valueEqualityComparerToUse = null;

            foreach (var key in item1.Keys)
            {
                if (!item2.ContainsKey(key))
                {
                    return false;
                }

                var item1Value = item1[key];
                var item2Value = item2[key];

                if (valueEqualityComparerToUse == null)
                {
                    valueEqualityComparerToUse = GetEqualityComparerToUse(valueComparer);
                }

                if (!valueEqualityComparerToUse.Equals(item1Value, item2Value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Compares two dictionaries for equality.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionaries.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionaries.</typeparam>
        /// <param name="item1">The first <see cref="IReadOnlyDictionary{TKey, TValue}"/> to compare.</param>
        /// <param name="item2">The second <see cref="IReadOnlyDictionary{TKey, TValue}"/> to compare.</param>
        /// <param name="valueComparer">Optional equality comparer to use to compare values.  Default is to call <see cref="GetEqualityComparerToUse{T}(IEqualityComparer{T})"/>.</param>
        /// <returns>
        /// - true if the two source dictionaries are null.
        /// - false if one or the other is null.
        /// - false if the dictionaries are of different length.
        /// - true if the two dictionaries are of equal length and their values are equal for the same keys.
        /// - otherwise, false.
        /// </returns>
        public static bool IsReadOnlyDictionaryEqualTo<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> item1,
            IReadOnlyDictionary<TKey, TValue> item2,
            IEqualityComparer<TValue> valueComparer = null)
        {
            if (ReferenceEquals(item1, item2))
            {
                return true;
            }

            if (ReferenceEquals(item1, null) || ReferenceEquals(item2, null))
            {
                return false;
            }

            if (item1.Keys.Count() != item2.Keys.Count())
            {
                return false;
            }

            IEqualityComparer<TValue> valueEqualityComparerToUse = null;

            foreach (var key in item1.Keys)
            {
                if (!item2.ContainsKey(key))
                {
                    return false;
                }

                var item1Value = item1[key];
                var item2Value = item2[key];

                if (valueEqualityComparerToUse == null)
                {
                    valueEqualityComparerToUse = GetEqualityComparerToUse(valueComparer);
                }

                if (!valueEqualityComparerToUse.Equals(item1Value, item2Value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Compares two dictionaries for equality.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements of the input sequences.</typeparam>
        /// <param name="item1">An <see cref="IEnumerable{T}"/> to compare to <paramref name="item2"/>.</param>
        /// <param name="item2">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
        /// <param name="elementComparer">Optional equality comparer to use to compare the elements.  Default is to call <see cref="GetEqualityComparerToUse{T}(IEqualityComparer{T})"/>.</param>
        /// <returns>
        /// - true if the two source sequences are null.
        /// - false if one or the other is null.
        /// - true if the two sequences are of equal length and their corresponding elements are equal according to <paramref name="elementComparer"/>.
        /// - otherwise, false.
        /// </returns>
        public static bool IsSequenceEqualTo<TElement>(
            this IEnumerable<TElement> item1,
            IEnumerable<TElement> item2,
            IEqualityComparer<TElement> elementComparer = null)
        {
            if (ReferenceEquals(item1, item2))
            {
                return true;
            }

            if (ReferenceEquals(item1, null) || ReferenceEquals(item2, null))
            {
                return false;
            }

            var equalityComparerToUse = GetEqualityComparerToUse(elementComparer);

            var result = item1.SequenceEqual(item2, equalityComparerToUse);

            return result;
        }

        /// <summary>
        /// Determines if two enumerables have the exact same elements in any order.
        /// Every unique element in the first set has to appear in the second set the same number of times it appears in the first.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements of the input sequences.</typeparam>
        /// <param name="item1">An <see cref="IEnumerable{T}"/> to compare to <paramref name="item2"/>.</param>
        /// <param name="item2">An <see cref="IEnumerable{T}"/> to compare to the first sequence.</param>
        /// <param name="elementComparer">Optional equality comparer to use to compare the elements.  Default is to call <see cref="GetEqualityComparerToUse{T}(IEqualityComparer{T})"/>.</param>
        /// <returns>
        /// - true if the two source sequences are null.
        /// - false if one or the other is null.
        /// - false if there is any symmetric difference.
        /// - true if the two sequences both contain the same number of elements for each unique element.
        /// - otherwise, false.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "This is not excessively complex.")]
        public static bool IsUnorderedEqualTo<TElement>(
            this IEnumerable<TElement> item1,
            IEnumerable<TElement> item2,
            IEqualityComparer<TElement> elementComparer = null)
        {
            if (ReferenceEquals(item1, item2))
            {
                return true;
            }

            if (ReferenceEquals(item1, null) || ReferenceEquals(item2, null))
            {
                return false;
            }

            var equalityComparerToUse = GetEqualityComparerToUse(elementComparer);

            // ReSharper disable once PossibleMultipleEnumeration
            var item1AsList = item1.ToList();

            // ReSharper disable once PossibleMultipleEnumeration
            var item2AsList = item2.ToList();

            if (item1AsList.Count != item2AsList.Count)
            {
                return false;
            }

            foreach (var item1Element in item1AsList)
            {
                var elementFound = false;

                for (var x = 0; x < item2AsList.Count; x++)
                {
                    var item2Element = item2AsList[x];

                    if (equalityComparerToUse.Equals(item1Element, item2Element))
                    {
                        item2AsList.RemoveAt(x);

                        elementFound = true;

                        break;
                    }
                }

                if (!elementFound)
                {
                    return false;
                }
            }

            return true;
        }

        private static IEqualityComparer<T> GetEqualityComparerToUse<T>(
            IEqualityComparer<T> comparer)
        {
            var type = typeof(T);

            IEqualityComparer<T> result;

            if (comparer != null)
            {
                result = comparer;
            }
            else if (type.IsSystemDictionaryType())
            {
                var genericArguments = type.GetGenericArguments();

                // IDictionary is the only System dictionary type that doesn't implement IReadOnlyDictionary
                // which is why we have to special-case it here.
                var equalityComparerConstructorInfo = type.GetGenericTypeDefinition() == typeof(IDictionary<,>)
                    ? typeof(DictionaryEqualityComparer<,>).MakeGenericType(genericArguments).GetConstructor(new Type[0])
                    : typeof(ReadOnlyDictionaryEqualityComparer<,>).MakeGenericType(genericArguments).GetConstructor(new Type[0]);

                // ReSharper disable once PossibleNullReferenceException
                result = (IEqualityComparer<T>)equalityComparerConstructorInfo.Invoke(null);
            }
            else if (type.IsArray)
            {
                var constructorInfo = typeof(EnumerableEqualityComparer<>).MakeGenericType(type.GetElementType()).GetConstructor(new[] { typeof(EnumerableEqualityComparerStrategy) });

                // ReSharper disable once PossibleNullReferenceException
                result = (IEqualityComparer<T>)constructorInfo.Invoke(new object[] { EnumerableEqualityComparerStrategy.SequenceEqual });
            }
            else if (type.IsSystemCollectionType())
            {
                var genericArguments = type.GetGenericArguments();

                var constructorInfo = typeof(EnumerableEqualityComparer<>).MakeGenericType(genericArguments[0]).GetConstructor(new[] { typeof(EnumerableEqualityComparerStrategy) });

                var enumerableEqualityComparerStrategy = type.IsSystemOrderedCollectionType() ? EnumerableEqualityComparerStrategy.SequenceEqual : EnumerableEqualityComparerStrategy.UnorderedEqual;

                // ReSharper disable once PossibleNullReferenceException
                result = (IEqualityComparer<T>)constructorInfo.Invoke(new object[] { enumerableEqualityComparerStrategy });
            }
            else
            {
                result = EqualityComparer<T>.Default;
            }

            return result;
        }
    }
}
