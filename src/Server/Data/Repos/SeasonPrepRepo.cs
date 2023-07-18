using FBTracker.Server.Data.Records;
using FBTracker.Server.Data.Schema.Tables;
using FBTracker.Shared.DTOs;

namespace FBTracker.Server.Data.Repos;
public class SeasonPrepRepo
{
    private readonly SeasonPrepTable _table;
    private SeasonPrepDTO _dto = default!;

    public SeasonPrepRepo(
        SeasonPrepTable table)
    {
        _table = table;
    }

    internal SeasonPrepRepo WithData(SeasonPrepDTO dto)
    {
        _dto = dto;
        return this;
    }

    internal async Task<_SeasonPrep> GetPrepRecord()
    {
        return await _table
            .FromSeason(_dto.Season)
            .GetPrepRecord();
    }
}
