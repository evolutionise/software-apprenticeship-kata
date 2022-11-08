using System.Text.RegularExpressions;

namespace kata;

public class InputParser
{
    public Talk Parse(string rawTitleString)
    {
        var timeMatch = MatchOnTime(rawTitleString);
        var title = ExtractTitleFromRawString(rawTitleString, timeMatch);
        var time = GetTimeFromMatch(timeMatch);

        return new Talk(title, time);
    }

    private static TimeSpan GetTimeFromMatch(Match timeMatch)
    {
        var expectedLengthOfMinutesString = 2;
        var time = timeMatch.Value[..expectedLengthOfMinutesString];

        var timespan = new TimeSpan(0, minutes: int.Parse(time), 0);
        return timespan;
    }

    private static Match MatchOnTime(string input)
    {
        var regex = new Regex(@"(\w+)(\d+)");

        var matches = regex.Matches(input);
        return matches[0];
    }

    private static string ExtractTitleFromRawString(string input, Match timeMatch)
    {
        var titleWordsWithoutTime = input.Split(' ').TakeWhile(w => w != timeMatch.Value + "min");
        var titleWithoutTime = string.Join(' ', titleWordsWithoutTime);
        return titleWithoutTime;
    }
}