using FB_Tracker.Shared.Models;
using FBTracker.Server.Data.Services;
using FBTracker.Shared.DTOs;
using FBTracker.Shared.GloblaConstants.RouteTags;
using Microsoft.AspNetCore.Mvc;

namespace FBTracker.Server.Controllers;

[ApiController]
[Route(TeamsRouteTags.controller)]
public class TeamsController : Controller
{
    private readonly ILogger<TeamsController> _logger;
    private readonly TeamsService _teamsService;

    public TeamsController(
        ILogger<TeamsController> logger,
        TeamsService teamsService) 
    {
        _logger = logger;                                      
        _teamsService = teamsService;
    }

    [HttpPost]
    [Route(TeamsRouteTags.get_season)]
    public async Task<IEnumerable<Team>> GetTeamsAsync([FromBody] TeamsQuery query)
    {
        _logger.LogInformation($"[TeamsController] Request received for teams from season: {query.Season}");
        return await _teamsService.GetSeason(query);
    }
    
    [HttpPost]
    [Route(TeamsRouteTags.update)]
    public async Task UpdateTeamAsync([FromBody] TeamDTO dto)
    {
        _logger.LogInformation($"[TeamsController] (UpdateTeamAsync) Request recieved to update team id: {dto.Id}");
        await _teamsService.UpdateTeam(dto);
        await Task.CompletedTask;
    }
}