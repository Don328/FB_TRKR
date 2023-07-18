namespace FBTracker.Server.Data.Records;

public record _Team(
    int Id,
    int Season,
    string Locale,
    string Name,
    string Abrev,
    int ConferenceIndex,
    int RegionIndex);
