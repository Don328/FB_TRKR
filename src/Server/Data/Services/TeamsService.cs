using FB_Tracker.Shared.Models;
using FBTracker.Server.Data.Repos;
using FBTracker.Shared.DTOs;

namespace FBTracker.Server.Data.Services;
public class TeamsService
{
    private readonly TeamsRepo _repo;

    public TeamsService(TeamsRepo repo)
    {
        _repo = repo;
    }

    internal async Task<IEnumerable<Team>> GetSeason(TeamsQuery query)
    {
        return await _repo
            .FromSeason(query.Season)
            .GetSeasonTeams();
    }

    internal async Task UpdateTeam(TeamDTO dto)
    {
        await _repo
            .WithData(dto)
            .Update();

        await Task.CompletedTask;
    }
}
