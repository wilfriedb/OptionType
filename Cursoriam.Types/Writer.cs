namespace Cursoriam.Types;
// De blogpost
// https://bartoszmilewski.com/2014/12/23/kleisli-categories/
// en
// https://mmhaskell.com/monads/reader-writer
// geven een tegenstrijdige en verwarrende beschrijving van de Writer monad.
// Zowel beschrijving als gebruik komen niet overeen.

public interface IWriter<V, L>
{

}

public struct StringWriter<V> : IWriter<V, string>
{
    const string mempty = "";
    private readonly V item;
    private readonly string log;

    // Return and bind make a functor

    // Return
    public StringWriter(V item)
    {
        this.item = item;
        log = mempty;
    }

    public StringWriter(V item, string log)
    {
        this.item = item;
        this.log = log;
    }

    // Bind
    public StringWriter<R> SelectMany<R>(Func<V, StringWriter<R>> selector)
    {
        var result = selector(item);
        return new(result.item, log + result.log);
    }

    // Map
    // Map is Bind plus Return 
    public StringWriter<R> Select<R>(Func<V, R> selector)
        => SelectMany(item => new StringWriter<R>(selector(item)));

    // Being composable is a property of a monad
    public Func<T, StringWriter<T2>> Compose<T, T1, T2>(Func<T, StringWriter<T1>> f, Func<T1, StringWriter<T2>> g)
        => x => f(x).SelectMany(g);
}