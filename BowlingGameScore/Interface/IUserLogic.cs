using BowlingGameScore.ViewModels;

namespace BowlingGameScore.Interface
{
    public interface IUserLogic
    {
        void AddDelivery(int firstDelivery, int secondDelivery);
        int AddDeliveryScore(int firstDelivery, int secondDelivery);
        bool AddStrike(int firstDelivery);
        bool AddSpare(int firstDelivery, int secondDelivery);
        void CheckForStrike();
        void CheckForSpare();
        void FinalStrike(int firstDelivery, int secondDelivery);
        void FinalSpare(int firstDelivery);
        void SetGame(UserViewModel model, int firstDelivery, int secondDelivery);
        int AddframeCount();
    }
}
