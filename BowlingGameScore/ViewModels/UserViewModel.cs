using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BowlingGameScore.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "First Delivery")]
        [Range(0, 10, ErrorMessage = "The field First Delivery must be between 0 and 10.")]
        [Required(ErrorMessage = "The First Delivery field is required.")]
        public int FirstDelivery { get; set; }
        [Display(Name = "Second Delivery")]
        [Range(0, 10, ErrorMessage = "The field Second Delivery must be between 0 and 10.")]
        [Required(ErrorMessage = "The Second Delivery field is required.")]
        public int SecondDelivery { get; set; }
        [Display(Name = "Score")]
        public int Score { get; set; }
        public int FinalScore { get; set; }
        public int FrameCount { get; set; }
        public string StrikeSymbols { get; set; }
        public string SpareSymbols { get; set; }
        public bool ShowSymbols { get; set; }
        public IList<UserViewModel> Frames { get; set; } = new List<UserViewModel>();
    }
}