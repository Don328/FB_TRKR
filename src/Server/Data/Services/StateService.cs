using FBTracker.Server.Data.Repos;
using FBTracker.Shared.DTOs;

namespace FBTracker.Server.Data.Services;

public class StateService 
{
    private readonly UserStateRepo _repo;
    public StateService(UserStateRepo repo)
    {
        _repo = repo;
    }

    internal async Task<int> GetSeason(SeasonDTO dto)
    {
        return await _repo.WithData(dto).GetSeason();
    }

    internal async Task SetSeason(SeasonDTO dto)
    {
        await _repo.WithData(dto).UpdateUserState();
        await Task.CompletedTask;
    }
}