using CourseApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetOrderHistory()
        {
            var userId = int.Parse(User.FindFirst("id")!.Value);
            var response = await _orderService.GetOrderHistoryAsync(userId);
            return Ok(response);
        }
    }
}
