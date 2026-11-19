using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaymentGateway.Api.Models.Responses
{
    public class PostBankResponse
    {
        [Required]
        public bool Authorized { get; set; }

        [Required]
        [JsonPropertyName("authorization-code")]
        public Guid AuthorizationCode { get; set; }
    }
}
