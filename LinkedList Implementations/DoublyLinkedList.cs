// Represents a doubly linked list.
// Each node points to both the next and the previous node.
public class DoublyLinkedList
{
    // Gets the first node (the head) of the list.
    public Node Head { get; private set; }

    // Gets the last node (the tail) of the list.
    // A direct reference to the tail allows for O(1) add operations.
    public Node Tail { get; private set; }

    // Adds a new node with the specified value to the end of the list. This is an O(1) operation.
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

    // Adds a new node with the specified value to the beginning of the list.  This is an O(1) operation.
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

        // Link the current head's Previous pointer back to the new node.
        Head.Previous = newNode;
        // Point the new node's Next reference to the current head.
        newNode.Next = Head;
        // Update the list's Head to be the new node.
        Head = newNode;
    }

    // Removes the last node from the list. This is an O(1) operation.
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

        // Move the tail pointer to the second-to-last node.
        Tail = Tail.Previous;
        // Sever the link from the new tail to the old tail.
        Tail.Next = null;
    }

    // Removes the first node from the list. This is an O(1) operation.
    public void RemoveFirst()
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

        // Move the head pointer to the second node.
        Head = Head.Next;
        // Sever the link from the new head back to the old head.
        Head.Previous = null;
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

    // Removes the first occurrence of a node with the specified value.
    public void Remove(int data)
    {
        // Find the node to be removed using the helper method.
        var nodToRemove = Find(data);

        // If the node doesn't exist in the list, exit the method.
        if (nodToRemove == null) return;

        // If the node is the Head, call the specific method for removing the first element.
        if (nodToRemove == Head)
        {
            RemoveFirst();
            return;
        }

        // If the node is the Tail, call the specific method for removing the last element.
        if (nodToRemove == Tail)
        {
            RemoveLast();
            return;
        }

        // If the node is in the middle, bypass it by connecting its previous and next nodes.
        // The 'Next' of the previous node should point to the 'Next' of the current node.
        nodToRemove.Previous.Next = nodToRemove.Next;
        // The 'Previous' of the next node should point to the 'Previous' of the current node.
        nodToRemove.Next.Previous = nodToRemove.Previous;
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