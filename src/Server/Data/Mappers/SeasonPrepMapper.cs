using FBTracker.Server.Data.Records;
using FBTracker.Shared.DTOs;

namespace FBTracker.Server.Data.Mappers;
internal static class SeasonPrepMapper
{
    internal static SeasonPrepDTO ToDTO(_SeasonPrep record)
    {
        return new SeasonPrepDTO
            { 
                Id = record.Id,
                Season = record.Season,
                TeamsConfirmed = record.TeamsConfirmed,
                SchedulesConfirmed = record.SchedulesConfirmed
            };
    }
}
