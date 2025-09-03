public class MyKeyValue<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }

    public MyKeyValue(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}