// Represents a generic first-in, first-out (FIFO) collection of objects.
// This implementation uses a LinkedList<T> for efficient enqueue and dequeue operations.
public class MyQueue<T>
{
    // Internal LinkedList to store the queue elements.
    private LinkedList<T> _items;

    // Initializes a new instance of the MyQueue class.
    public MyQueue()
    {
        // Create a new, empty LinkedList to hold the items.
        _items = new LinkedList<T>();
    }

    // Adds an object to the end of the queue.
    // Time Complexity: O(1)
    public void Enqueue(T item)
    {
        // Add the new item to the end (tail) of the LinkedList.
        _items.AddLast(item);
    }

    // Removes and returns the object at the beginning of the queue.
    // Time Complexity: O(1)
    public T Dequeue()
    {
        // Check if the queue is empty.
        if (_items.Count == 0)
        {
            // Throw an exception if trying to dequeue from an empty queue.
            throw new InvalidOperationException("Queue is empty. Cannot perform Dequeue operation.");
        }
        
        // Get the value of the item at the front of the queue.
        var dequeueItem = _items.First.Value;
        
        // Remove the item from the front (head) of the LinkedList.
        _items.RemoveFirst();

        // Return the removed item.
        return dequeueItem;
    }

    // Returns the object at the beginning of the queue without removing it.
    // Time Complexity: O(1)
    public T Peek()
    {
        // Check if the queue is empty.
        if (_items.Count == 0)
        {
            // Throw an exception if trying to peek at an empty queue.
            throw new InvalidOperationException("Queue is empty. Cannot perform Peek operation.");
        }
        
        // Return the item at the front of the queue.
        return _items.First.Value;
    }

    // Gets the number of elements contained in the queue.
    public int Count => _items.Count;
}