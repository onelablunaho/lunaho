using OneBackComboTrainingWeb.Dto;
using OneBackComboTrainingWeb.Repository;
using OneBackComboTrainingWeb.Request;
using System;

namespace OneBackComboTrainingWeb.Service
{
    public class MatchResultService
    {
        private readonly IMatchResultRepository _matchResultRepository;
        public MatchResultService(IMatchResultRepository matchResultRepository)
        {
            _matchResultRepository = matchResultRepository;
        }

        public string UpdateMatchResult(MatchResultDto matchResultDto)
        {
            MatchResult matchResult = _matchResultRepository.GetMatchResultByMatchId(matchResultDto.MatchId);
            switch (matchResultDto.EventType)
            {
                case Event.HomeGoal:
                    matchResult.Result += "H";
                    break;
                case Event.AwayGoal:
                    matchResult.Result += "A";
                    break;
                case Event.NextPeriod:
                    matchResult.Result += ";";
                    break;
                case Event.CancelHomeGoal:
                    if (matchResult.Result.Last() != 'H')
                        throw new ArgumentException("cancel fail");
                    matchResult.Result = new string(matchResult.Result.Take(matchResult.Result.Length - 1).ToArray());
                    break;
                case Event.CancelAwayGoal:
                    if (matchResult.Result.Last() != 'A')
                        throw new ArgumentException("cancel fail");
                    matchResult.Result = new string(matchResult.Result.Take(matchResult.Result.Length - 1).ToArray());
                    break;
            }

            _matchResultRepository.InsertUpdateMatchResultByMatchId(matchResult);
            string result =
                $"{matchResult.Result.ToCharArray().Count(c => c == 'H')}:{matchResult.Result.ToCharArray().Count(c => c == 'A')}";
            string period = result.IndexOf(';') == -1 ? "First Half" : "Second Half" ;

            return $"{result}({period})";
        }
    }

    public class MatchResultRepository : IMatchResultRepository
    {
        public MatchResult GetMatchResultByMatchId(int matchId)
        {
            throw new NotImplementedException();
        }

        public MatchResult InsertUpdateMatchResultByMatchId(MatchResult matchResult)
        {
            throw new NotImplementedException();
        }
    }
}
