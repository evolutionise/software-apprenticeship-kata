namespace kata.ConferenceTrackManagementTwo;

public class ConferenceTrack
{
    public ConferenceTrack(List<ConferenceTalk> talks)
    {
    }

    public ConferenceSession MorningSession { get; set; }
}

public record ConferenceSession(
    IEnumerable<ConferenceTalk> Talks
)
{
    public TimeSpan RunTime { get; set; }
}