using System.Net.Http.Json;
using FB_Tracker.Shared.Models;
using FBTracker.Shared.DTOs;
using FBTracker.Shared.GloblaConstants.RouteTags;

namespace FBTracker.Client.DataServices;
public class TeamDataService
{
    private readonly HttpClient _http;

    public TeamDataService(
        HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<Team>> GetSeasonTeamsAsync(int season)
    {
        var url =
            _http.BaseAddress
            + TeamsRouteTags.GetSeason;

        var query = new TeamsQuery
            {Season = season};

        var response = await _http.PostAsJsonAsync(url, query);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content
                .ReadFromJsonAsync<IEnumerable<Team>>()
                    ?? Enumerable.Empty<Team>();
        }

        return Enumerable.Empty<Team>();
    }

    public async Task UpdateTeamData(TeamDTO dto)
    {
        var url = _http.BaseAddress
            + TeamsRouteTags.Update;

        await _http.PostAsJsonAsync(url, dto);
        await Task.CompletedTask;        
    }
}
