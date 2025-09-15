using System.Net.Sockets;


/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: When creating a Customer Service with a negative size/zero size, max size should be set to 10.
        // Expected Result: Max size is 10
        Console.WriteLine("Test 1");
        var tc1 = new CustomerService(0);
        Console.WriteLine(tc1._maxSize);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: When que is fill, new customers can not be added.
        // Expected Result: Error message
        // Console.WriteLine("Test 2");
        // var tc2 = new CustomerService(2);
        // tc2.AddNewCustomer();
        // tc2.AddNewCustomer();
        // tc2.AddNewCustomer();
        // Console.WriteLine(tc2);

        // Defect(s) Found: Incorrect operator used to check if queue is full

        // Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: If queue is empty, error message should be displayed.
        // Expected Result: Error message "No customers in queue to serve."
        // Console.WriteLine("Test 3");
        // var tc3 = new CustomerService(1);
        // tc3.ServeCustomer();

        // Defect(s) Found:

        // Console.WriteLine("=================");

        // Test 4
        // Scenario: serve customer from queue
        // Expected Result: first customer in queue is served
        Console.WriteLine("Test 4");
        var tc4 = new CustomerService(3);
        tc4.AddNewCustomer();
        tc4.AddNewCustomer();
        tc4.ServeCustomer();
        Console.WriteLine(tc4);
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}