public class Program
{
    public static void Main(string[] args)
    {
        // === Run the demonstration for MyStack ===
        DemonstrateStack();

        Console.WriteLine("\n\n"); // Add some space between demonstrations

        // === Run the demonstration for MyQueue ===
        DemonstrateQueue();
    }

    /// Demonstrates the functionality of the MyStack class using a
    /// real-world scenario of an "Undo" feature in an editor.
    public static void DemonstrateStack()
    {
        PrintSectionHeader("MyStack<T> - Editor Undo History");

        // Create a stack with a small, fixed capacity to test the 'full' condition.
        var undoStack = new MyStack<string>(3);
        Console.WriteLine($"Undo history created with capacity: {3}");
        Console.WriteLine($"Initial number of actions: {undoStack.Count}");
        Console.WriteLine("---------------------------------------------");

        // 1. Pushing actions onto the stack
        Console.WriteLine("User performs some actions...");
        undoStack.Push("Typed 'Hello World'");
        Console.WriteLine("Pushed: \"Typed 'Hello World'\"");
        undoStack.Push("Formatted text to Bold");
        Console.WriteLine("Pushed: \"Formatted text to Bold\"");
        Console.WriteLine($"Current number of actions: {undoStack.Count}");
        Console.WriteLine("---------------------------------------------");
        
        // 2. Peeking at the last action
        Console.WriteLine("Peeking at the last action without removing it...");
        Console.WriteLine($"Peek() -> \"{undoStack.Peek()}\"");
        Console.WriteLine($"Count remains: {undoStack.Count}");
        Console.WriteLine("---------------------------------------------");
        
        // 3. Popping an action (Undo)
        Console.WriteLine("User hits 'Undo' (Ctrl+Z)...");
        string undoneAction = undoStack.Pop();
        Console.WriteLine($"Popped: \"{undoneAction}\"");
        Console.WriteLine($"Current number of actions: {undoStack.Count}");
        Console.WriteLine("---------------------------------------------");
        
        // 4. Testing Edge Case: Stack is full
        Console.WriteLine("User performs more actions to fill the stack...");
        undoStack.Push("Inserted an image");
        Console.WriteLine("Pushed: \"Inserted an image\"");
        undoStack.Push("Added a table");
        Console.WriteLine("Pushed: \"Added a table\"");
        Console.WriteLine($"Stack is now full. Count: {undoStack.Count}");

        try
        {
            Console.WriteLine("Attempting to push one more action to a full stack...");
            undoStack.Push("This should fail");
        }
        catch (InvalidOperationException ex)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS: Caught expected exception -> {ex.Message}");
            Console.ResetColor();
        }
        Console.WriteLine("---------------------------------------------");

        // 5. Testing Edge Case: Stack is empty
        Console.WriteLine("User undoes all actions...");
        Console.WriteLine($"Popped: \"{undoStack.Pop()}\"");
        Console.WriteLine($"Popped: \"{undoStack.Pop()}\"");
        Console.WriteLine($"Popped: \"{undoStack.Pop()}\"");
        Console.WriteLine($"Stack is now empty. Count: {undoStack.Count}");

        try
        {
            Console.WriteLine("Attempting to pop from an empty stack...");
            undoStack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS: Caught expected exception -> {ex.Message}");
            Console.ResetColor();
        }
    }

    /// Demonstrates the functionality of the MyQueue class using a
    /// real-world scenario of a printer job queue.
    public static void DemonstrateQueue()
    {
        PrintSectionHeader("MyQueue<T> - Printer Job Queue");
        
        var printerQueue = new MyQueue<string>();
        Console.WriteLine("Printer queue is ready.");
        Console.WriteLine($"Initial jobs in queue: {printerQueue.Count}");
        Console.WriteLine("---------------------------------------------");

        // 1. Enqueuing jobs
        Console.WriteLine("Users are sending documents to print...");
        printerQueue.Enqueue("Report.docx");
        Console.WriteLine("Enqueued: \"Report.docx\"");
        printerQueue.Enqueue("Presentation.pptx");
        Console.WriteLine("Enqueued: \"Presentation.pptx\"");
        printerQueue.Enqueue("Spreadsheet.xlsx");
        Console.WriteLine("Enqueued: \"Spreadsheet.xlsx\"");
        Console.WriteLine($"Current jobs in queue: {printerQueue.Count}");
        Console.WriteLine("---------------------------------------------");

        // 2. Peeking at the next job
        Console.WriteLine("Checking the next job without printing it...");
        Console.WriteLine($"Peek() -> \"{printerQueue.Peek()}\"");
        Console.WriteLine($"Count remains: {printerQueue.Count}");
        Console.WriteLine("---------------------------------------------");

        // 3. Dequeuing jobs (Printing)
        Console.WriteLine("Printer starts processing jobs in order...");
        string currentJob = printerQueue.Dequeue();
        Console.WriteLine($"Now Printing (Dequeued): \"{currentJob}\"");
        Console.WriteLine($"Jobs remaining: {printerQueue.Count}");
        Console.WriteLine("---------------------------------------------");
        
        // 4. Processing the rest of the queue
        Console.WriteLine($"Next to print is: \"{printerQueue.Peek()}\"");
        Console.WriteLine($"Now Printing (Dequeued): \"{printerQueue.Dequeue()}\"");
        Console.WriteLine($"Now Printing (Dequeued): \"{printerQueue.Dequeue()}\"");
        Console.WriteLine($"Queue is now empty. Count: {printerQueue.Count}");
        Console.WriteLine("---------------------------------------------");
        
        // 5. Testing Edge Case: Queue is empty
        try
        {
            Console.WriteLine("Attempting to dequeue from an empty queue...");
            printerQueue.Dequeue();
        }
        catch (InvalidOperationException ex)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS: Caught expected exception -> {ex.Message}");
            Console.ResetColor();
        }
    }

    /// A helper method to print a formatted header to the console.
    private static void PrintSectionHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=============================================");
        Console.WriteLine($"      DEMONSTRATING {title.ToUpper()}");
        Console.WriteLine("=============================================");
        Console.ResetColor();
    }
}