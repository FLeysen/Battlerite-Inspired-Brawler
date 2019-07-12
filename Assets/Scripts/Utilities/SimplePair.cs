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