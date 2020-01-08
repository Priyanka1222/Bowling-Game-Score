namespace BowlingGameScore.Models
{
    public class Frame
    {
        public int FrameId { get; set; }
        public int FirstDelivery { get; set; }
        public int SecondDelivery { get; set; }
        public bool Strike { get; set; }
        public bool Spare { get; set; }
        public int Score { get; set; }
        public int FrameCount { get; set; }
    }
}