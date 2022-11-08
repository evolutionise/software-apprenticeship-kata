using System.Text.RegularExpressions;
using kata.ConferenceTrackManagementTwo;

namespace kata.ConferenceTrackManagement;

public class ConferenceTrackManagement
{
    public string CreateConferenceTrack()
    {
        // Get talks
        var talks = GetConferenceTalks("talks.txt");
        

        
        
        // Do the thing
        // Arrange morning session
        // Arrange afternoon session?
        
        // Create session outline
        
        // Pretty print for output?
        return "";
    }
    
    
    public IEnumerable<ConferenceTalk> GetConferenceTalks(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        return lines.ToList().Select(ConferenceTalk.ParseConferenceTalkString);
    }
}