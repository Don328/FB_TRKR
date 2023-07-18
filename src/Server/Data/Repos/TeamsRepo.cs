using FB_Tracker.Shared.Models;
using FBTracker.Server.Data.Mappers;
using FBTracker.Server.Data.Schema.Tables;
using FBTracker.Shared.DTOs;

namespace FBTracker.Server.Data.Repos;
public class TeamsRepo
{
    private readonly TeamsTable _table;
    private TeamDTO _dto = default!;
    private IEnumerable<TeamDTO> _inputSeason = default!;
    private int _season;

    public TeamsRepo(TeamsTable table)
    {
        _table = table;
    }

    internal TeamsRepo WithData(TeamDTO dto)
    {
        _dto = dto;
        return this;
    }

    internal TeamsRepo FromPreviousTeams(IEnumerable<TeamDTO> teams)
    {
        _inputSeason = teams;
        return this;
    }

    internal TeamsRepo FromSeason(int season)
    {
        _season = season;
        return this;
    }

    internal async Task<IEnumerable<Team>> GetSeasonTeams()
    {
        var teamRecords = await _table
            .FromSeason(_season)
            .ReadSeason();

        var teams = TeamsMapper.ToEntity(teamRecords);

        return await Task.FromResult(teams);
    }

    internal async Task Update()
    {
        await _table
            .ForTeam(_dto)
            .Update();

        await Task.CompletedTask;
    }

    internal async Task<int> Create()
    {
        var id = await _table
            .ForTeam(_dto)
            .Create();

        return await Task.FromResult(id);
    }

    internal async Task TransferTeamsFromSeason()
    {
        foreach(var team in _inputSeason)
        {
            _dto = team;
            _dto.Season = _season;
            await Create();
        }
    }
}
