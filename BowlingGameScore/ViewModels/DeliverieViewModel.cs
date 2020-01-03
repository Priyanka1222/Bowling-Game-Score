using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BowlingGameScore.ViewModels
{
    public class DeliverieViewModel 
    {
        [Display(Name = "First Deliverie")]
        [Range(0, 10, ErrorMessage = "The field First Deliverie must be between 0 and 10.")]
        [Required(ErrorMessage = "The First Deliverie field is required.")]
        public int FirstDeliverie { get; set; }
        [Display(Name = "Second Deliverie")]
        [Range(0, 10, ErrorMessage = "The field Second Deliverie must be between 0 and 10.")]
        [Required(ErrorMessage = "The Second Deliverie field is required.")]
        public int SecondDeliverie { get; set; }
        [Display(Name = "Score")]
        public int Score { get; set; }
        public IList<DeliverieViewModel> Deliveries { get; set; } = new List<DeliverieViewModel>();
    }
}