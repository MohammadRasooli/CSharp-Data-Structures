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