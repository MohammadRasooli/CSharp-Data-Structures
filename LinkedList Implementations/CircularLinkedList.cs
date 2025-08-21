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

    // Adds a new node with the specified value to the beginning of the list. This is an O(1) operation.
    public void AddFirst(int data)
    {
        // Create a new node with the given data.
        var newNode = new Node(data);

        // If the list is empty, the new node becomes both the head and the tail.
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            // The new node points to itself to form the circle.
            newNode.Next = Head;
            return;
        }

        // Update the current tail's Next to point to the new head, closing the circle.
        Tail.Next = newNode;
        // Point the new node's Next reference to the current (old) head.
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

        // Unlink the old tail by pointing the new last node's Next to the head.
        current.Next = Head;
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

        // The tail must now point to the new head (the second node) to maintain the circle.
        Tail.Next = Head.Next;
        // Move the Head pointer to the second node.
        Head = Head.Next;
    }

    // Finds the first node that contains the specified value.
    public Node Find(int data)
    {
        // If the list is empty, return null as nothing can be found.
        if (Head == null) return null;

        // Start traversing from the head.
        var current = Head;
        do
        {
            // If the current node's data matches, we've found it.
            if (current.Data == data)
            {
                // Return the found node immediately.
                return current;
            }
            // Move to the next node in the list.
            current = current.Next;
        } while (current != Head); // Continue until we've circled back to the head.

        // If the loop completes, the value was not in the list, so return null.
        return null;
    }

    // Removes the first occurrence of a node with the specified value.
    public void Remove(int data)
    {
        // If the list is empty, do nothing.
        if (Head == null) return;

        // Special case: list has one node and it's the one to be removed.
        if (Head == Tail && Head.Data == data)
        {
            Head = null;
            Tail = null;
            return;
        }

        // If the node to remove is the head.
        if (Head.Data == data)
        {
            // Move the head to the next node.
            Head = Head.Next;
            // Update the tail's Next to point to the new head, closing the circle.
            Tail.Next = Head;
            return;
        }

        // Start at the head and search for the node *before* the one to be removed.
        var current = Head;
        // Loop until we find the target node or circle back to the start.
        while (current.Next != Head && current.Next.Data != data)
        {
            current = current.Next;
        }

        // If the target node was found.
        if (current.Next.Data == data)
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