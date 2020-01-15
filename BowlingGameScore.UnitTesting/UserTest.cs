using BowlingGameScore.DataLogic;
using BowlingGameScore.Interface;
using BowlingGameScore.Models;

using NUnit.Framework;

namespace BowlingGameScore.UnitTesting
{
    public class UserTest
    {
        private IUserLogic _result;
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = new User();
            _result = new UserLogic(_user);
        }

        [Test]
        public void GivenDeliverie_WhenAddDeliveries_ThenReturnListOfDeliveries()
        {
            _result.AddDelivery(1, 1);
            _result.AddDelivery(1, 1);
            _result.AddDelivery(4, 0);

            Assert.That(_user.Frames.Count, Is.EqualTo(3));
        }

        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(5, 5, 10)]
        [TestCase(3, 3, 6)]
        [TestCase(2, 2, 4)]
        public void GivenDeliveries_WhenAddDeliveriesScore_ThenReturnExpectedResult(int firstDeliverie, int secondDeliverie, int result)
        {
            int score = _result.AddDeliveryScore(firstDeliverie, secondDeliverie);

            Assert.That(score, Is.EqualTo(result));
        }

        [Test]
        public void GivenFirstDeliverieOfTen_WhenAddStrike_ThenReturnTrue()
        {
            int firstDeliverie = 10;

            bool value = _result.AddStrike(firstDeliverie);

            Assert.IsTrue(value);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(3)]
        [TestCase(2)]
        public void GivenFirstDeliverieOfNotTen_WhenAddStrike_ThenReturnFalse(int firstDeliverie)
        {
            bool value = _result.AddStrike(firstDeliverie);

            Assert.IsFalse(value);
        }

        [Test]
        [TestCase(6, 4)]
        [TestCase(5, 5)]
        [TestCase(9, 1)]
        public void GivenDeliveriesOfaTotalOfTen_WhenAddSpare_ThenReturnTrue(int firstDeliverie, int secondDeliverie)
        {
            bool value = _result.AddSpare(firstDeliverie, secondDeliverie);

            Assert.IsTrue(value);
        }

        [Test]
        [TestCase(6, 2)]
        [TestCase(1, 5)]
        [TestCase(4, 4)]
        public void GivenDeliveriesOfaTotalOfNotTen_WhenAddSpare_ThenReturnFalse(int firstDeliverie, int secondDeliverie)
        {
            bool value = _result.AddSpare(firstDeliverie, secondDeliverie);

            Assert.IsFalse(value);
        }

        [Test]
        public void GivenStrike_CheckForStrike_ThenReturnExpectedResult()
        {
            _result.AddDelivery(1, 1);
            _result.AddDelivery(10, 0);
            _result.AddDelivery(1, 1);

            _result.CheckForStrike();

            Assert.AreEqual(_user.Frames[1].Score, 12);
        }

        [Test]
        public void GivenSpare_CheckForSpare_ThenReturnExpectedResult()
        {
            _result.AddDelivery(1, 1);
            _result.AddDelivery(5, 5);
            _result.AddDelivery(1, 1);

            _result.CheckForSpare();

            Assert.AreEqual(_user.Frames[1].Score, 11);
        }

        [Test]
        public void GivenFinalStrike_FinalStrike_ThenReturnExpectedResult()
        {
            _result.AddDelivery(1, 1);
            _result.AddDelivery(1, 1);
            _result.AddDelivery(10, 0);

            _result.FinalStrike(1, 2);

            Assert.AreEqual(_user.Frames[2].Score, 13);
        }

        [Test]
        public void GivenFinalSpare_FinalSpare_ThenReturnExpectedResult()
        {
            _result.AddDelivery(1, 1);
            _result.AddDelivery(1, 1);
            _result.AddDelivery(5, 5);

            _result.FinalSpare(1);

            Assert.AreEqual(_user.Frames[2].Score, 11);
        }

        [Test]
        public void GivenDeliverie_FinalScore_ThenReturnFinalScore()
        {
            _result.AddDelivery(1, 1);
            _result.AddDelivery(10, 0);
            _result.AddDelivery(1, 2);
            _result.AddDelivery(5, 5);

            _result.CheckForStrike();
            _result.CheckForSpare();

            Assert.AreEqual(_result.FinalScore(), 28);
        }

        [Test]
        public void GivenFrames_AddFrameCount_ThenReturnFrameCount()
        {
            _result.AddDelivery(10, 0);
            _result.AddDelivery(5, 5);
            _result.AddDelivery(1, 0);
            _result.AddDelivery(10, 0);

            Assert.AreEqual(_result.AddFrameCount(), 4);
        }

        [Test]
        public void GivenAllStrike_AllStrike_ThenReturnTrue()
        {
            _result.AddDelivery(10, 0);
            _result.AddDelivery(10, 0);
            _result.AddDelivery(10, 0);
            _result.AddDelivery(10, 0);

            _result.CheckForStrike();

            Assert.IsTrue(_result.AllStrike());
        }

        [Test]
        public void GivenNotAllStrike_AllStrike_ThenReturnFalse()
        {
            _result.AddDelivery(10, 0);
            _result.AddDelivery(5, 5);
            _result.AddDelivery(1, 0);
            _result.AddDelivery(10, 0);

            _result.CheckForStrike();
            _result.CheckForSpare();

            Assert.IsFalse(_result.AllStrike());
        }
    }
}