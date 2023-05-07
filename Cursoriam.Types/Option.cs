using System.Diagnostics.CodeAnalysis;
namespace Cursoriam.Types;

public readonly struct Option<T>
{
    private readonly T? item;

    public Option()
    {
    }

    public Option(T value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        item = value;
    }

    // public T Value
    // {
    //     get
    //     {
    //         if (item == null)
    //         {
    //             throw new NullReferenceException("Option is None, check before use.");
    //         }
    //         return item;
    //     }
    // }

    [MemberNotNullWhen(true, nameof(item))]
    public bool IsSome => item is not null;

    [MemberNotNullWhen(false, nameof(item))]
    public bool IsNone => !IsSome;

    public static Option<T> Return(T value) => new(value);

    /// <summary>
    /// The Select method is in functional programming languages also known as 
    /// map (OCaml, python) or fmap (Haskell)
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <typeparam name="R"></typeparam>
    /// <param name="option"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public Option<R> Select<R>(Func<T, R> selector)
        => SelectMany(unwrapped => Option<R>.Return(selector(unwrapped)));

    /// <summary>
    /// The SelectMany method is in functional programming languages also known as
    /// bind (OCaml, python) or flatMap (Haskell)
    /// </summary>
    public Option<R> SelectMany<R>(Func<T, Option<R>> function)
    {
        if (IsSome)
        {
            var result = function(item);
            return result;
        }
        return new Option<R>();
    }

    public override string ToString()
        => IsSome ? $"Some({item})" : "None";
}

public static class OptionExtensions
{
    public static Option<R> Flatten<R>(this Option<Option<R>> option)
       => option.SelectMany(x => x);
}
