using FBTracker.Server.Data.Records;
using FBTracker.Server.Data.Schema.Commands;
using FBTracker.Server.Data.Schema.Constants;
using MySqlConnector;

namespace FBTracker.Server.Data.Schema.Tables;
public class SeasonPrepTable
{
    private readonly ILogger<SeasonPrepTable> _logger;
    private readonly MySqlConnection _conn;
    private int _season;

    public SeasonPrepTable(
        ILogger<SeasonPrepTable> logger,
        DataContext context)
    {
        _logger = logger;
        _conn = context.GetConnectionAsync()
            .GetAwaiter().GetResult();   
    }

    internal SeasonPrepTable FromSeason(int season)
    {
        _season = season;
        return this;        
    }

    internal async Task<_SeasonPrep> GetPrepRecord()
    {
        int id = 0;
        int season = 0;
        bool teamsConf = false;
        bool schedulesConf = false;

        using var cmd = _conn.CreateCommand();
        cmd.CommandText = ReadRow.seasonPrep_bySeason;
        ParamBuilder.Build(cmd, ParameterNames.season, _season);
        
        _conn.Open();
        using var reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            id = reader.GetInt32(0);
            season = reader.GetInt32(1);
            teamsConf = reader.GetBoolean(2);
            schedulesConf = reader.GetBoolean(3);
        }

        var record = new _SeasonPrep(
            Id:id,
            Season:season,
            TeamsConfirmed:teamsConf,
            SchedulesConfirmed:schedulesConf);
        
        if (record.Id > 0) _logger.LogInformation($"[SeasonPrepTable] Returning prep record for season: {record.Season}");
        else _logger.LogInformation($"[SeasonPrepTable] There was a proble getting the prep record for season: {_season}");
        
        await _conn.CloseAsync();
        return await Task.FromResult(record);
    }
}
