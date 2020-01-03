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

        public void AddDeliverie(int FirstDeliverie, int SecondDeliverie)
        {
            bool Strike = AddStrike(FirstDeliverie);
            bool Spare = AddSpare(FirstDeliverie, SecondDeliverie);
            if (Strike == true)
            {
                SecondDeliverie = 0;
            }

            int Score = AddDeliveriesScore(FirstDeliverie, SecondDeliverie);

            Deliveries.Add(new Deliverie()
            {
                FirstDeliverie = FirstDeliverie,
                SecondDeliverie = SecondDeliverie,
                Score = Score,
                Strike = Strike,
                Spare = Spare
            });
        }

        public int AddDeliveriesScore(int FirstDeliverie, int SecondDeliverie)
        {
            int Score = FirstDeliverie + SecondDeliverie;
            return Score;
        }

        public bool AddStrike(int FirstDeliverie)
        {
            if (FirstDeliverie == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddSpare(int FirstDeliverie, int SecondDeliverie)
        {
            int Score = AddDeliveriesScore(FirstDeliverie, SecondDeliverie);
            bool Strike = AddStrike(FirstDeliverie);
            if (Score == 10 && Strike == false)
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

        public void FinalStrike(int FirstDeliverie, int SecondDeliverie)
        {
            int Score = AddDeliveriesScore(FirstDeliverie, SecondDeliverie);

            if (Deliveries.LastOrDefault().Strike == true)
            {
                Deliveries.LastOrDefault().Score += Score;
            }
        }

        public void FinalSpare(int FirstDeliverie)
        {
            if (Deliveries.LastOrDefault().Spare == true)
            {
                Deliveries.LastOrDefault().Score += FirstDeliverie;
            }
        }

        public int FinalScore()
        {
            return Deliveries.Sum(x => x.Score);
        }
    }
}