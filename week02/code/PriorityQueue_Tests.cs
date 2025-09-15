using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add item to the back of the queue
    // Expected Result: Items are added in the correct order
    // Defect(s) Found: No defects found.

    public void TestPriorityQueue_AddMultipleItems()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Hello", 10);
        priorityQueue.Enqueue("World", 5);

        Assert.AreEqual("[Hello (Pri:10), World (Pri:5)]", priorityQueue.ToString());

    }

    [TestMethod]
    // Scenario: Remove the item with the highest priority and return its value
    // Expected Result: Hello, priority 10 will be removed and returned.
    // Defect(s) Found: Item is not removed from the queue. Logic was missing to remove the highest priority item from the queue.
    public void TestPriorityQueue_RemoveHighestPriorityItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Hello", 10);
        priorityQueue.Enqueue("World", 9);
        priorityQueue.Enqueue("Goodbye", 8);

        priorityQueue.Dequeue();

        Assert.AreEqual("[World (Pri:9), Goodbye (Pri:8)]", priorityQueue.ToString());


    }

    [TestMethod]
    // Scenario: Remove the first item when two items share the highest priority
    // Expected Result: The item placed first in the queue will be removed and returned.
    // Defect(s) Found: Item closest to the front of the queue is not removed. An incorrect operator was used (>=) instead of (>).
    public void TestPriorityQueue_Dequeue_RemoveFirstItemWhenTied()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 6);
        priorityQueue.Enqueue("Hello", 10);
        priorityQueue.Enqueue("World", 10);
        priorityQueue.Enqueue("Goodbye", 8);

        priorityQueue.Dequeue();

        Assert.AreEqual("[First (Pri:6), World (Pri:10), Goodbye (Pri:8)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Throw exception when queue is empty
    // Expected Result: Exception is thrown
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}