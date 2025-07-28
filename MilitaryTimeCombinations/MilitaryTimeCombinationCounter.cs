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
public static class MilitaryTimeCombinationCounter
{
    private const char Wildcard = '?';

    private static bool ValidateTimeCombination(string? time)
    {
        if (string.IsNullOrEmpty(time))
            return false;
        var hourValidationExpression = string.Format("?:[01{0}][0-9{0}]|2[0-3{0}]|\\?[0-9{0}])", Wildcard);
        var minuteValidationExpression = string.Format("[0-5{0}][0-9{0}]", Wildcard);
        var regex = new Regex(string.Format("^({0}:{1}$", hourValidationExpression, minuteValidationExpression));
        return regex.IsMatch(time);
    }

    public static int CountTimeCombinations(string? time)
    {
        if (!ValidateTimeCombination(time))
            throw new ArgumentException(string.Format(
                "Input time does not follow the required format 'HH:mm' with '{0}' as a wildcard", Wildcard));

        int numberOfHourCombinations = 1, numberOfMinuteCombinations = 1;
        char hourFirstDigit = time[0], hourSecondDigit = time[1];
        char minuteFirstDigit = time[3], minuteSecondDigit = time[4];

        if (hourFirstDigit == Wildcard)
            numberOfHourCombinations = 3;

        if (hourSecondDigit == Wildcard)
            switch (hourFirstDigit)
            {
                case '2':
                    numberOfHourCombinations = 4;
                    break;
                case Wildcard:
                    numberOfHourCombinations = 24;
                    break;
                default:
                    numberOfHourCombinations = 10;
                    break;
            }

        if (minuteFirstDigit == Wildcard)
            numberOfMinuteCombinations = 6;
        if (minuteSecondDigit == Wildcard)
            numberOfMinuteCombinations *= 10;

        return numberOfHourCombinations * numberOfMinuteCombinations;
    }
}