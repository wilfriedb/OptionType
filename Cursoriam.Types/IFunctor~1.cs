namespace Cursoriam.Types;

// Deze interfaces gaan dus niet werken, want de select is niet covariant (of andersom), 
// en de selectmany kan geen IMonad teruggeven, wan het moet wel een endofunctor zijn
public interface IFunctor<T>
{
    IFunctor<R> Select<R>(Func<T, R> map);
}

public interface IMonad<T> : IFunctor<T>
{
    IMonad<R> SelectMany<R>(Func<T, IMonad<R>> bind);
}
