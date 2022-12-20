using System.Text.RegularExpressions;

namespace kata.ConferenceTrackManagementTwo;

public class InputParser
{
    public ConferenceTalk Parse(string rawTitleString)
    {
        var time = GetTimeFromMatch(rawTitleString);
        var title = ExtractTitleFromRawString(rawTitleString);
        
        return new ConferenceTalk(title, time);
    }

    private static TimeSpan GetTimeFromMatch(string input)
    {
        var matches = MatchOnTime(input);

        if (!matches.Any()) return new TimeSpan(0, 15, 0);
        
        var expectedLengthOfMinutesString = 2;
        var time = matches[0].Value[..expectedLengthOfMinutesString];

        var timespan = new TimeSpan(0, minutes: int.Parse(time), 0);
        return timespan;

    }

    private static MatchCollection MatchOnTime(string input)
    {
        var regex = new Regex(@"(\w+)(\d+)");

        var matches = regex.Matches(input);
        
        return matches;
    }

    private static string ExtractTitleFromRawString(string input)
    {
        var words = input.Trim().Split(' ');
        var titleWordsWithoutTime = words.Take(words.Length - 1);
        var titleWithoutTime = string.Join(' ', titleWordsWithoutTime);
        return titleWithoutTime;
    }
}