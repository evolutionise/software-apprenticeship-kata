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
        var regex = new Regex(@"\w+");

        var thing = regex.Matches();
        var match = regex.Match(input);

        var min = int.Parse(match.Groups[1].Value);
        var length = TimeSpan.FromMinutes(min);

        return new Talk(match.Groups[0].Value, length);
    }
}

public record Talk(string Title, TimeSpan Length);