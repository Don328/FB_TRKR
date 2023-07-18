using FBTracker.Server.Data;
using FBTracker.Server.Data.Schema.Commands;
using FBTracker.Server.Data.Schema.Constants;
using FBTracker.Shared.DTOs;
using MySqlConnector;

namespace FBTracker.Server.Data.Schema.Tables;

public class UserStateTable
{
    private readonly ILogger<UserStateTable> _logger;
    private readonly MySqlConnection _conn;
    private int _userId;

    public UserStateTable(
        ILogger<UserStateTable> logger,
        DataContext context)
    {
        _logger = logger;
        _conn = context.GetConnectionAsync()
            .GetAwaiter().GetResult();
    }

    internal UserStateTable WithUserId(int userId)
    {
        _userId = userId;
        return this;
    }

    internal async Task<int> GetSelectedSeason()
    {
        int season = -1;
        using var cmd = _conn.CreateCommand();
        cmd.CommandText = ReadRow.userState_by_id;
        ParamBuilder.Build(cmd, ParameterNames.id, _userId);
        _conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            season = reader.GetInt32(1);
        }

        await _conn.CloseAsync();

        if (season == -1) _logger.LogInformation("error fetching selected user state data from db");
        else _logger.LogInformation($"[UserStateTable] Returning data. (season: {season})");
        
        return await Task.FromResult(season);
    }

    internal async Task Update(
        SeasonDTO dto)
    {
        using var cmd = _conn.CreateCommand();
        cmd.CommandText = UpdateRow.userState;
        ParamBuilder.Build(cmd, ParameterNames.id, dto.UserId);
        ParamBuilder.Build(cmd, ParameterNames.season, dto.Season);

        _conn.Open();
        await cmd.ExecuteNonQueryAsync();
        await _conn.CloseAsync();

        await Task.CompletedTask;
    }
}
