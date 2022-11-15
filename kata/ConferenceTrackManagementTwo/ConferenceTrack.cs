namespace kata.ConferenceTrackManagementTwo;

public record ConferenceTrack(
    ConferenceSession AfternoonSession,
    ConferenceSession MorningSession
)
{
    public ConferenceTrack(List<ConferenceTalk> talks) : this()
    {

    }
}

public record ConferenceSession(
    IEnumerable<ConferenceTalk> Talks
)
{
    public TimeSpan RunTime { get; set; }
}