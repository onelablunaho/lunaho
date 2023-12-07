using OneBackComboTrainingWeb.Request;

namespace OneBackComboTrainingWeb.Dto
{
    public class MatchResultDto
    {

        public MatchResultDto(MatchResultRequest request)
        {
            MatchId = request.MatchId;
            EventType = request.Event;
        }

        public int MatchId { get; set; }
        public Event EventType { get; set; }
    }
}
