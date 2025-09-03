public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- MyHashTable Test Demonstration ---");

        // --- SECTION 1: Basic Operations ---
        Console.WriteLine("\n--- 1. Testing Basic Add, Get, and Update ---");
        var ht = new MyHashTable<string, int>(10);
        
        Console.WriteLine("-> Action: Adding three new items ('apple', 'banana', 'cherry').");
        ht.Add("apple", 5);
        ht.Add("banana", 8);
        ht.Add("cherry", 12);
        
        Console.WriteLine($"   State: Current count is {ht.Count}."); // Expected: 3
        Console.WriteLine($"   State: Value of 'apple' is {ht.Get("apple")}.");   // Expected: 5
        
        Console.WriteLine("\n-> Action: Updating the value of an existing item ('apple' to 99).");
        ht.Add("apple", 99);
        
        Console.WriteLine($"   State: Value of 'apple' is now {ht.Get("apple")}."); // Expected: 99
        Console.WriteLine($"   State: Count remains {ht.Count}.");                  // Expected: 3

        // --- SECTION 2: Removal and Error Handling ---
        Console.WriteLine("\n--- 2. Testing Removal and Error Handling ---");
        
        Console.WriteLine("-> Action: Removing an existing item ('banana').");
        bool wasRemoved = ht.Remove("banana");
        
        Console.WriteLine($"   State: Remove operation returned '{wasRemoved}'."); // Expected: True
        Console.WriteLine($"   State: Current count is {ht.Count}.");           // Expected: 2

        Console.WriteLine("\n-> Action: Attempting to get the removed key ('banana').");
        try
        {
            ht.Get("banana");
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("   State: Successfully caught expected KeyNotFoundException.");
        }

        Console.WriteLine("\n-> Action: Attempting to remove a key that does not exist ('orange').");
        bool wasNotRemoved = ht.Remove("orange");
        Console.WriteLine($"   State: Remove operation returned '{wasNotRemoved}'."); // Expected: False

        // --- SECTION 3: Collision Handling ---
        Console.WriteLine("\n--- 3. Testing Collision Handling ---");
        Console.WriteLine("-> Action: Creating a table with size 1 to force all items to collide.");
        var collisionTable = new MyHashTable<string, string>(1);

        collisionTable.Add("alpha", "Value A");
        collisionTable.Add("beta", "Value B");
        collisionTable.Add("gamma", "Value C");

        Console.WriteLine($"   State: After adding 3 colliding keys, count is {collisionTable.Count}."); // Expected: 3
        
        Console.WriteLine("\n-> Action: Verifying all colliding items can be retrieved correctly.");
        Console.WriteLine($"   State: Get('alpha') -> {collisionTable.Get("alpha")}"); // Expected: Value A
        Console.WriteLine($"   State: Get('beta') -> {collisionTable.Get("beta")}");   // Expected: Value B
        Console.WriteLine($"   State: Get('gamma') -> {collisionTable.Get("gamma")}"); // Expected: Value C

        Console.WriteLine("\n-> Action: Removing the middle item ('beta') from the collision chain.");
        collisionTable.Remove("beta");
        
        Console.WriteLine($"   State: After removal, count is {collisionTable.Count}."); // Expected: 2
        Console.WriteLine("   State: Verifying the other items in the chain are still accessible.");
        Console.WriteLine($"   State: Get('alpha') -> {collisionTable.Get("alpha")}"); // Expected: Value A
        Console.WriteLine($"   State: Get('gamma') -> {collisionTable.Get("gamma")}"); // Expected: Value C

        Console.WriteLine("\n--- All Tests Concluded ---");
    }
}