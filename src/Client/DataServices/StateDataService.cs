using System.Net.Http.Json;
using FB_Tracker.Shared.Models;
using FBTracker.Client.State.Components;
using FBTracker.Shared.DTOs;
using FBTracker.Shared.GlobalConstants;
using FBTracker.Shared.GlobalConstants.RouteTags;
using FBTracker.Shared.GloblaConstants.RouteTags;

namespace FBTracker.Client.DataServices;
public class StateDataService
{
    private readonly HttpClient _http;

    public StateDataService(HttpClient http)
    {
        _http = http;
    }

    public async Task<int> GetSelectedSeason()
    {
        var url = 
            _http.BaseAddress 
            + StateRouteTags.GetSeason;
        
        var dto = new SeasonDTO()
        { UserId = StateConstants.defaultUserId };

        var response = await _http.PostAsJsonAsync(
            url, dto);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content
                .ReadFromJsonAsync<int>();
        }

        return -1;
    }

    public async Task ChangeSeason(int season)
    {
        var url =
            _http.BaseAddress
            + StateRouteTags.SetSeason;

        var dto = new SeasonDTO()
            {
                UserId = StateConstants.defaultUserId,
                Season = season
            };

        await _http.PostAsJsonAsync(url, dto);
        await Task.CompletedTask;
    }
    
    public async Task<SeasonPrepDTO> GetSeasonPrepData(int season)
    {
        var url = _http.BaseAddress
            + StateRouteTags.GetSeasonPrep;
        var dto = new SeasonPrepDTO { Season = season};

        var response = await _http.PostAsJsonAsync(url, dto);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content
                .ReadFromJsonAsync<SeasonPrepDTO>()
                    ?? default!;
        }

        return default!;
    }
}

