using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Exceptions;
using OneBackComboTrainingWeb.Dto;
using OneBackComboTrainingWeb.Repository;
using OneBackComboTrainingWeb.Request;
using OneBackComboTrainingWeb.Service;

namespace OneBackTests
{
    [TestFixture]
    public class UpdateMatchResultServiceTests
    {
        private MatchResultService _matchResultService;
        private IMatchResultRepository _matchResultRepository;
        private MatchResultRequest _request;

        public UpdateMatchResultServiceTests()
        {
            _request = new MatchResultRequest()
            {
                MatchId = 91
            };
        }

        [SetUp]
        public void SetUp()
        {
            _matchResultRepository = Substitute.For<IMatchResultRepository>();
            _matchResultService = new MatchResultService(_matchResultRepository);
        }
        

        [Test]
        public void first_half_no_score()
        {
            _request.Event = Event.NextPeriod;
            MatchResultDto matchResultDto = new MatchResultDto(_request)
            {
                MatchId = 91,
                EventType = Event.NextPeriod
            };
            MatchResult matchResult = new MatchResult()
            {
                MatchId = 91,
                Result = ""
            };
            _matchResultRepository.GetMatchResultByMatchId(
                matchResultDto.MatchId).Returns(matchResult);
            
            string result = _matchResultService.UpdateMatchResult(matchResultDto);
            
            _matchResultRepository.Received().InsertUpdateMatchResultByMatchId(Arg.Any<MatchResult>());
            //received with anyargs
            Assert.AreEqual("0:0(First Half)", result);
        }

        [Test]
        public void first_half_home_goal()
        {
            _request.Event = Event.NextPeriod;
            MatchResultDto matchResultDto = new MatchResultDto(_request)
            {
                MatchId = 91,
                EventType = Event.HomeGoal
            };
            MatchResult matchResult = new MatchResult()
            {
                MatchId = 91,
                Result = ""
            };
            _matchResultRepository.GetMatchResultByMatchId(
                matchResultDto.MatchId).Returns(matchResult);

            string result = _matchResultService.UpdateMatchResult(matchResultDto);

            _matchResultRepository.Received().InsertUpdateMatchResultByMatchId(Arg.Any<MatchResult>());
            //received with anyargs
            Assert.AreEqual("1:0(First Half)", result);
        }

        [Test]
        public void first_half_home_two_goal()
        {
            _request.Event = Event.NextPeriod;
            MatchResultDto matchResultDto = new MatchResultDto(_request)
            {
                MatchId = 91,
                EventType = Event.HomeGoal
            };
            MatchResult matchResult = new MatchResult()
            {
                MatchId = 91,
                Result = "H"
            };
            _matchResultRepository.GetMatchResultByMatchId(
                matchResultDto.MatchId).Returns(matchResult);

            string result = _matchResultService.UpdateMatchResult(matchResultDto);
            matchResult.Period = 0;
            matchResult.Result = "HH";
            _matchResultRepository.Received().InsertUpdateMatchResultByMatchId(
                matchResult);
            //received with anyargs
            Assert.AreEqual("2:0(First Half)", result);
        }
    }
}
