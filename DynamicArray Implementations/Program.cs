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

// A class to test the DynamicArray implementation.
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Creating a new DynamicArray<string> ---");
        var names = new DynamicArray<string>();
        Console.WriteLine($"Initial Count: {names.Count}, Initial Capacity: {names.Capacity}");

        Console.WriteLine("\n--- Adding 4 items ---");
        names.Add("Alice");
        names.Add("Bob");
        names.Add("Charlie");
        names.Add("David");
        Console.WriteLine($"Current Count: {names.Count}, Current Capacity: {names.Capacity}");
        PrintItems(names);

        Console.WriteLine("\n--- Adding a 5th item to trigger a resize ---");
        names.Add("Eve");
        Console.WriteLine($"New Count: {names.Count}, New Capacity: {names.Capacity}");
        PrintItems(names);

        Console.WriteLine("\n--- Removing item at index 1 ('Bob') ---");
        names.RemoveAt(1);
        Console.WriteLine($"After removal. Count: {names.Count}, Capacity: {names.Capacity}");
        PrintItems(names);
        
        Console.WriteLine("\n--- Accessing and modifying item at index 2 ('David') ---");
        Console.WriteLine($"Item at index 2 is: {names[2]}");
        names[2] = "Daniel";
        Console.WriteLine("Item at index 2 has been changed to 'Daniel'.");
        PrintItems(names);

        Console.WriteLine("\n--- Testing out of bounds exception ---");
        try
        {
            Console.WriteLine(names[10]);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Successfully caught expected exception: {ex.Message}");
        }
    }

    // Helper method to print all items in the dynamic array.
    private static void PrintItems<T>(DynamicArray<T> array)
    {
        Console.Write("Current items: [ ");
        for (int i = 0; i < array.Count; i++)
        {
            Console.Write(array[i]);
            if (i < array.Count - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(" ]");
    }
}