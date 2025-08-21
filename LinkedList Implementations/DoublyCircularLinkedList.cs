// Represents a doubly circular linked list.
// It combines the features of a doubly linked list and a circular list.
public class DoublyCircularLinkedList
{
    // Gets the head node of the list. This is an arbitrary entry point.
    public Node Head { get; private set; }

    // Gets the last node of the list. Its 'Next' points to the Head and the Head's 'Previous' points to it.
    public Node Tail { get; private set; }

    // Adds a new node with the specified value to the end of the list. This is an O(1) operation.
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

    // Adds a new node with the specified value to the beginning of the list. This is an O(1) operation.
    public void AddFirst(int data)
    {
        // Create the new node to be added.
        var newNode = new Node(data);

        // If the list is empty, the new node is both the head and the tail.
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            // The single node must point to itself to form the circle.
            Head.Previous = Tail;
            Tail.Next = Head;
            return;
        }

        // Link the new node to its future neighbors (the current Head and Tail).
        newNode.Next = Head;
        newNode.Previous = Tail;

        // Update the old neighbors to point to the new node, closing the circle.
        Head.Previous = newNode;
        Tail.Next = newNode;

        // Update the Head of the list to be the new node.
        Head = newNode;
    }

    // Removes the last node from the list. This is an O(1) operation.
    public void RemoveLast()
    {
        // If the list is empty, there is nothing to remove.
        if (Head == null) return;

        // If there's only one node, clear the list.
        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            return;
        }

        // The node before the tail should now point to the head.
        Tail.Previous.Next = Head; // Or Tail.Next, which is the same.
        // The head's previous pointer should point to the new tail.
        Head.Previous = Tail.Previous;
        // Update the Tail to be the node that was previously before it.
        Tail = Tail.Previous;
    }

    // Removes the first node from the list. This is an O(1) operation.
    public void RemoveFirst()
    {
        // If the list is empty, do nothing.
        if (Head == null) return;

        // If there is only one node, clear the list.
        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            return;
        }

        // The tail's next pointer must now point to the new head.
        Tail.Next = Head.Next;
        // The new head's previous pointer must now point to the tail.
        Head.Next.Previous = Tail;
        // Update the Head to be the next node in the sequence.
        Head = Head.Next;
    }

    // Finds the first node that contains the specified value.
    public Node Find(int data)
    {
        // If the list is empty, the node cannot be found.
        if (Head == null) return null;

        // Start the search from the head of the list.
        var current = Head;
        // Use a do-while loop to ensure the head node is checked at least once.
        do
        {
            // If the current node's data matches the target data, return the node.
            if (current.Data == data)
            {
                return current;
            }
            // Move to the next node in the circle.
            current = current.Next;
        } while (current != Head); // Stop when we've looped back to the head.

        // If the loop completes, the node was not found.
        return null;
    }

    // Removes the first occurrence of a node with the specified value.
    public void Remove(int data)
    {
        // If the list is empty, there is nothing to remove.
        if (Head == null) return;

        // Use the Find method to locate the node that needs to be removed.
        var nodToRemove = Find(data);

        // If Find returns null, the node isn't in the list, so we can exit.
        if (nodToRemove == null) return;

        // If the node to remove is the head, delegate to the specialized RemoveFirst method.
        if (nodToRemove == Head)
        {
            RemoveFirst();
            return;
        }

        // If the node to remove is the tail, delegate to the specialized RemoveLast method.
        if (nodToRemove == Tail)
        {
            RemoveLast();
            return;
        }

        // For a middle node, bypass it by connecting its previous and next nodes.
        nodToRemove.Previous.Next = nodToRemove.Next;
        nodToRemove.Next.Previous = nodToRemove.Previous;
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