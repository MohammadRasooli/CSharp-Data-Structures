// A generic dynamic array implementation.
public class DynamicArray<T>
{
    // The internal array to store the elements.
    private T[] _items;

    // The number of elements currently in the array.
    private int _count;

    // The default capacity of the array if not specified.
    private const int DefaultCapacity = 4;

    // Default constructor that initializes the array with the default capacity.
    public DynamicArray() : this(DefaultCapacity)
    {
    }

    // Constructor that allows specifying the initial capacity.
    public DynamicArray(int initialCapacity)
    {
        // Check if the initial capacity is negative.
        if (initialCapacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Capacity cannot be negative.");
        }
        // Initialize the internal array with the specified capacity.
        _items = new T[initialCapacity];
        // Start with zero elements.
        _count = 0;
    }

    // Gets or sets the element at the specified index.
    public T this[int index]
    {
        get
        {
            // Check if the index is out of the valid range.
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }
            return _items[index];
        }
        set
        {
            // Check if the index is out of the valid range.
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }
            _items[index] = value;
        }
    }

    // Adds an item to the end of the array.
    public void Add(T item)
    {
        // If the array is full, resize it.
        if (_count == _items.Length)
        {
            Resize();
        }

        // Add the new item at the end.
        _items[_count] = item;
        // Increment the count of elements.
        _count++;
    }

    // Doubles the capacity of the internal array.
    private void Resize()
    {
        // Double the capacity, or use default if it's zero.
        int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
        // Create a new, larger array.
        T[] biggerArray = new T[newCapacity];

        // Use Array.Copy for better performance.
        if (_count > 0)
        {
            Array.Copy(_items, biggerArray, _count);
        }

        // Replace the old array with the new, bigger one.
        _items = biggerArray;
    }

    // Removes the element at the specified index.
    public void RemoveAt(int index)
    {
        // Check if the index is out of the valid range.
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException("Index is out of range!");
        }

        // Shift elements to the left to fill the gap.
        for (int i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        // Decrement the count of elements.
        _count--;

        // Clear the last element to allow garbage collection.
        _items[_count] = default(T);
    }

    // Gets the number of elements in the array.
    public int Count => _count;

    // Gets the total capacity of the internal array.
    public int Capacity => _items.Length;
}