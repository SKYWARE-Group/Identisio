﻿using System;

namespace Skyware.Identisio;

/// <summary>
/// Abstract class for all the identifiers in the library
/// </summary>
public abstract class IdentifierBase
{

    /// <summary>
    /// By design the IdentifierBase class and its ancestors are not meant to be instantiated directly. They are immutable.
    /// </summary>
    protected IdentifierBase() { }

    /// <summary>
    /// Value of the identifier.
    /// </summary>
    public string Value { get; protected set; }

    /// <summary>
    /// Full identifier name in English.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Abbreviation in the native language
    /// Examples: 'SSN', 'ЕГН', etc.
    /// </summary>
    public abstract string NativeAbbreviation { get; }

    /// <summary>
    /// Name according to the native language and regulation
    /// Examples: "Единен граждански номер", "Social Security Number", etc.
    /// </summary>
    public abstract string NativeName { get; }

    /// <summary>
    /// GDPR, HIPPA or equivalent regulation flag
    /// </summary>
    public abstract bool IsPrivateData { get; }

    /// <summary>
    /// Validate the identifier
    /// </summary>
    /// <param name="value">The value of the identifier</param>
    /// <returns>Result of the validation</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static bool Validate(string value) => throw new NotImplementedException();

}
