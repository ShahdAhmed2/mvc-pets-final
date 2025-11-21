using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_pets.Models
{
    public class Donation
    {
        public int DonationId { get; set; }

        [Required(ErrorMessage = "Please enter the donation amount")]
        [Range(1, 1000000, ErrorMessage = "Donation amount must be between 1 and 1,000,000 SAR")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please enter the donation type")]
        [StringLength(100, ErrorMessage = "Donation type must not exceed 100 characters")]
        public string Type { get; set; }

        public DateTime DonationDate { get; set; }

        [Required(ErrorMessage = "Please enter the payment method")]
        [StringLength(50, ErrorMessage = "Payment method must not exceed 50 characters")]
        public string PaymentMethod { get; set; }

        public string Status { get; set; } = "Pending";
        public string? AdminNote { get; set; }

        // Use the correct property name:
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser User { get; set; }
        
    }
}
