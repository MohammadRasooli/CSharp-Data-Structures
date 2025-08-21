// Represents a singly linked list.
// Each node points only to the next node in the sequence.
public class SinglyLinkedList
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

        // Move the Head pointer to the second node.
        Head = Head.Next;
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
        // If the list is empty, do nothing.
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