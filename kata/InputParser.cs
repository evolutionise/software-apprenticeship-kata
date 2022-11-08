using System.Text.RegularExpressions;

namespace kata;

public class InputParser
{
    public Talk Parse(string rawTitleString)
    {
        var timeMatch = MatchOnTime(rawTitleString);
        var titleWithoutTime = ExtractTitleFromRawString(rawTitleString, timeMatch);
        var timespan = GetTimeFromMatch(timeMatch);

        return new Talk(titleWithoutTime, timespan);
    }

    private static TimeSpan GetTimeFromMatch(Match timeMatch)
    {
        var time = timeMatch.Value[..2];

        var timespan = new TimeSpan(0, minutes: int.Parse(time), 0);
        return timespan;
    }

    private static Match MatchOnTime(string input)
    {
        var regex = new Regex(@"(\w+)(\d+)");

        var matches = regex.Matches(input);
        return matches[0];
    }

    private static string ExtractTitleFromRawString(string input, Match matches)
    {
        var titleWordsWithoutTime = input.Split(' ').TakeWhile(w => w != matches.Value + "min");
        var titleWithoutTime = string.Join(' ', titleWordsWithoutTime);
        return titleWithoutTime;
    }
}