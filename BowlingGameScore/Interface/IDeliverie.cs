namespace BowlingGameScore.Interface
{
    public interface IDeliverie
    {
        void AddDeliverie(int FirstDeliverie, int SecondDeliverie);
        int AddDeliveriesScore(int FirstDeliverie, int SecondDeliverie);
        bool AddStrike(int FirstDeliverie);
        bool AddSpare(int FirstDeliverie, int SecondDeliverie);
        void CheckForStrike();
        void CheckForSpare();
        void FinalStrike(int FirstDeliverie, int SecondDeliverie);
        void FinalSpare(int FirstDeliverie);
        int FinalScore();
    }
}
