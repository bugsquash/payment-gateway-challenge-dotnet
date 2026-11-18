using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Api.Models.Requests
{
    public class PaymentRequest
    {
        [Required]
        public long CardNumber { get; set; }

        [Required]
        [Range(1, 12)]
        public int ExpiryMonth { get; set; }

        [Required]
        [Range(2026, 2040)]
        public int ExpiryYear { get; set; }

        [Required]
        [StringLength(3)]
        public required string Currency { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int Cvv { get; set; }
    }
}
