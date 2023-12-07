namespace OneBackComboTrainingWeb.Request
{
    public class MatchResultRequest
    {
        public int MatchId { get; set;}
        public Event Event { get; set; }
    }

    public enum Event
    {
        HomeGoal,
        AwayGoal,
        CancelHomeGoal,
        CancelAwayGoal,
        NextPeriod
    }
}