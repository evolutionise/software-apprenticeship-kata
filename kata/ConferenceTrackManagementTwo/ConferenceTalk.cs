using System.Text.RegularExpressions;

namespace kata.ConferenceTrackManagementTwo;

public record ConferenceTalk(
    string Title,
    int? Minutes = null
)
{
    public static ConferenceTalk ParseConferenceTalkString(string line)
    {
        if (line.Contains("lightning"))
        {
            var x = string.Join( " ", line.Split(" ").TakeWhile(y => y != "lightning"));
            return new ConferenceTalk(x);
        }
        
        var re = new Regex(@"([a-zA-Z]+)(\d+)");
        var result = re.Match(line);
        
        var title = result.Groups[1].Value;
        var runTime = int.Parse(result.Groups[2].Value);
        return new ConferenceTalk(title, runTime);
    }
}
    
    