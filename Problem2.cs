/*
 Problem2
 Write a function in C# that takes an array of integers and returns the two numbers that add up to
    a specific target number. If no such numbers exist, return an appropriate message.

    Example Input:
    Array: [2, 7, 11, 15]

    Target: 9

    Example Output:
    Numbers: 2 and 7
 */
using System;
using System.Collections.Generic;

public class Problem2
{
    public static void Main(string[] args)
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 10;

        try
        {
            var result = FindTwoTargetValues(nums, target);

            if (result.HasValue)
            {
                Console.WriteLine($"Numbers: {result.Value.Item1} and {result.Value.Item2}");
            }
            else
            {
                Console.WriteLine($"No two numbers add up to {target}.");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Exception :"+ ex.Message);
        }
    }
    public static (int, int)? FindTwoTargetValues(int[] nums, int target)
    {

        if (nums == null || nums.Length < 2)
        {
            throw new ArgumentException("Input array must contain at least two elements.");
        }

        Dictionary<int, int> numMapping = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int difference = target - nums[i];

            if (numMapping.ContainsKey(difference))
            {
                return (nums[numMapping[difference]], nums[i]);
            }

            numMapping[nums[i]] = i;
        }

        return null;
    }


}
