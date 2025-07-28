namespace ConsoleApp1;
/// <summary>
/// Provides a method for efficiently finding the closest integer to a target in a sorted array.
/// </summary>
public static class NearestFinder
{
    /// <summary>
    /// Finds the integer in a sorted array that is closest to the specified target.
    /// </summary>
    /// <param name="array">A sorted array of integers (in ascending order).</param>
    /// <param name="target">The target value to compare against.</param>
    /// <returns>
    /// The integer from the array that is numerically closest to the target.
    /// If two values are equally close, the smaller value is returned.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the array is null.</exception>
    /// <exception cref="ArgumentException">Thrown if the array is empty.</exception>
    public static int FindNearest(int[] array, int target)
    {
        if (array == null)
        {
            throw new ArgumentNullException("Input array cannot be null");
        }
        if (array.Length == 0)
        {
            throw new ArgumentException("Input array cannot be empty");
        }
        int left = 0;
        int right = array.Length - 1;
        while (left < right - 1)
        {
            int middle = (right + left) / 2;
            if (array[middle] == target) 
                return array[middle];
            if (array[middle] < target)
                left = middle;
            else
                right = middle;
        }

        int leftDifference = Math.Abs(target - array[left]);
        int rightDifference= Math.Abs(target - array[right]);
        if (leftDifference < rightDifference)
            return array[left];
        if (leftDifference > rightDifference)
            return array[right];
        return Math.Min(array[left], array[right]);
    }
}