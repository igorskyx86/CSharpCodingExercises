


using ConsoleApp1;

int[] arr = [1, 3, 8, 10];
// arr = [];
arr = [-10, -5, 0, 5, 10];
int target = -6;
int nearest = NearestFinder.FindNearest(arr, target);
Console.WriteLine(nearest);