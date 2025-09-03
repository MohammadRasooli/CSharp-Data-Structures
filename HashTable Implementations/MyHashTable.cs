// Represents a generic hash table collection using separate chaining for collision resolution.
public class MyHashTable<TKey, TValue>
{
    // The array of buckets. Each bucket is a linked list to handle collisions.
    private LinkedList<MyKeyValue<TKey, TValue>>[] _buckets;

    // The total number of buckets in the hash table (capacity).
    private int _size;

    // The current number of key-value pairs in the hash table.
    private int _count;

    // Initializes a new instance of the hash table with a specified size.
    // size: The initial number of buckets.
    public MyHashTable(int size)
    {
        // Ensure the size is a positive number.
        if (size <= 0)
            throw new ArgumentException("Size must be a positive number.", nameof(size));

        _size = size;
        // Create the array of buckets.
        _buckets = new LinkedList<MyKeyValue<TKey, TValue>>[_size];
        _count = 0;
    }

    // Calculates the bucket index for a given key.
    // This method computes the hash code, ensures it's non-negative, and then maps it to a valid index.
    private int GetBucketIndex(TKey key)
    {
        // Throw an exception if the key is null.
        if (key == null)
            throw new ArgumentNullException(nameof(key), "Key cannot be null.");

        // Get the hash code of the key.
        var hashCode = key.GetHashCode();
        // Ensure the hash code is positive to prevent negative array indices.
        hashCode = Math.Abs(hashCode);
        // Map the hash code to a bucket index using the modulo operator.
        return hashCode % _size;
    }

    // Adds a key-value pair to the hash table. If the key already exists, its value is updated.
    // Time Complexity: O(1) on average, O(n) in the worst-case scenario.
    public void Add(TKey key, TValue value)
    {
        // Calculate the index for the given key.
        var index = GetBucketIndex(key);

        // If the bucket at this index is not yet created, initialize it.
        if (_buckets[index] == null)
        {
            _buckets[index] = new LinkedList<MyKeyValue<TKey, TValue>>();
        }

        // Get the linked list (bucket) at the calculated index.
        LinkedList<MyKeyValue<TKey, TValue>> bucket = _buckets[index];

        // Iterate through the bucket to check if the key already exists.
        foreach (var pair in bucket)
        {
            // If the key is found, update its value and exit the method.
            if (pair.Key.Equals(key))
            {
                pair.Value = value;
                return;
            }
        }

        // If the key is new, create a new pair and add it to the end of the bucket.
        var newPair = new MyKeyValue<TKey, TValue>(key, value);
        bucket.AddLast(newPair);
        // Increment the total count of items.
        _count++;
    }

    // Retrieves the value associated with the specified key.
    // Time Complexity: O(1) on average, O(n) in the worst-case scenario.
    // Throws: KeyNotFoundException if the key is not found.
    public TValue Get(TKey key)
    {
        // Calculate the index for the given key.
        var index = GetBucketIndex(key);

        // If the bucket is null, the key cannot exist.
        if (_buckets[index] == null)
        {
            throw new KeyNotFoundException("The given key was not present in the hash table.");
        }

        // Get the linked list (bucket) at the calculated index.
        LinkedList<MyKeyValue<TKey, TValue>> bucket = _buckets[index];

        // Iterate through the bucket to find the key.
        foreach (var pair in bucket)
        {
            // If the key is found, return its corresponding value.
            if (pair.Key.Equals(key))
            {
                return pair.Value;
            }
        }
        // If the loop finishes without finding the key, throw an exception.
        throw new KeyNotFoundException("The given key was not present in the hash table.");
    }

    // Removes the key-value pair with the specified key from the hash table.
    // Time Complexity: O(1) on average, O(n) in the worst-case scenario.
    // Returns true if the element is successfully removed; otherwise, false.
    public bool Remove(TKey key)
    {
        // Calculate the index for the given key.
        var index = GetBucketIndex(key);

        // If the bucket is null, the key cannot exist.
        if (_buckets[index] == null)
        {
            return false;
        }

        // Variable to hold the pair that needs to be removed.
        MyKeyValue<TKey, TValue> pairToRemove = null;
        // Get the linked list (bucket) at the calculated index.
        LinkedList<MyKeyValue<TKey, TValue>> bucket = _buckets[index];

        // Iterate through the bucket to find the pair to remove.
        foreach (var pair in bucket)
        {
            if (pair.Key.Equals(key))
            {
                pairToRemove = pair;
                break; // Exit the loop once the pair is found.
            }
        }
        // If a pair to remove was found...
        if (pairToRemove != null)
        {
            // ...remove it from the bucket.
            bucket.Remove(pairToRemove);
            // Decrement the total count of items.
            _count--;
            // Return true indicating success.
            return true;
        }
        // If the key was not found, return false.
        return false;
    }

    // Gets the number of key-value pairs contained in the hash table.
    public int Count => _count;
}