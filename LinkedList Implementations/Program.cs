public class Program
{
    public static void Main(string[] args)
    {
        // --- 1. Singly Linked List Demonstration ---
        Console.WriteLine("--- Singly Linked List Demonstration ---");
        var singlyTrain = new SinglyLinkedList();

        // Step 1: Populate the list using AddLast
        Console.WriteLine("Step 1: Populating with AddLast(10), AddLast(20), AddLast(30)");
        singlyTrain.AddLast(10);
        singlyTrain.AddLast(20);
        singlyTrain.AddLast(30);
        singlyTrain.PrintList(); // Expected: List :  10 --> 20 --> 30 --> null
        Console.WriteLine();

        // Step 2: Demonstrate AddFirst
        Console.WriteLine("Step 2: Adding a new head with AddFirst(5)");
        singlyTrain.AddFirst(5);
        singlyTrain.PrintList(); // Expected: List :  5 --> 10 --> 20 --> 30 --> null
        Console.WriteLine();

        // Step 3: Demonstrate RemoveFirst
        Console.WriteLine("Step 3: Removing the head with RemoveFirst()");
        singlyTrain.RemoveFirst();
        singlyTrain.PrintList(); // Expected: List :  10 --> 20 --> 30 --> null
        Console.WriteLine();

        // Step 4: Demonstrate RemoveLast
        Console.WriteLine("Step 4: Removing the tail with RemoveLast()");
        singlyTrain.RemoveLast();
        singlyTrain.PrintList(); // Expected: List :  10 --> 20 --> null
        Console.WriteLine();

        // Step 5: Demonstrate Remove (a node in the middle)
        Console.WriteLine("Step 5: Removing a specific node with Remove(20)");
        singlyTrain.AddFirst(5);   // List is now 5 -> 10 -> 20
        singlyTrain.AddLast(30);  // List is now 5 -> 10 -> 20 -> 30
        Console.WriteLine("List before removing 20:");
        singlyTrain.PrintList();
        singlyTrain.Remove(20);
        Console.WriteLine("List after removing 20:");
        singlyTrain.PrintList(); // Expected: List :  5 --> 10 --> 30 --> null
        Console.WriteLine();

        // Step 6: Demonstrate Find
        Console.WriteLine("Step 6: Finding nodes in the list");
        Console.WriteLine("Searching for node with value 10...");
        var foundNodeSingly = singlyTrain.Find(10);
        if (foundNodeSingly != null)
        {
            var nextData = foundNodeSingly.Next != null ? foundNodeSingly.Next.Data.ToString() : "null";
            Console.WriteLine($"   -> Found node! Its data is {foundNodeSingly.Data}. The next node's data is {nextData}.");
        }

        Console.WriteLine("Searching for node with value 99...");
        var notFoundNodeSingly = singlyTrain.Find(99);
        if (notFoundNodeSingly == null)
        {
            Console.WriteLine("   -> Node with data 99 was not found, as expected.");
        }


        // --- Doubly Linked List Demonstration ---
        Console.WriteLine("\n\n--- Doubly Linked List Demonstration ---");
        var doublyTrain = new DoublyLinkedList();

        // Step 1: Populate the list using AddLast
        Console.WriteLine("Step 1: Populating with AddLast(10), AddLast(20), AddLast(30)");
        doublyTrain.AddLast(10);
        doublyTrain.AddLast(20);
        doublyTrain.AddLast(30);
        doublyTrain.PrintForward();  // Expected: Forward:  10 <-> 20 <-> 30 <-> null
        doublyTrain.PrintBackward(); // Expected: Backward: 30 <-> 20 <-> 10 <-> null
        Console.WriteLine();

        // Step 2: Demonstrate AddFirst
        Console.WriteLine("Step 2: Adding a new head with AddFirst(5)");
        doublyTrain.AddFirst(5);
        doublyTrain.PrintForward();  // Expected: Forward:  5 <-> 10 <-> 20 <-> 30 <-> null
        doublyTrain.PrintBackward(); // Expected: Backward: 30 <-> 20 <-> 10 <-> 5 <-> null
        Console.WriteLine();

        // Step 3: Demonstrate RemoveFirst
        Console.WriteLine("Step 3: Removing the head with RemoveFirst()");
        doublyTrain.RemoveFirst();
        doublyTrain.PrintForward();  // Expected: Forward:  10 <-> 20 <-> 30 <-> null
        doublyTrain.PrintBackward(); // Expected: Backward: 30 <-> 20 <-> 10 <-> null
        Console.WriteLine();

        // Step 4: Demonstrate RemoveLast
        Console.WriteLine("Step 4: Removing the tail with RemoveLast()");
        doublyTrain.RemoveLast();
        doublyTrain.PrintForward();  // Expected: Forward:  10 <-> 20 <-> null
        doublyTrain.PrintBackward(); // Expected: Backward: 20 <-> 10 <-> null
        Console.WriteLine();

        // Step 5: Demonstrate remove (a node in the middle)
        Console.WriteLine("Step 5: Removing a specific node with remove(20)");
        doublyTrain.AddFirst(5);   // List is now 5 <-> 10 <-> 20
        doublyTrain.AddLast(30);  // List is now 5 <-> 10 <-> 20 <-> 30
        Console.WriteLine("List before removing 20:");
        doublyTrain.PrintForward();
        doublyTrain.Remove(20);
        Console.WriteLine("List after removing 20:");
        doublyTrain.PrintForward();  // Expected: Forward:  5 <-> 10 <-> 30 <-> null
        doublyTrain.PrintBackward(); // Expected: Backward: 30 <-> 10 <-> 5 <-> null
        Console.WriteLine();

        // Step 6: Demonstrate Find
        Console.WriteLine("Step 6: Finding nodes in the list");
        Console.WriteLine("Searching for node with value 10...");
        var foundNodeDoubly = doublyTrain.Find(10);
        if (foundNodeDoubly != null)
        {
            var prevData = foundNodeDoubly.Previous != null ? foundNodeDoubly.Previous.Data.ToString() : "null";
            var nextData = foundNodeDoubly.Next != null ? foundNodeDoubly.Next.Data.ToString() : "null";
            Console.WriteLine($"   -> Found node! Its data is {foundNodeDoubly.Data}. Previous is {prevData}, Next is {nextData}.");
        }

        Console.WriteLine("Searching for node with value 99...");
        var notFoundNodeDoubly = doublyTrain.Find(99);
        if (notFoundNodeDoubly == null)
        {
            Console.WriteLine("   -> Node with data 99 was not found, as expected.");
        }


        // --- Circular Linked List Demonstration ---
        Console.WriteLine("\n\n--- Circular Linked List Demonstration ---");
        var circularTrain = new CircularLinkedList();

        // Step 1: Populate the list using AddLast
        Console.WriteLine("Step 1: Populating with AddLast(10), AddLast(20), AddLast(30)");
        circularTrain.AddLast(10);
        circularTrain.AddLast(20);
        circularTrain.AddLast(30);
        circularTrain.PrintList(); // Expected: Circular Linked List :  10 --> 20 --> 30 --> (Back To Head : 10)
        Console.WriteLine();

        // Step 2: Demonstrate AddFirst
        Console.WriteLine("Step 2: Adding a new head with AddFirst(5)");
        circularTrain.AddFirst(5);
        circularTrain.PrintList(); // Expected: Circular Linked List :  5 --> 10 --> 20 --> 30 --> (Back To Head : 5)
        Console.WriteLine();

        // Step 3: Demonstrate RemoveFirst
        Console.WriteLine("Step 3: Removing the head with RemoveFirst()");
        circularTrain.RemoveFirst();
        circularTrain.PrintList(); // Expected: Circular Linked List :  10 --> 20 --> 30 --> (Back To Head : 10)
        Console.WriteLine();

        // Step 4: Demonstrate RemoveLast
        Console.WriteLine("Step 4: Removing the tail with RemoveLast()");
        circularTrain.RemoveLast();
        circularTrain.PrintList(); // Expected: Circular Linked List :  10 --> 20 --> (Back To Head : 10)
        Console.WriteLine();

        // Step 5: Demonstrate Remove (a node in the middle)
        Console.WriteLine("Step 5: Removing a specific node with Remove(20)");
        circularTrain.AddFirst(5);  // List is now 5 -> 10 -> 20
        circularTrain.AddLast(30); // List is now 5 -> 10 -> 20 -> 30
        Console.WriteLine("List before removing 20:");
        circularTrain.PrintList();
        circularTrain.Remove(20);
        Console.WriteLine("List after removing 20:");
        circularTrain.PrintList(); // Expected: Circular Linked List :  5 --> 10 --> 30 --> (Back To Head : 5)
        Console.WriteLine();

        // Step 6: Demonstrate Find
        Console.WriteLine("Step 6: Finding nodes in the list");
        Console.WriteLine("Searching for node with value 10...");
        var foundNodeCircular = circularTrain.Find(10);
        if (foundNodeCircular != null)
        {
            // In a circular list, Next is never null for an existing node
            Console.WriteLine($"   -> Found node! Its data is {foundNodeCircular.Data}. The next node's data is {foundNodeCircular.Next.Data}.");
        }

        Console.WriteLine("Searching for node with value 99...");
        var notFoundNodeCircular = circularTrain.Find(99);
        if (notFoundNodeCircular == null)
        {
            Console.WriteLine("   -> Node with data 99 was not found, as expected.");
        }


        // --- Doubly Circular Linked List Demonstration ---
        Console.WriteLine("\n\n--- Doubly Circular Linked List Demonstration ---");
        var doublyCircularTrain = new DoublyCircularLinkedList();

        // Step 1: Populate the list using AddLast
        Console.WriteLine("Step 1: Populating with AddLast(10), AddLast(20), AddLast(30)");
        doublyCircularTrain.AddLast(10);
        doublyCircularTrain.AddLast(20);
        doublyCircularTrain.AddLast(30);
        // Print forwards to show the links from Head to Tail.
        doublyCircularTrain.PrintForward(); // Expected: Forward Traversal : 10 <-> 20 <-> 30 <-> (Back To Head: 10)
        // Print backwards to show the links from Tail to Head.
        doublyCircularTrain.PrintBackward(); // Expected: Backward Traversal: 30 <-> 20 <-> 10 <-> (Back To Tail: 30)
        Console.WriteLine();

        // Step 2: Demonstrate AddFirst
        Console.WriteLine("Step 2: Adding a new head with AddFirst(5)");
        doublyCircularTrain.AddFirst(5);
        doublyCircularTrain.PrintForward(); // Expected: Forward Traversal : 5 <-> 10 <-> 20 <-> 30 <-> (Back To Head: 5)
        doublyCircularTrain.PrintBackward(); // Expected: Backward Traversal: 30 <-> 20 <-> 10 <-> 5 <-> (Back To Tail: 30)
        Console.WriteLine();

        // Step 3: Demonstrate RemoveFirst
        Console.WriteLine("Step 3: Removing the head with RemoveFirst()");
        doublyCircularTrain.RemoveFirst();
        doublyCircularTrain.PrintForward(); // Expected: Forward Traversal : 10 <-> 20 <-> 30 <-> (Back To Head: 10)
        doublyCircularTrain.PrintBackward(); // Expected: Backward Traversal: 30 <-> 20 <-> 10 <-> (Back To Tail: 30)
        Console.WriteLine();

        // Step 4: Demonstrate RemoveLast
        Console.WriteLine("Step 4: Removing the tail with RemoveLast()");
        doublyCircularTrain.RemoveLast();
        doublyCircularTrain.PrintForward(); // Expected: Forward Traversal : 10 <-> 20 <-> (Back To Head: 10)
        doublyCircularTrain.PrintBackward(); // Expected: Backward Traversal: 20 <-> 10 <-> (Back To Tail: 20)
        Console.WriteLine();

        // Step 5: Demonstrate Remove (a node in the middle)
        Console.WriteLine("Step 5: Removing a specific node with Remove(20)");
        // Reset the list to a known state to test middle removal.
        doublyCircularTrain.AddFirst(5);  // List is now 5 <-> 10 <-> 20
        doublyCircularTrain.AddLast(30); // List is now 5 <-> 10 <-> 20 <-> 30
        Console.WriteLine("List before removing 20:");
        doublyCircularTrain.PrintForward();
        // Remove the middle node.
        doublyCircularTrain.Remove(20);
        Console.WriteLine("List after removing 20:");
        doublyCircularTrain.PrintForward(); // Expected: Forward Traversal : 5 <-> 10 <-> 30 <-> (Back To Head: 5)
        doublyCircularTrain.PrintBackward(); // Expected: Backward Traversal: 30 <-> 10 <-> 5 <-> (Back To Tail: 30)
        Console.WriteLine();

        // Step 6: Demonstrate Find
        Console.WriteLine("Step 6: Finding nodes in the list");
        Console.WriteLine("Searching for node with value 10...");
        // Search for a node that exists.
        var foundNodeDoublyCircular = doublyCircularTrain.Find(10);
        if (foundNodeDoublyCircular != null)
        {
            // Because it's a circular list, Previous and Next will never be null.
            Console.WriteLine($"   -> Found node! Its data is {foundNodeDoublyCircular.Data}. Previous is {foundNodeDoublyCircular.Previous.Data}, Next is {foundNodeDoublyCircular.Next.Data}.");
        }

        Console.WriteLine("Searching for node with value 99...");
        // Search for a node that does not exist.
        var notFoundNodeDoublyCircular = doublyCircularTrain.Find(99);
        if (notFoundNodeDoublyCircular == null)
        {
            Console.WriteLine("   -> Node with data 99 was not found, as expected.");
        }
    }
}