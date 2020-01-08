using System.Collections.Generic;

namespace BowlingGameScore.Models
{
    public class User
    {
        public int UserId { get; set; }
        public IList<Frame> Frames { get; set; } = new List<Frame>();
    }
}
