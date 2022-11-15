using kata;
using kata.ConferenceTrackManagement;
using kata.ConferenceTrackManagementTwo;

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

    [Fact]
    public void MorningSessionIsUnder4Hours()
    {
        //arrange
        const string input = @"Writing Fast Tests Against Enterprise Rails 60min  
Overdoing it in Python 45min  
Lua for the Masses 30min  
Ruby Errors from Mismatched Gem Versions 45min   
Common Ruby Errors 45min  
Rails for Python Developers lightning  
Communicating Over Distance 60min  
Accounting-Driven Development 45min  
Woah 30min  
Sit Down and Write 30min  
Pair Programming vs Noise 45min  
Rails Magic 60min  
Ruby on Rails: Why We Should Move On 60min  
Clojure Ate Scala (on my project) 45min  
Programming in the Boondocks of Seattle 30min  
Ruby vs. Clojure for Back-End Development 30min  
Ruby on Rails Legacy App Maintenance 60min  
A World Without HackerNews 30min  
User Interface CSS in Rails Apps 30min ";
        var inputLines = input.Split(Environment.NewLine);
        
        var parser = new InputParser();
        var talks = inputLines.Select(il => parser.Parse(il)).ToList();
        
        //act
        var track = new ConferenceTrack(talks);
        
        
        Assert.True(track.MorningSession.RunTime > TimeSpan.FromHours(0));
        Assert.True(track.MorningSession.RunTime < TimeSpan.FromHours(4));
    }
    
    
    // Pretty prints the output
}

// Writing Fast Tests Against Enterprise Rails 60min  
// Overdoing it in Python 45min  
// Lua for the Masses 30min  
// Ruby Errors from Mismatched Gem Versions 45min   
// Common Ruby Errors 45min  
// Rails for Python Developers lightning  
//     Communicating Over Distance 60min  
// Accounting-Driven Development 45min  
// Woah 30min  
// Sit Down and Write 30min  
// Pair Programming vs Noise 45min  
// Rails Magic 60min  
// Ruby on Rails: Why We Should Move On 60min  
// Clojure Ate Scala (on my project) 45min  
// Programming in the Boondocks of Seattle 30min  
// Ruby vs. Clojure for Back-End Development 30min  
// Ruby on Rails Legacy App Maintenance 60min  
// A World Without HackerNews 30min  
// User Interface CSS in Rails Apps 30min  