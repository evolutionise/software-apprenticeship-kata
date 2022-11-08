using System.Text.RegularExpressions;

namespace kata;

public class InputParser
{
    public Talk Parse(string input)
    {
        var regex = new Regex(@"(\w+)(\d+)");

        var matches = regex.Matches(input);

        var titleWordsWithoutTime = input.Split(' ').TakeWhile(w => w != matches[0].Value + "min");
        var titleWithoutTime = string.Join(' ', titleWordsWithoutTime);

        var time = matches[0].Value.Substring(0, 2);

        var timespan = new TimeSpan(0, minutes: int.Parse(time), 0);

        return new Talk(titleWithoutTime, timespan);
    }
}