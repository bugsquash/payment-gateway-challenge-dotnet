using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaymentGateway.Api.Models.Requests
{
    public class PostBankRequest
    {
        [Required]
        [JsonPropertyName("card_number")]
        public required string CardNumber { get; set; }

        [Required]
        [JsonPropertyName("expiry_date")]
        public required string ExpiryDate { get; set; }

        [Required]
        [StringLength(3)]
        public required string Currency { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public required string Cvv { get; set; }
    }
}
