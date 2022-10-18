namespace kata.ConferenceTrackManagement;

public record ConferenceTrack(
    ConferenceSession AfternoonSession,
    ConferenceSession MorningSession
    );

public record ConferenceSession(
    IEnumerable<ConferenceTalk> Talks
);