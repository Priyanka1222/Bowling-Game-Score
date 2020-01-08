using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BowlingGameScore.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "First Delivery")]
        [Range(0, 10, ErrorMessage = "The field First Deliverie must be between 0 and 10.")]
        [Required(ErrorMessage = "The First Deliverie field is required.")]
        public int FirstDelivery { get; set; }
        [Display(Name = "Second Delivery")]
        [Range(0, 10, ErrorMessage = "The field Second Deliverie must be between 0 and 10.")]
        [Required(ErrorMessage = "The Second Deliverie field is required.")]
        public int SecondDelivery { get; set; }
        [Display(Name = "Score")]
        public int Score { get; set; }
        public int FinalScore { get; set; }
        public IList<UserViewModel> Frames { get; set; } = new List<UserViewModel>();
    }
}