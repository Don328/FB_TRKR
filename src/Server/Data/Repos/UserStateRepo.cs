using FBTracker.Server.Data.Records;
using FBTracker.Server.Data.Schema.Tables;
using FBTracker.Shared.DTOs;

namespace FBTracker.Server.Data.Repos;

public class UserStateRepo
{
    private readonly UserStateTable _table;
    private SeasonDTO _dto = default!;

    public UserStateRepo(
        UserStateTable table)
    {
        _table = table;
    }

    internal UserStateRepo WithData(SeasonDTO dto)
    {
        _dto = dto;
        return this;
    }

    internal UserStateRepo FromSeason(int season)
    {
        _dto.Season = season;
        return this;
    }

    internal async Task<int> GetSeason()
    {
        var season = await _table
            .WithUserId(_dto.UserId)
            .GetSelectedSeason();

        return await Task.FromResult(season);
    }

    internal async Task UpdateUserState()
    {
        await _table.Update(_dto);
    }
}