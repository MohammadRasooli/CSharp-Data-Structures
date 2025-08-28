// Represents a generic last-in, first-out (LIFO) collection of objects.
// This implementation uses a fixed-size array.
public class MyStack<T>
{
    // Internal array to store the stack elements.
    private T[] _items;
    // Tracks the number of elements currently in the stack.
    private int _count;

    // Initializes a new instance of the MyStack class with a specified capacity.
    public MyStack(int capacity)
    {
        // Create an array with the given maximum capacity.
        _items = new T[capacity];
        // Initially, the stack is empty.
        _count = 0;
    }

    // Adds an object to the top of the stack.
    // Time Complexity: O(1)
    public void Push(T item)
    {
        // Check if the stack is full.
        if (_count == _items.Length)
        {
            // Throw an exception if the stack has reached its capacity.
            throw new InvalidOperationException("Stack is full. Cannot push a new item.");
        }

        // Add the new item to the top of the stack.
        _items[_count] = item;
        // Increment the count of items.
        _count++;
    }

    // Removes and returns the object at the top of the stack.
    // Time Complexity: O(1)
    public T Pop()
    {
        // Check if the stack is empty.
        if (_count == 0)
        {
            // Throw an exception if trying to pop from an empty stack.
            throw new InvalidOperationException("Stack is empty. Cannot perform Pop operation.");
        }

        // Decrement the count to point to the top item.
        _count--;

        // Get the item at the top of the stack.
        var popItem = _items[_count];
        // Clear the reference in the array to help with garbage collection (for reference types).
        _items[_count] = default(T);

        // Return the removed item.
        return popItem;
    }

    // Returns the object at the top of the stack without removing it.
    // Time Complexity: O(1)
    public T Peek()
    {
        // Check if the stack is empty.
        if (_count == 0)
        {
            // Throw an exception if trying to peek at an empty stack.
            throw new InvalidOperationException("Stack is empty. Cannot perform Peek operation.");
        }

        // Return the top item, which is at index (count - 1).
        return _items[_count - 1];
    }

    // Gets the number of elements contained in the stack.
    public int Count => _count;
}