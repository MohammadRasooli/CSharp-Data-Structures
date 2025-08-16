// Represents a single node in a linked list.
// It can be visualized as a single wagon in a train.
public class Node
{

    // Gets or sets the value stored in the node.

    public int Data { get; set; }


    // Gets or sets the reference to the next node in the sequence.

    public Node Next { get; set; }


    // Gets or sets the reference to the previous node in the sequence.
    // Used in Doubly Linked Lists.

    public Node Previous { get; set; }


    // Initializes a new instance of the Node class with the specified data.

    public Node(int data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

// Represents a singly linked list.
// Each node points only to the next node in the sequence.
public class SinglyLinkedList
{

    // Gets the first node (the head) of the list.
    public Node Head { get; private set; }


    // Gets the last node (the tail) of the list.
    // A direct reference to the tail allows for O(1) add operations.
    public Node Tail { get; private set; }


    // Adds a new node with the specified value to the end of the list.
    public void AddLast(int data)
    {
        var newNode = new Node(data);

        // If the list is empty, the new node is both the head and the tail.
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        // Link the current tail to the new node.
        Tail.Next = newNode;
        // Update the tail to be the new last node.
        Tail = newNode;
    }

    // Adds a new node with the specified value to the beginning of the list.
    public void AddFirst(int data)
    {
        // Create a new node with the given data.
        var newNode = new Node(data);

        // If the list is empty, the new node becomes both the head and the tail.
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        // Point the new node's Next reference to the current head.
        newNode.Next = Head;
        // Update the list's Head to be the new node.
        Head = newNode;
    }

    // Removes the last node from the list.
    public void RemoveLast()
    {
        // If the list is empty, there's nothing to do.
        if (Head == null) return;

        // If there is only one node in the list, set both Head and Tail to null.
        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            return;
        }

        // We need to find the node *before* the tail to update its Next reference.
        var current = Head;
        while (current.Next != Tail)
        {
            current = current.Next;
        }

        // Unlink the last node by setting the previous node's Next to null.
        current.Next = null;
        // Update the Tail to point to the new last node.
        Tail = current;
    }

    // Removes the first node from the list.
    public void RemoveFirst()
    {
        // If the list is empty, there's nothing to do.
        if (Head == null) return;

        // If there is only one node, clear the list.
        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            return;
        }

        // Move the Head pointer to the second node, effectively removing the first.
        Head = Head.Next;
    }

    // Removes the first occurrence of a node with the specified value.
    public void Remove(int data)
    {
        if (Head == null) return;

        // If the node to remove is the head, use the dedicated method and exit.
        if (Head.Data == data)
        {
            RemoveFirst();
            return;
        }

        // Start at the head and search for the node *before* the one to be removed.
        var current = Head;
        while (current.Next != null && current.Next.Data != data)
        {
            current = current.Next;
        }

        // If the target node was found (meaning the loop didn't run to the end unsuccessfully).
        if (current.Next != null)
        {
            // Special case: if the target is the tail, we must update the Tail reference.
            if (current.Next == Tail)
            {
                Tail = current;
            }
            // Bypass the target node by linking the current node to the node after the target.
            current.Next = current.Next.Next;
        }
    }

    // Finds the first node that contains the specified value.
    public Node Find(int data)
    {
        // Start traversing from the head.
        var current = Head;
        // Loop until the end of the list is reached.
        while (current != null)
        {
            // If the current node's data matches, we've found it.
            if (current.Data == data)
            {
                // Return the found node immediately.
                return current;
            }
            // Move to the next node in the list.
            current = current.Next;
        }
        // If the loop completes, the value was not in the list, so return null.
        return null;
    }

    // Prints all the elements of the linked list to the console.
    public void PrintList()
    {
        Console.Write("List :  ");
        var current = Head;
        while (current != null)
        {
            Console.Write($"{current.Data} --> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

// Represents a doubly linked list.
// Each node points to both the next and the previous node.
public class DoublyLinkedList
{

    // Gets the first node (the head) of the list.
    public Node Head { get; private set; }


    // Gets the last node (the tail) of the list.
    // A direct reference to the tail allows for O(1) add operations.
    public Node Tail { get; private set; }


    // Adds a new node with the specified value to the end of the list.
    public void AddLast(int data)
    {
        var newNode = new Node(data);

        // If the list is empty, the new node becomes both the head and the tail.
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        // Link the current tail to the new node.
        Tail.Next = newNode;
        // Link the new node back to the old tail (creating the backward link).
        newNode.Previous = Tail;

        // Update the tail to be the new last node.
        Tail = newNode;
    }


    // Prints all elements of the list in forward order (from head to tail).
    public void PrintForward()
    {
        Console.Write("Forward:  ");
        var current = Head;
        while (current != null)
        {
            Console.Write($"{current.Data} <-> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }


    // Prints all elements of the list in reverse order (from tail to head).
    public void PrintBackward()
    {
        Console.Write("Backward: ");
        var current = Tail;
        while (current != null)
        {
            Console.Write($"{current.Data} <-> ");
            current = current.Previous;
        }
        Console.WriteLine("null");
    }
}

// Represents a circular singly linked list.
// The last node's 'Next' pointer points back to the head node.
public class CircularLinkedList
{

    // Gets the head node of the list. In a circular list, this is an arbitrary entry point.
    public Node Head { get; private set; }


    // Gets the last node of the list. Its 'Next' property points back to the Head.
    public Node Tail { get; private set; }


    // Adds a new node with the specified value to the end of the list.
    public void AddLast(int data)
    {
        var newNode = new Node(data);

        // If the list is empty, the new node is the head and the tail.
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            // The first node points to itself to start the circle.
            newNode.Next = Head;
            return;
        }

        // Append the new node after the current tail.
        Tail.Next = newNode;
        // Make the new node's Next pointer point back to the Head, closing the circle.
        newNode.Next = Head;

        // Update the Tail to be the new last node.
        Tail = newNode;
    }


    // Prints all elements of the circular list, starting from the head.
    public void PrintList()
    {
        if (Head == null)
        {
            Console.WriteLine("Circular Linked List is empty.");
            return;
        }

        Console.Write("Circular Linked List :  ");
        var current = Head;
        do
        {
            Console.Write($"{current.Data} --> ");
            current = current.Next;
        } while (current != Head); // Traverse until we circle back to the head.

        // Shows the final link from the tail back to the head.
        Console.WriteLine($"(Back To Head : {current.Data})");
    }
}

// Represents a doubly circular linked list.
// It combines the features of a doubly linked list and a circular list.
public class DoublyCircularLinkedList
{

    // Gets the head node of the list. This is an arbitrary entry point.
    public Node Head { get; private set; }


    // Gets the last node of the list. Its 'Next' points to the Head and the Head's 'Previous' points to it.
    public Node Tail { get; private set; }


    // Adds a new node with the specified value to the end of the list.
    public void AddLast(int data)
    {
        var newNode = new Node(data);

        // If the list is empty, the new node becomes the head and the tail.
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            // The first node points to itself in both directions to start the circle.
            newNode.Next = Head;
            newNode.Previous = Tail; // which is also Head
            return;
        }

        // Link the current tail's Next pointer to the new node.
        Tail.Next = newNode;
        // Link the new node's Previous pointer back to the old tail.
        newNode.Previous = Tail;

        // Update the Tail to be the new last node.
        Tail = newNode;

        // Close the circle by linking the new Tail and the Head in both directions.
        Tail.Next = Head;
        Head.Previous = Tail;
    }


    // Prints all elements in forward order, starting from the head and traversing the circle once.
    public void PrintForward()
    {
        if (Head == null)
        {
            Console.WriteLine("Doubly Circular Linked List is empty.");
            return;
        }

        Console.Write("Forward Traversal : ");
        var current = Head;
        do
        {
            Console.Write($"{current.Data} <-> ");
            current = current.Next;
        } while (current != Head);

        // Shows the final link from the tail back to the head.
        Console.WriteLine($"(Back To Head: {current.Data})");
    }


    // Prints all elements in reverse order, starting from the tail and traversing the circle once.
    public void PrintBackward()
    {
        if (Head == null)
        {
            Console.WriteLine("Doubly Circular Linked List is empty.");
            return;
        }

        Console.Write("Backward Traversal: ");
        var current = Tail;
        do
        {
            Console.Write($"{current.Data} <-> ");
            current = current.Previous;
        } while (current != Tail);

        // Shows the final link from the head back to the tail.
        Console.WriteLine($"(Back To Tail: {current.Data})");
    }
}

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
        Node foundNode = singlyTrain.Find(10);
        if (foundNode != null)
        {
            Console.WriteLine($"   -> Found node! Its data is {foundNode.Data}. The next node's data is {foundNode.Next.Data}.");
        }

        Console.WriteLine("Searching for node with value 99...");
        Node notFoundNode = singlyTrain.Find(99);
        if (notFoundNode == null)
        {
            Console.WriteLine("   -> Node with data 99 was not found, as expected.");
        }


        // --- Doubly Linked List Demonstration ---
        Console.WriteLine("\n\n--- Doubly Linked List ---");
        var doublyTrain = new DoublyLinkedList();
        doublyTrain.AddLast(10);
        doublyTrain.AddLast(20);
        doublyTrain.AddLast(30);
        doublyTrain.PrintForward();
        doublyTrain.PrintBackward();

        // --- Circular Linked List Demonstration ---
        Console.WriteLine("\n--- Circular Linked List ---");
        var circularTrain = new CircularLinkedList();
        circularTrain.AddLast(10);
        circularTrain.AddLast(20);
        circularTrain.AddLast(30);
        circularTrain.PrintList();

        // --- Doubly Circular Linked List Demonstration ---
        Console.WriteLine("\n--- Doubly Circular Linked List ---");
        var doublyCircularTrain = new DoublyCircularLinkedList();
        doublyCircularTrain.AddLast(10);
        doublyCircularTrain.AddLast(20);
        doublyCircularTrain.AddLast(30);
        doublyCircularTrain.PrintForward();
        doublyCircularTrain.PrintBackward();
    }
}