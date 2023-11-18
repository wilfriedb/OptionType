using System.Numerics;

namespace Cursoriam.Composition;
public static class Numerics
{
    public static T Double<T>(T value)
    where T : INumber<T>
    => value * T.CreateChecked(2);

    public static Func<T, T> Quadruple<T>() where T : INumber<T> => f => Double(Double(f));

    static void Test()
    {
        var result = Double(2);
        var result2 = Quadruple<int>()(2);
        
    }
}
