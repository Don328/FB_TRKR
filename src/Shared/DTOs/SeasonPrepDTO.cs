namespace FBTracker.Shared.DTOs;
public class SeasonPrepDTO
{
    public int Id { get; set; }
    public int Season { get; set; }
    public bool TeamsConfirmed { get; set; }
    public bool SchedulesConfirmed { get; set; }
}
