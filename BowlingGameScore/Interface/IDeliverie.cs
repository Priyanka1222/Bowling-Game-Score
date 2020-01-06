namespace BowlingGameScore.Interface
{
    public interface IDeliverie
    {
        void AddDeliverie(int firstDeliverie, int secondDeliverie);
        int AddDeliveriesScore(int firstDeliverie, int secondDeliverie);
        bool AddStrike(int firstDeliverie);
        bool AddSpare(int firstDeliverie, int secondDeliverie);
        void CheckForStrike();
        void CheckForSpare();
        void FinalStrike(int firstDeliverie, int secondDeliverie);
        void FinalSpare(int firstDeliverie);
        int FinalScore();
    }
}
