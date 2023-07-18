using FBTracker.Server.Data;
using FBTracker.Server.Data.Services;
using FBTracker.Shared.DTOs;
using FBTracker.Shared.GlobalConstants.RouteTags;
using Microsoft.AspNetCore.Mvc;

namespace FBTracker.Server.Controllers;
               
[ApiController]
[Route(StateRouteTags.controller)]
public class StateController : Controller
{ 
    private readonly ILogger<StateController> _logger;
    private readonly StateService _stateService;
    private readonly SeasonPrepService _prepSvc;

    public StateController(
        ILogger<StateController> logger,
        StateService stateService,
        SeasonPrepService prepSvc)
    {
        _logger = logger;
        _stateService = stateService;
        _prepSvc = prepSvc;
    }

    [HttpPost]
    [Route(StateRouteTags.get_season)]
    public async Task<int> GetSeason([FromBody] SeasonDTO dto)
    {
        _logger.LogInformation($"[StateController] GetSeason() request recieved (user id: {dto.UserId})");
        return await _stateService.GetSeason(dto);
    }

    [HttpPost]
    [Route(StateRouteTags.set_season)]
    public async Task SetSeason([FromBody] SeasonDTO dto)
    {
        _logger.LogInformation($"[stateController] SetSeason() request recieved (user id: {dto.UserId} season: {dto.Season})");
        await _stateService.SetSeason(dto);
        await Task.CompletedTask;
    }

    [HttpPost]
    [Route(StateRouteTags.get_season_prep)]
    public async Task<SeasonPrepDTO> GetSeasonPrep([FromBody] SeasonPrepDTO dto)
    {
        _logger.LogInformation($"[stateController] GetSeasonPrep() request received for season: {dto.Season}");
        return await _prepSvc.GetSeasonPrep(dto);
    }
}