using FBTracker.Server.Data.Mappers;
using FBTracker.Server.Data.Repos;
using FBTracker.Shared.DTOs;

namespace FBTracker.Server.Data.Services;
public class SeasonPrepService
{
    private readonly SeasonPrepRepo _repo;

    public SeasonPrepService(
        SeasonPrepRepo repo)
    {
        _repo = repo;
    }

    internal async Task<SeasonPrepDTO> GetSeasonPrep(SeasonPrepDTO dto)
    {
        var record = await _repo
            .WithData(dto)
            .GetPrepRecord();

        return await Task.FromResult(
            SeasonPrepMapper.ToDTO(record));
    }
}
