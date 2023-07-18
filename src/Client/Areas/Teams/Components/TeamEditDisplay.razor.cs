using FB_Tracker.Shared.Models;
using FBTracker.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace FBTracker.Client.Areas.Teams.Components;
partial class TeamEditDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public Team Team { get; set; } = default!;

    [Parameter, EditorRequired]
    public EventCallback<TeamDTO> OnUpdate { get; set; }

    private TeamDTO _dto = new();
    private bool _editEnabled = false;

    protected override void OnInitialized()
    {
        _dto.Id = Team.Id;
        _dto.Season = Team.Season;
        _dto.Locale = Team.Locale;
        _dto.Name = Team.Name;
        _dto.Abrev = Team.Abrev;
        _dto.Region = Team.Region;
        _dto.Conference = Team.Conference;
    }
    
    private void ToggleEdit() => _editEnabled = !_editEnabled;

    private async Task Update()
    {
        await OnUpdate.InvokeAsync(_dto);
    }

}
