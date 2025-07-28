using System.Text.RegularExpressions;

namespace MilitaryTimeCombinations;
/// <summary>
/// Calculates the number of valid military time combinations from a masked time string.
/// </summary>
/// <remarks>
/// A '?' character in the input string can represent any digit from 0–9.
/// </remarks>
/// <example>
/// var count = counter.CountTimeCombinations("1?:4?");
/// </example>
/// <param name="time">A time string in HH:mm format, with optional '?' wildcards.</param>
/// <returns>The number of valid military time combinations that match the pattern.</returns>
/// <exception cref="ArgumentException">Thrown when the input does not match the expected format.</exception>
public class MilitaryTimeCombinationCounter
{
    private readonly Regex _regex = new Regex("^(?:[01?][0-9?]|2[0-3?]|\\?[0-9?]):[0-5?][0-9?]$");

    private bool ValidateTimeCombination(string? time)
    {
        if(string.IsNullOrEmpty(time))
            return false;
        return _regex.IsMatch(time);
    }
    public int CountTimeCombinations(string? time)
    {
        if (!ValidateTimeCombination(time))
            throw new ArgumentException("Input time does not follow the required format 'HH:mm' with '?' as a wildcard");
        var numberOfCombinations = 1;
        var hourPart = time.Split(':')[0];
        var minutePart = time.Split(':')[1];

        if (hourPart.StartsWith('?'))
            numberOfCombinations = 3;
        
        if (hourPart.EndsWith('?'))
            if (hourPart.StartsWith('2'))
                numberOfCombinations = 4;
            else if (hourPart.StartsWith('?'))
                numberOfCombinations = 24;
            else
                numberOfCombinations = 10;

        if (minutePart.StartsWith('?'))
            numberOfCombinations *= 6;
       
        if (minutePart.EndsWith('?'))
            numberOfCombinations *= 10;

        return numberOfCombinations;
    }
}