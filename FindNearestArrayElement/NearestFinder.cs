namespace ConsoleApp1;

public static class NearestFinder
{
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