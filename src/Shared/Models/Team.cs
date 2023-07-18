using FBTracker.Shared.Enums;

namespace FB_Tracker.Shared.Models;
public class Team
{
    public int Id { get; set; }
    public int Season { get; set; }
    public string Locale { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Abrev { get; set; } = string.Empty;
    public Conference Conference { get; set; }
    public Region Region { get; set; }
    public string Division { get => $"{Conference}-{Region}"; }
    //public List<Game> Games { get; set; } = new();
    //public List<Player> Players { get; set; } = new();
}
