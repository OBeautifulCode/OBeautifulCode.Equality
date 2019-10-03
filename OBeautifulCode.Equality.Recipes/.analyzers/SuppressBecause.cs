// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SuppressBecause.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in OBeautifulCode.Build source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Equality.Recipes.Internal
{
    using System.CodeDom.Compiler;
    using System.Diagnostics.CodeAnalysis;
    
    /// <summary>
    /// Standard justifications for analysis suppression.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [GeneratedCode("OBeautifulCode.Build.Analyzers", "See package version number")]
    internal static class ObcSuppressBecause
    {
        /// <summary>
        /// Console executable does not need the [assembly: CLSCompliant(true)] as it should not be shared as an assembly for reference.
        /// </summary>
        public const string CA1014_MarkAssembliesWithClsCompliant_ConsoleExeDoesNotNeedToBeClsCompliant = "Console executable does not need the [assembly: CLSCompliant(true)] as it should not be shared as an assembly for reference.";

        /// <summary>
        /// We are optimizing for the logical grouping of types rather than the number of types in a namepace.
        /// </summary>
        public const string CA1020_AvoidNamespacesWithFewTypes_OptimizeForLogicalGroupingOfTypes = "We are optimizing for the logical grouping of types rather than the number of types in a namepace.";

        /// <summary>
        /// When we need to identify a group of types, we prefer the use of an empty interface over an attribute because it's easier to use and results in cleaner code.
        /// </summary>
        public const string CA1040_AvoidEmptyInterfaces_NeedToIdentifyGroupOfTypesAndPreferInterfaceOverAttribute = "When we need to identify a group of types, we prefer the use of an empty interface over an attribute because it's easier to use and results in cleaner code.";

        /// <summary>
        /// It's ok to throw NotImplementedException in a code path that we believe will never be called.
        /// </summary>
        public const string CA1065_DoNotRaiseExceptionsInUnexpectedLocations_ThrowNotImplementedExceptionForCodePathThatWillNeverBeCalled = "It's ok to throw NotImplementedException in a code path that we believe will never be called.";

        /// <summary>
        /// We prefer to read <see cref="System.Guid" />'s string representation as lowercase.
        /// </summary>
        public const string CA1308_NormalizeStringsToUppercase_PreferGuidLowercase = "We prefer to read System.Guid's string representation as lowercase.";
    }
}
