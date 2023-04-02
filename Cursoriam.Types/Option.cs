
namespace Cursoriam.Types;

public readonly struct Option<T>
{
    private readonly bool hasItem;
    private readonly T? _value;

    public Option()
    {
        hasItem = false;
    }

    public Option(T value)
    {
        if (value is null)
        {
            throw new NullReferenceException($"{nameof(value)} is null, check before use.");
        }
        _value = value;
        hasItem = true;
    }

    public T Value
    {
        get
        {
            if (_value == null)
            {
                throw new NullReferenceException("Option is None, check before use.");
            }
            return _value;
        }
    }

    public bool IsSome => hasItem;

    public bool IsNone => !IsSome;

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
        => Bind(unwrapped => new Option<R>(selector(unwrapped)));

    public Option<R> Bind<R>(Func<T, Option<R>> function)
    {
        if (IsSome)
        {
            var unwrapped = Value;
            var result = function(unwrapped);
            return result;
        }
        return new Option<R>();
    }
}
