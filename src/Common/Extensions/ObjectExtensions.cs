using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using JetBrains.Annotations;

namespace Common.Extensions;

public static class ObjectExtensions
{
    /// <summary>
    ///     Auto-maps the <see cref="source" /> to a new instance of the <see cref="TTarget" /> instance
    /// </summary>
    public static TTarget Convert<TSource, TTarget>(this TSource source)
    {
        var configuration = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TTarget>());
        var mapper = configuration.CreateMapper();

        return mapper.Map<TTarget>(source);
    }

    /// <summary>
    ///     Whether the object does exist
    /// </summary>
    [ContractAnnotation("null => false; notnull => true")]
    public static bool Exists([NotNullWhen(true)] this object? instance)
    {
        return instance is not null;
    }

    /// <summary>
    ///     Whether the parameter <see cref="value" /> from being invalid according to the <see cref="validation" />,
    ///     and if invalid, returns a <see cref="ErrorCode.Validation" /> error
    /// </summary>
    public static bool IsInvalidParameter<TValue>(this TValue? value, Predicate<TValue> predicate,
        string parameterName, string? errorMessage, out Error error)
    {
        if (value.NotExists())
        {
            error = errorMessage.HasValue()
                ? Error.Validation(errorMessage)
                : Error.Validation(parameterName);
            return true;
        }

        return IsInvalidParameter(() => predicate(value), parameterName, errorMessage, out error);
    }

    /// <summary>
    ///     Whether the parameter <see cref="value" /> from being invalid according to the <see cref="validation" />,
    ///     and if invalid, returns a <see cref="ErrorCode.Validation" /> error
    /// </summary>
    public static bool IsInvalidParameter<TValue>(this TValue? value, Predicate<TValue> predicate,
        string parameterName, out Error error)
    {
        if (value.NotExists())
        {
            error = Error.Validation(parameterName);
            return true;
        }

        return IsInvalidParameter(() => predicate(value), parameterName, null, out error);
    }

    /// <summary>
    ///     Whether the parameter <see cref="value" /> has any value,
    ///     and if invalid, returns a <see cref="ErrorCode.Validation" /> error
    /// </summary>
    public static bool IsNotValuedParameter(this string? value, string parameterName, string? errorMessage,
        out Error error)
    {
        return IsInvalidParameter(value.HasValue, parameterName, errorMessage, out error);
    }

    /// <summary>
    ///     Whether the parameter <see cref="value" /> has any value,
    ///     and if invalid, returns a <see cref="ErrorCode.Validation" /> error
    /// </summary>
    public static bool IsNotValuedParameter(this string? value, string parameterName, out Error error)
    {
        return IsInvalidParameter(value.HasValue, parameterName, null, out error);
    }

    /// <summary>
    ///     Whether the object does not exist
    /// </summary>
    [ContractAnnotation("null => true; notnull => false")]
    public static bool NotExists([NotNullWhen(false)] this object? instance)
    {
        return instance is null;
    }

    /// <summary>
    ///     Populates the public properties of the <see cref="target" /> instance with the values of matching public properties
    ///     of the
    ///     <see cref="source" /> instance, whether those values have default or non-default values.
    /// </summary>
    public static void PopulateWith<TType>(this TType target, TType source)
    {
        target.PopulateWith(source.ToObjectDictionary());
    }

    /// <summary>
    ///     Populates the public properties of the <see cref="target" /> instance with the values of matching properties of the
    ///     <see cref="source" /> instance, whether those values have default or non-default values.
    /// </summary>
    public static void PopulateWith<TType>(this TType target, IReadOnlyDictionary<string, object?> source)
    {
        var configuration = new MapperConfiguration(_ => { });
        var mapper = configuration.CreateMapper();

        mapper.Map(source, target);
    }

    /// <summary>
    ///     Throws an <see cref="ArgumentOutOfRangeException" /> if the specified <see cref="value" /> is invalid
    /// </summary>
    public static void ThrowIfInvalidParameter<TValue>(this TValue? value, Predicate<TValue?> predicate,
        string parameterName, string? errorMessage = null)
    {
        if (value.IsInvalidParameter(predicate, parameterName, errorMessage, out _))
        {
            throw new ArgumentOutOfRangeException(parameterName, errorMessage);
        }
    }

    /// <summary>
    ///     Throws an <see cref="ArgumentOutOfRangeException" /> if the specified <see cref="value" /> does not have a value
    /// </summary>
    public static void ThrowIfNotValuedParameter(this string? value, string parameterName, string? errorMessage = null)
    {
        if (value.IsNotValuedParameter(parameterName, errorMessage, out _))
        {
            throw new ArgumentOutOfRangeException(parameterName, errorMessage);
        }
    }

    private static bool IsInvalidParameter(Func<bool> predicate, string parameterName, string? errorMessage,
        out Error error)
    {
        var isValid = predicate();
        if (!isValid)
        {
            error = errorMessage.HasValue()
                ? Error.Validation(errorMessage)
                : Error.Validation(parameterName);
            return true;
        }

        error = Error.NoError;
        return false;
    }
}