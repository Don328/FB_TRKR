namespace FBTracker.Shared.GlobalConstants.RouteTags;

public static class StateRouteTags
{
    public const string controller = "api/state";
    public static string GetSeason { get => controller + "/" + get_season; }
    public const string get_season = "get-season";
    public static string SetSeason { get => controller + "/" + set_season; }
    public const string set_season = "set-season";
    public static string GetSeasonPrep { get => controller + "/" + get_season_prep;}
    public const string get_season_prep = "get-season-prep";
    public static string ConfirmTeamsList { get => controller + "/" + confirm_teams_list; }
    public const string confirm_teams_list = "confirm-teams-list";
    public static string ConfirmSchedule { get => controller + "/" + confirm_schedule; }
    public const string confirm_schedule = "confirm-schedule";
}                                                                                                                                                                                                                                                                                                                                                                                           