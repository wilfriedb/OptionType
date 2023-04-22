namespace Cursoriam.Types;

public readonly struct Identity<T>
{

    private readonly T value;

    public Identity(T value)
    {
        this.value = value;
    }

    public T Value => value;

    public Identity<R> Select<R>(Func<T, R> map)
        => new(map(value));

    public Identity<R> SelectMany<R>(Func<T, Identity<R>> bind)
    {
        var result = bind(value);
        return result;
    }
}