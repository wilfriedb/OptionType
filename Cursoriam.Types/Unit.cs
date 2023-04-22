namespace Cursoriam.Types;

public sealed class Unit
{
    private Unit() { }

    public static readonly Unit Value = new();

    public static bool operator ==(Unit left, Unit right) => true;

    public static bool operator !=(Unit left, Unit right) => false;

    public override bool Equals(object? obj) => obj is Unit;

    public override int GetHashCode() => 0;

    public override string ToString() => "()";
}
