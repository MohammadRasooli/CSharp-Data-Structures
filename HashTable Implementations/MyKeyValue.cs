// Represents a generic key/value pair.
public class MyKeyValue<TKey, TValue>
{
    // Gets or sets the key in the key/value pair.
    public TKey Key { get; set; }

    // Gets or sets the value in the key/value pair.
    public TValue Value { get; set; }

    // Initializes a new instance of the MyKeyValue class with the specified key and value.
    public MyKeyValue(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}