namespace MilitaryTimeCombinations;

class Program
{
    static void Main(string[] args)
    {
        var timeCombinationCounter = new MilitaryTimeCombinationCounter();
        Console.WriteLine("Enter time in 'HH:mm' format using '?' as a wildcard:");
        var inputTime = Console.ReadLine();
        Console.WriteLine(timeCombinationCounter.CountTimeCombinations(inputTime));
    }
}