namespace OneBackComboTrainingWeb
{
    public class TennisGame
    {
        private string _firstPlayerName;
        private string _secondPlayerName;
        
        private readonly Dictionary<int, string> _scoreMap = new Dictionary<int, string>
        {
            {0, "love"},
            {1, "fifteen"},
            {2, "thirty"},
            {3, "forty"}
        };

        public TennisGame(string firstPlayerName, string secondPlayerName)
        {
            _secondPlayerName = secondPlayerName;
            _firstPlayerName = firstPlayerName;
        }

        private int _firstPlayerScore;

        private int _secondPlayerScore;

        public void AddFirstPlayerScore()
        {
            _firstPlayerScore++;
        }

        public void AddSecondPlayerScore()
        {
            _secondPlayerScore++;
        }

        private string Score()
        {
            if (_firstPlayerScore == _secondPlayerScore)
            {
                if (_firstPlayerScore < 3)
                {
                    return $"{_scoreMap[_firstPlayerScore]} all";
                }

                return "deuce";
            }

            if (_firstPlayerScore <= 3 && _secondPlayerScore <= 3)
            {
                return $"{_scoreMap[_firstPlayerScore]} {_scoreMap[_secondPlayerScore]}";
            }

            if (Math.Abs(_firstPlayerScore-_secondPlayerScore) >= 2)
            {
                if (_firstPlayerScore > _secondPlayerScore)
                    return $"{_firstPlayerName} win";
                return $"{_secondPlayerName} win";
            }

            if (_firstPlayerScore > _secondPlayerScore)
                return $"{_firstPlayerName} adv";
            return $"{_secondPlayerName} adv";
        }
    }
}
