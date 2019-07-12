public class PairWithKey<T, Y, Z>
{
    public T key { get; }
    public Y first { get; set; }
    public Z second { get; set; }

    internal PairWithKey(T valueKey, Y valueFirst, Z valueSecond)
    {
        key = valueKey;
        first = valueFirst;
        second = valueSecond;
    }
}

public class TripleWithKey<T, X, Y, Z>
{
    public T key { get; }
    public X first { get; set; }
    public Y second { get; set; }
    public Z third { get; set; }

    internal TripleWithKey(T valueKey, X valueFirst, Y valueSecond, Z valueThird)
    {
        key = valueKey;
        first = valueFirst;
        second = valueSecond;
        third = valueThird;
    }
}