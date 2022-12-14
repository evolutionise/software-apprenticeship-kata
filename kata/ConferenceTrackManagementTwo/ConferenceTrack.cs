namespace kata.ConferenceTrackManagementTwo;

public class ConferenceTrack
{
    public ConferenceTrack(List<ConferenceTalk> talks)
    {
        var timespan = new TimeSpan(0);
        var seed = new List<(TimeSpan, List<ConferenceTalk>)>
        {
            (TimeSpan.Zero, new List<ConferenceTalk>())
        };
        
        var talksTotallingLessThan4Hrs = talks.Aggregate(
            seed,
            (accumulatedListOfTalks, talk) =>
            {
                var lastAddedItem = accumulatedListOfTalks.Last();

                if (lastAddedItem.Item1.Add(talk.Minutes.Value) < new TimeSpan(0, 4, 0, 0))
                {
                    lastAddedItem.Item2.Add(talk);
                    accumulatedListOfTalks.Add((lastAddedItem.Item1.Add(talk.Minutes.Value), lastAddedItem.Item2));
                    return accumulatedListOfTalks;
                }

                return accumulatedListOfTalks;
            });
        
        
        MorningSession = new ConferenceSession(talksTotallingLessThan4Hrs.Last().Item2);
    }

    public ConferenceSession MorningSession { get; set; }
}

public record ConferenceSession(
    IEnumerable<ConferenceTalk> Talks
)
{
    public TimeSpan RunTime { get; set; }
}