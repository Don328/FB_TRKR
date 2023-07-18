using System.Net.Http.Json;
using FB_Tracker.Shared.Models;
using FBTracker.Client.DataServices;
using FBTracker.Shared.DTOs;
using FBTracker.Shared.GlobalConstants;
using FBTracker.Shared.GlobalConstants.RouteTags;
using Microsoft.AspNetCore.Components;

namespace FBTracker.Client.State;

partial class AppState : ComponentBase
{
    [Inject]
    internal StateDataService StateService { get; set; } = default!;

    [Inject]
    internal TeamDataService TeamsService { get; set; } = default!;

    [Parameter]
    public RenderFragment ChildContent { get; set;} = default!;

    public int Season { get; private set;} = default!;
    public IEnumerable<Team> Teams { get; private set; } = default!;
    public bool TeamsConfirmed { get; private set; } = false;
    public bool SchedulesConfirmed { get; private set; } = false;

    protected override async Task OnInitializedAsync()
    {
        await SetSelectedSeason();
    }

    public async Task ChangeSelectedSeason(int season)
    {
        await StateService.ChangeSeason(season);
        await SetSelectedSeason();
    }

    private async Task SetSelectedSeason()
    {
        Season = await StateService
            .GetSelectedSeason();
        
        await SetTeams();
        await GetSeasonPrepData();
        StateHasChanged();
    }

    private async Task SetTeams()
    {
        Teams = await TeamsService
            .GetSeasonTeamsAsync(Season);
    }

    private async Task GetSeasonPrepData()
    {
        var seasonPrep = await StateService.GetSeasonPrepData(Season);
        TeamsConfirmed = seasonPrep.TeamsConfirmed;
        SchedulesConfirmed = seasonPrep.SchedulesConfirmed;
    }
}