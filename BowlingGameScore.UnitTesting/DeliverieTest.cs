using BowlingGameScore.Models;

using NUnit.Framework;

namespace BowlingGameScore.UnitTesting
{
    public class DeliverieTest
    {
        [Test]
        public void GivenDeliverie_WhenAddDeliveries_ThenReturnListOfDeliveries()
        {
            var deliverieResult = new Deliverie();
            deliverieResult.AddDeliverie(1, 1);
            deliverieResult.AddDeliverie(1, 1);
            deliverieResult.AddDeliverie(4, 0);

            Assert.That(deliverieResult.Deliveries.Count, Is.EqualTo(3));
        }

        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(5, 5, 10)]
        [TestCase(3, 3, 6)]
        [TestCase(2, 2, 4)]
        public void GivenDeliveries_WhenAddDeliveriesScore_ThenReturnExpectedResult(int FirstDeliverie, int SecondDeliverie, int result)
        {
            var deliverie = new Deliverie();

            int score = deliverie.AddDeliveriesScore(FirstDeliverie, SecondDeliverie);

            Assert.That(score, Is.EqualTo(result));
        }

        [Test]
        public void GivenFirstDeliverieOfTen_WhenAddStrike_ThenReturnTrue()
        {
            var deliverie = new Deliverie();
            int FirstDeliverie = 10;

            bool value = deliverie.AddStrike(FirstDeliverie);

            Assert.That(value, Is.EqualTo(true));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(3)]
        [TestCase(2)]
        public void GivenFirstDeliverieOfNotTen_WhenAddStrike_ThenReturnFalse(int FirstDeliverie)
        {
            var deliverie = new Deliverie();

            bool value = deliverie.AddStrike(FirstDeliverie);

            Assert.That(value, Is.EqualTo(false));
        }

        [Test]
        [TestCase(6, 4)]
        [TestCase(5, 5)]
        [TestCase(9, 1)]
        public void GivenDeliveriesOfaTotalOfTen_WhenAddSpare_ThenReturnTrue(int FirstDeliverie, int SecondDeliverie)
        {
            var deliverie = new Deliverie();

            bool value = deliverie.AddSpare(FirstDeliverie, SecondDeliverie);

            Assert.That(value, Is.EqualTo(true));
        }

        [Test]
        [TestCase(6, 2)]
        [TestCase(1, 5)]
        [TestCase(4, 4)]
        public void GivenDeliveriesOfaTotalOfNotTen_WhenAddSpare_ThenReturnFalse(int FirstDeliverie, int SecondDeliverie)
        {
            var deliverie = new Deliverie();

            bool value = deliverie.AddSpare(FirstDeliverie, SecondDeliverie);

            Assert.That(value, Is.EqualTo(false));
        }

        [Test]
        public void GivenStrike_CheckForStrike_ThenReturnExpectedResult()
        {
            var deliverieResult = new Deliverie();
            deliverieResult.AddDeliverie(1, 1);
            deliverieResult.AddDeliverie(10, 0);
            deliverieResult.AddDeliverie(1, 1);

            deliverieResult.CheckForStrike();

            Assert.AreEqual(deliverieResult.Deliveries[1].Score, 12);
        }

        [Test]
        public void GivenSpare_CheckForSpare_ThenReturnExpectedResult()
        {
            var deliverieResult = new Deliverie();
            deliverieResult.AddDeliverie(1, 1);
            deliverieResult.AddDeliverie(5, 5);
            deliverieResult.AddDeliverie(1, 1);

            deliverieResult.CheckForSpare();

            Assert.AreEqual(deliverieResult.Deliveries[1].Score, 11);
        }

        [Test]
        public void GivenFinalStrike_FinalStrike_ThenReturnExpectedResult()
        {
            var deliverieResult = new Deliverie();
            deliverieResult.AddDeliverie(1, 1);
            deliverieResult.AddDeliverie(1, 1);
            deliverieResult.AddDeliverie(10, 0);
     
            deliverieResult.FinalStrike(1, 2);

            Assert.AreEqual(deliverieResult.Deliveries[2].Score, 13);
        }

        [Test]
        public void GivenFinalSpare_FinalSpare_ThenReturnExpectedResult()
        {
            var deliverieResult = new Deliverie();
            deliverieResult.AddDeliverie(1, 1);
            deliverieResult.AddDeliverie(1, 1);
            deliverieResult.AddDeliverie(5, 5);

            deliverieResult.FinalSpare(1);

            Assert.AreEqual(deliverieResult.Deliveries[2].Score, 11);
        }

        [Test]
        public void GivenDeliverie_FinalScore_ThenReturnFinalScore()
        {
            var deliverieResult = new Deliverie();
            deliverieResult.AddDeliverie(1, 1);
            deliverieResult.AddDeliverie(10, 0);
            deliverieResult.AddDeliverie(1, 2);
            deliverieResult.AddDeliverie(5, 5);

            deliverieResult.CheckForStrike();
            deliverieResult.CheckForSpare();

            Assert.AreEqual(deliverieResult.FinalScore(), 28);
        }
    }
}