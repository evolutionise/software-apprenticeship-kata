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
        Assert.Equal(new TimeSpan(0, 60, 0), result.Minutes);
    }
    
    public static List<object[]> confernceTalkScenarios => new List<object[]>{
        new object[]{"Writing Fast Tests Against Enterprise Rails 60min ", "Writing Fast Tests Against Enterprise Rails ", 60},
        new object[]{"Overdoing it in Python 45min ", "Overdoing it in Python", 45},
        new object[]{"Lua for the Masses 30min ", "Lua for the Masses", 30}, 
        new object[]{"Ruby Errors from Mismatched Gem Versions 45min  ", "Ruby Errors from Mismatched Gem Versions", 45},
        new object[]{"Common Ruby Errors 45min ", "Common Ruby Errors", 45}, 
        new object[]{"Rails for Python Developers lightning ", "Rails for Python Developers", 15}, 
        new object[]{"Communicating Over Distance 60min ", "Communicating Over Distance", 60}, 
        new object[]{"Accounting-Driven Development 45min ", "Accounting-Driven Development", 45}, 
        new object[]{"Woah 30min ", "Woah", 30},
        new object[]{"Sit Down and Write 30min ", "Sit Down and Write", 30}, 
        new object[]{"Pair Programming vs Noise 45min ", "Pair Programming vs Noise", 45}, 
        new object[]{"Rails Magic 60min ", "Rails Magic", 60},
        new object[]{"Ruby on Rails: Why We Should Move On 60min ", "Ruby on Rails: Why We Should Move On", 60},
        new object[]{"Clojure Ate Scala (on my project) 45min ", "Clojure Ate Scala (on my project)", 45}, 
        new object[]{"Programming in the Boondocks of Seattle 30min ", "Programming in the Boondocks of Seattle", 30},
        new object[]{"Ruby vs. Clojure for Back-End Development 30min ", "Ruby vs. Clojure for Back-End Development", 30},
        new object[]{"Ruby on Rails Legacy App Maintenance 60min ", "Ruby on Rails Legacy App Maintenance", 60},
        new object[]{"A World Without HackerNews 30min ", "A World Without HackerNews", 30},
        new object[]{"User Interface CSS in Rails Apps 30min ", "User Interface CSS in Rails Apps", 30}
    };

    [Theory]
    [MemberData(nameof(confernceTalkScenarios))]
    public void GivenListOfTalksCanParseTitleAndTime(string rawString, string title, int mins)
    {
        var parser = new InputParser();
        var talk = parser.Parse(rawString);
        
        Assert.True(talk is not null);
    }
    
    // Arranges talks into sessions

    [Fact]
    public void MorningSessionIsUnder4Hours()
    {
        //arrange
        var talks = new List<ConferenceTalk>();
        
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