namespace FBTracker.Server.Data.Records;
public record _SeasonPrep(
    int Id,
    int Season,
    bool TeamsConfirmed,
    bool SchedulesConfirmed
);
