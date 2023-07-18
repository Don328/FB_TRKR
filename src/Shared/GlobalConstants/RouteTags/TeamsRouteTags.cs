namespace FBTracker.Shared.GloblaConstants.RouteTags;
public static class TeamsRouteTags
{
    public const string controller = "api/teams";
    
    public static string Get { get => $"{controller}/{get}"; }
    public const string get = "get";

    public static string GetSeason { get => $"{controller}/{get_season}"; }
    public const string get_season = "get-season";
    
    public static string Add { get => $"{controller}/{add}"; }
    public const string add = "add";
    
    public static string Update { get => $"{controller}/{update}"; }
    public const string update = "update";
    
    public static string Division_Rivals { get => $"{controller}/{division_rivals}"; }
    public const string division_rivals = "division-rivals";

}