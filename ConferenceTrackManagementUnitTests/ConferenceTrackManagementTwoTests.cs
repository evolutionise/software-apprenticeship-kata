using System.Text.RegularExpressions;

namespace ConferenceTrackManagementUnitTests;

public class ConferenceTrackManagementTwoTests
{
    // Parse talks from input
    [Fact]
    public void GivenSingleTalkCanParseTitleAndTime()
    {
        //arrange
        const string input = "Writing Fast Tests Against Enterprise Rails 60min  ";
        var parser = new InputParser();
        
        //act
        var result = parser.Parse(input);
        
        //assert
        Assert.Equal("Writing Fast Tests Against Enterprise Rails", result.Title);
        Assert.Equal(new TimeSpan(0, 60, 0), result.Length);
    }
    
    // Arranges talks into sessions
    
    // Pretty prints the output
}

public class InputParser
{
    public Talk Parse(string input)
    {
        var regex = new Regex(@"(\w+)(\d+)");

        var matches = regex.Matches(input);

        var titleWordsWithoutTime = input.Split(' ').TakeWhile(w => w != matches[0].Value);
        var titleWithoutTime = string.Join(' ', titleWordsWithoutTime);

        var time = matches[0].Value.Substring(0, matches[0].Length - 3);

        return new Talk(titleWithoutTime, time);
    }
}

public record Talk(string Title, TimeSpan Length);