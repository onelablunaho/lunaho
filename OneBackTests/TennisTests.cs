using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneBackComboTrainingWeb;

namespace OneBackTests
{
    [TestFixture]
    public class TennisTests
    {
        private TennisGame _tennisGame;

        [SetUp]
        public void SetUp()
        {
            _tennisGame = new TennisGame("Eva", "Eric");
        }


        [Test]
        public void score_is_love_all()
        {
            Assert.That(_tennisGame.ScoreResult, Is.EqualTo("love all"));
        }

        [Test]
        public void score_is_fifteen_all()
        {
            AddFirstPlayerScore(1);
            AddSecondPlayerScore(1);
            Assert.That(_tennisGame.ScoreResult, Is.EqualTo("fifteen all"));
        }

        [Test]
        public void score_is_thirty_all()
        {
            AddFirstPlayerScore(2);
            AddSecondPlayerScore(2);
            Assert.That(_tennisGame.ScoreResult, Is.EqualTo("thirty all"));
        }

        public void AddFirstPlayerScore(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _tennisGame.AddFirstPlayerScore();
            }
        }
        public void AddSecondPlayerScore(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _tennisGame.AddSecondPlayerScore();
            }
        }

    }
}
