using System.Linq;

using BowlingGameScore.Interface;
using BowlingGameScore.Models;
using BowlingGameScore.ViewModels;

namespace BowlingGameScore.DataLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly User _context;

        public UserLogic(User context)
        {
            _context = context;
        }

        public void AddDelivery(int firstDelivery, int secondDelivery)
        {
            bool strike = AddStrike(firstDelivery);
            bool spare = AddSpare(firstDelivery, secondDelivery);
            int score = AddDeliveryScore(firstDelivery, secondDelivery);
        
            _context.Frames.Add(new Frame()
            {
                FirstDelivery = firstDelivery,
                SecondDelivery = secondDelivery,
                Score = score,
                Strike = strike,
                Spare = spare
            });
        }

        public int AddframeCount()
        {
            int frameCount = _context.Frames.Count;
            return frameCount;
        }

        public int AddDeliveryScore(int firstDelivery, int secondDelivery)
        {
            int score = firstDelivery + secondDelivery;
            return score;
        }

        public bool AddStrike(int firstDelivery)
        {
            return firstDelivery == 10;
        }

        public bool AddSpare(int firstDelivery, int secondDelivery)
        {
            int score = AddDeliveryScore(firstDelivery, secondDelivery);
            bool strike = AddStrike(firstDelivery);

            return score == 10 && strike == false;
        }

        public void CheckForStrike()
        {
            var current = _context.Frames[0];

            foreach (var nextValue in _context.Frames)
            {
                if (nextValue == _context.Frames[0])
                {
                    continue;
                }
                else if (current.Strike == true)
                {
                    current.Score += nextValue.Score;
                }
                current = nextValue;
            }
        }

        public void CheckForSpare()
        {
            var current = _context.Frames[0];

            foreach (var nextValue in _context.Frames)
            {
                if (nextValue == _context.Frames[0])
                {
                    continue;
                }
                else if (current.Spare == true)
                {
                    current.Score += nextValue.FirstDelivery;
                }
                current = nextValue;
            }
        }

        public void FinalStrike(int firstDelivery, int secondDelivery)
        {
            int score = AddDeliveryScore(firstDelivery, secondDelivery);

            if (_context.Frames.LastOrDefault().Strike == true)
            {
                _context.Frames.LastOrDefault().Score += score;
            }
        }

        public void FinalSpare(int firstDelivery)
        {
            if (_context.Frames.LastOrDefault().Spare == true)
            {
                _context.Frames.LastOrDefault().Score += firstDelivery;
            }
        }

        public int FinalScore()
        {
            return _context.Frames.Sum(x => x.Score);
        }

        public void SetGame(UserViewModel model, int firstDelivery, int secondDelivery)
        {
            for (int i = 0; i <= 9; i++)
            {
                AddDelivery(model.Frames[i].FirstDelivery, model.Frames[i].SecondDelivery); 
                model.Frames[i].FrameCount = AddframeCount();
            }

            CheckForStrike();
            CheckForSpare();

            if (!firstDelivery.Equals(null) || !secondDelivery.Equals(null))
            {
                FinalStrike(firstDelivery, secondDelivery);
                FinalSpare(firstDelivery);
            }

            model.FinalScore = FinalScore();
        }
    }
}