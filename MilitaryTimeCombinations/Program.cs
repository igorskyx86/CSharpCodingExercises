namespace MilitaryTimeCombinations;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter time in 'HH:mm' format using '?' as a wildcard:");
        var inputTime = Console.ReadLine();
        Console.WriteLine(MilitaryTimeCombinationCounter.CountTimeCombinations(inputTime));
    }
}