using Microsoft.AspNetCore.Mvc;

using PaymentGateway.Api.Models;
using PaymentGateway.Api.Models.Requests;
using PaymentGateway.Api.Models.Responses;
using PaymentGateway.Api.Services;

namespace PaymentGateway.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : Controller
{
    private readonly PaymentsRepository _paymentsRepository;

    public PaymentsController(PaymentsRepository paymentsRepository)
    {
        _paymentsRepository = paymentsRepository;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PostPaymentResponse?>> GetPaymentAsync(Guid id)
    {
        var payment = _paymentsRepository.Get(id);

        if (payment is null)
        {
            return new NotFoundResult();
        }

        return new OkObjectResult(payment);
    }

    [HttpPost]
    public async Task<ActionResult<PostPaymentResponse>> PostPaymentAsync(PaymentRequest paymentRequest)
    {
        var postPaymentResponse = new PostPaymentResponse()
        {
            Id = Guid.NewGuid(),
            Amount = paymentRequest.Amount,
            CardNumberLastFour = ExtractLastFourDigitsFromCardNumber(paymentRequest.CardNumber),
            Currency = paymentRequest.Currency,
            ExpiryMonth = paymentRequest.ExpiryMonth,
            ExpiryYear = paymentRequest.ExpiryYear,
            Status = PaymentStatus.Authorized,
        };

        _paymentsRepository.Add(postPaymentResponse);

        return postPaymentResponse;
    }

    private static int ExtractLastFourDigitsFromCardNumber(long cardNumber)
    {
        var cardNumberString = cardNumber.ToString();

        var cardNumberLastFourDigits = Convert.ToInt16(cardNumberString.Substring(cardNumberString.Length - 4));

        return cardNumberLastFourDigits;
    }
}