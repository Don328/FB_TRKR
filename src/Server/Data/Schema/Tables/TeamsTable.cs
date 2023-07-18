using FBTracker.Server.Data.Records;
using FBTracker.Server.Data.Schema.Commands;
using FBTracker.Shared.DTOs;
using MySqlConnector;

namespace FBTracker.Server.Data.Schema.Tables;

public class TeamsTable
{
    private readonly ILogger<TeamsTable> _logger;
    private readonly MySqlConnection _conn;
    private int _season;
    private TeamDTO _teamDTO = default!;

    public TeamsTable(
        ILogger<TeamsTable> logger,
        DataContext context)
    {
        _logger = logger;
        _conn = context.GetConnectionAsync()
            .GetAwaiter().GetResult();
    }

    internal TeamsTable FromSeason(int season)
    {
        _season = season;
        return this;
    }

    internal TeamsTable ForTeam(TeamDTO dto)
    {
        _teamDTO = dto;
        return this;
    }

    internal async Task<int> Create()
    {
        int createdId = 0;
        using (var cmd = _conn.CreateCommand())
        {
            cmd.CommandText = CreateRow.team;
            ParamBuilder.Build(cmd, "@season", _teamDTO.Season);
            ParamBuilder.Build(cmd, "@locale", _teamDTO.Locale);
            ParamBuilder.Build(cmd, "@name", _teamDTO.Name);
            ParamBuilder.Build(cmd, "@abrev", _teamDTO.Abrev);
            ParamBuilder.Build(cmd, "@conference", _teamDTO.Conference);
            ParamBuilder.Build(cmd, "@region", _teamDTO.Region);

            _logger.LogInformation($"[TeamsTable] Saving data. (Team: {_teamDTO.Abrev} Season: {_teamDTO.Season})");
            _conn.Open();
            var response = await cmd.ExecuteScalarAsync();
            if (response != null) createdId = (int)response;
            await _conn.CloseAsync();
        }

        return await Task.FromResult(createdId);
    }
    
    internal async Task Update()
    {
        using (var cmd = _conn.CreateCommand())
        {
            cmd.CommandText = UpdateRow.team;
            ParamBuilder.Build(cmd, "@id", _teamDTO.Id);
            ParamBuilder.Build(cmd, "@season", _teamDTO.Season);
            ParamBuilder.Build(cmd, "@locale", _teamDTO.Locale);
            ParamBuilder.Build(cmd, "@name", _teamDTO.Name);
            ParamBuilder.Build(cmd, "@abrev", _teamDTO.Abrev);
            ParamBuilder.Build(cmd, "@conference", _teamDTO.Conference);
            ParamBuilder.Build(cmd, "@region", _teamDTO.Region);

            _logger.LogInformation($"[TeamsTable] Updating data. (TeamId: {_teamDTO.Id} Season: {_teamDTO.Season})");
            _conn.Open();
            await cmd.ExecuteNonQueryAsync();
            await _conn.CloseAsync();
        }

        await Task.CompletedTask;
    }

    internal async Task<IEnumerable<_Team>> ReadSeason()
    {
        _logger.LogInformation($"[TeamsTable] Reading teams for season: {_season})");
        var teams = new List<_Team>();

        using var cmd = _conn.CreateCommand();
        cmd.CommandText = ReadTable.teamsBySeason;
        ParamBuilder.Build(cmd, "@season", _season);

        _conn.Open();
        using var reader = await cmd.ExecuteReaderAsync();
        while (reader.Read())
        {
            teams.Add(new _Team(
                Id: reader.GetInt32(0),
                Season: reader.GetInt32(1),
                Locale: reader.GetString(2),
                Name: reader.GetString(3),
                Abrev: reader.GetString(4),
                ConferenceIndex: reader.GetInt32(5),
                RegionIndex: reader.GetInt32(6)));
        }

        await _conn.CloseAsync();

        return await Task.FromResult(teams);
    }
}
