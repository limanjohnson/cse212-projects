using Microsoft.VisualBasic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>

    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // 1. Create an array of doubles of the length specified by parameter 'length'
        // 2. Use a loop to iterate from 0 to length - 1
        // 3. For each iteration, add the appropriate multiple of 'number' to the array
        // 4. Return the array

        var multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // 1. check that amount is a valid number
        // 2. Get the index of the last 'amount' numbers in the list
        // 3. Remove the last 'amount' numbers from the list
        // 4. Insert the removed numbers at the beginning of the list
        if (amount < 1 || amount > data.Count)
        {
            // These numbers will not allow for the function to work as intended and will result in an error
            return;
        }

        // Get the number of the last index

        List<int> lastNumbers = data.GetRange(data.Count - amount, amount);

        // Remove lastNumber
        data.RemoveRange(data.Count - amount, amount);

        // insert lastNumbers at the beginning of the list
        data.InsertRange(0, lastNumbers);
    }
}
