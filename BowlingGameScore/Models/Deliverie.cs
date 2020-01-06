using System.Collections.Generic;
using System.Linq;

using BowlingGameScore.Interface;

namespace BowlingGameScore.Models
{
    public class Deliverie : IDeliverie
    {
        public int FirstDeliverie { get; set; }
        public int SecondDeliverie { get; set; }
        public int Score { get; set; }
        public bool Strike { get; set; }
        public bool Spare { get; set; }
        public IList<Deliverie> Deliveries { get; set; } = new List<Deliverie>();

        public void AddDeliverie(int firstDeliverie, int secondDeliverie)
        {
            bool strike = AddStrike(firstDeliverie);
            bool spare = AddSpare(firstDeliverie, secondDeliverie);
            if (Strike == true)
            {
                secondDeliverie = 0;
            }

            int score = AddDeliveriesScore(firstDeliverie, secondDeliverie);

            Deliveries.Add(new Deliverie()
            {
                FirstDeliverie = firstDeliverie,
                SecondDeliverie = secondDeliverie,
                Score = score,
                Strike = strike,
                Spare = spare
            });
        }

        public int AddDeliveriesScore(int firstDeliverie, int secondDeliverie)
        {
            int score = firstDeliverie + secondDeliverie;
            return score;
        }

        public bool AddStrike(int firstDeliverie)
        {
            if (firstDeliverie == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddSpare(int firstDeliverie, int secondDeliverie)
        {
            int score = AddDeliveriesScore(firstDeliverie, secondDeliverie);
            bool strike = AddStrike(firstDeliverie);
            if (score == 10 && strike == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckForStrike()
        {
            var current = Deliveries[0];

            foreach (var nextValue in Deliveries)
            {
                if (nextValue == Deliveries[0]) {}

                else if (current.Strike == true)
                {
                    current.Score += nextValue.Score;
                }
                current = nextValue;
            }
        }

        public void CheckForSpare()
        {
            var current = Deliveries[0];

            foreach (var nextValue in Deliveries)
            {
                if (nextValue == Deliveries[0]){}

                else if (current.Spare == true)
                {
                    current.Score += nextValue.FirstDeliverie;
                }
                current = nextValue;
            }
        }

        public void FinalStrike(int firstDeliverie, int secondDeliverie)
        {
            int score = AddDeliveriesScore(firstDeliverie, secondDeliverie);

            if (Deliveries.LastOrDefault().Strike == true)
            {
                Deliveries.LastOrDefault().Score += score;
            }
        }

        public void FinalSpare(int firstDeliverie)
        {
            if (Deliveries.LastOrDefault().Spare == true)
            {
                Deliveries.LastOrDefault().Score += firstDeliverie;
            }
        }

        public int FinalScore()
        {
            return Deliveries.Sum(x => x.Score);
        }
    }
}