using CourseApp.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment()
        {
            var userId = int.Parse(User.FindFirst("id")!.Value);
            var response = await _paymentService.ProcessPaymentAsync(userId);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetPaymentHistory()
        {
            var userId = int.Parse(User.FindFirst("id")!.Value);
            var response = await _paymentService.GetPaymentHistoryAsync(userId);
            return Ok(response);
        }
    }
}
