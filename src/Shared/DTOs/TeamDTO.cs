using FBTracker.Shared.Enums;

namespace FBTracker.Shared.DTOs;
public class TeamDTO
{
    public int Id { get; set; }
    public int Season { get; set; }
    public string Locale { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Abrev { get; set; } = string.Empty;
    public Conference Conference { get; set; }
    public Region Region { get; set; }
}
