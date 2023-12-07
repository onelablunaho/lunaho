namespace OneBackComboTrainingWeb.Repository
{
    public interface IMatchResultRepository
    {
        MatchResult GetMatchResultByMatchId(int matchId);
        MatchResult InsertUpdateMatchResultByMatchId(MatchResult matchResult);
    }

    public class MatchResult
    {
        public int MatchId { get; set;}
        public byte Period { get; set;}
        public string Result { get; set;}
    }
}
