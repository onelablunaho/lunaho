using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneBackComboTrainingWeb.Dto;
using OneBackComboTrainingWeb.Repository;
using OneBackComboTrainingWeb.Request;
using OneBackComboTrainingWeb.Service;

namespace OneBackComboTrainingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private MatchResultService _matchResultService;
        public MatchController(MatchResultService matchResultService)
        {
            _matchResultService = matchResultService;
        }

        [HttpPost]
        public string UpdateMatchResult(MatchResultRequest request)
        {
            var matchResultDto = new MatchResultDto(request);
            
            return _matchResultService.UpdateMatchResult(matchResultDto);
        }
    }
}
