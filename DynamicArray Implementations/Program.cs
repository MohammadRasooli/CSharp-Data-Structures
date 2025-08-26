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