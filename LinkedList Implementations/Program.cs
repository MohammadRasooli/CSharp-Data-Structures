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

    // <param name="data">The value to store in the node.<//param>
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

    // <param name="data">The value to add to the list.<//param>
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

    // <param name="data">The value to add to the list.<//param>
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

    // <param name="data">The value to add to the list.<//param>
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

    // <param name="data">The value to add to the list.<//param>
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
        // --- 1. Initialization ---
        // Create instances for each type of linked list.
        var singlyTrain = new SinglyLinkedList();
        var doublyTrain = new DoublyLinkedList();
        var circularTrain = new CircularLinkedList();
        var doublyCircularTrain = new DoublyCircularLinkedList();

        // --- 2. Population ---
        // Add the same data to each list to demonstrate their behavior.
        // Singly
        singlyTrain.AddLast(10);
        singlyTrain.AddLast(20);
        singlyTrain.AddLast(30);

        // Doubly
        doublyTrain.AddLast(10);
        doublyTrain.AddLast(20);
        doublyTrain.AddLast(30);

        // Circular
        circularTrain.AddLast(10);
        circularTrain.AddLast(20);
        circularTrain.AddLast(30);

        // Doubly Circular
        doublyCircularTrain.AddLast(10);
        doublyCircularTrain.AddLast(20);
        doublyCircularTrain.AddLast(30);

        // --- 3. Demonstration ---
        // Print the contents of each list to show their structure and traversal.
        Console.WriteLine("--- Singly Linked List ---");
        singlyTrain.PrintList();

        Console.WriteLine("\n--- Doubly Linked List ---");
        doublyTrain.PrintForward();
        doublyTrain.PrintBackward();

        Console.WriteLine("\n--- Circular Linked List ---");
        circularTrain.PrintList();

        Console.WriteLine("\n--- Doubly Circular Linked List ---");
        doublyCircularTrain.PrintForward();
        doublyCircularTrain.PrintBackward();
    }
}