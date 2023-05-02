namespace Cursoriam.Types;

public static class NullableExtensions
{

    public static Nullable<R> Select<T, R>(this Nullable<T> nullable, Func<T, R> mapper)
        where T : struct
        where R : struct
    {
        return nullable.SelectMany(n => new Nullable<R>(mapper(n)));
    }

    public static Nullable<R> SelectMany<T, R>(this Nullable<T> nullable, Func<T, Nullable<R>> binder)
        where T : struct
        where R : struct
    {
        if (nullable.HasValue)
        {
            return binder(nullable.Value);
        }
        return default;
    }

    public static Nullable<R> SelectMany<T, U, R>(this Nullable<T> nullable, Func<T, Nullable<U>> binder, Func<T, U, R> projector)
        where T : struct
        where U : struct
        where R : struct
    {
        return nullable.SelectMany(x=> binder(x).Select(y => projector(x, y)));
    }
}
