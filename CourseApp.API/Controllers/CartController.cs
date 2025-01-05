using CourseApp.Application.DTOs;
using CourseApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(CartAddDto cartAddDto)
        {
            var userId = int.Parse(User.FindFirst("id")!.Value);
            var response = await _cartService.AddToCartAsync(cartAddDto, userId);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("remove/{cartId}")]
        public async Task<IActionResult> RemoveFromCart(int cartId)
        {
            var userId = int.Parse(User.FindFirst("id")!.Value);
            var response = await _cartService.RemoveFromCartAsync(cartId, userId);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetCartItems()
        {
            var userId = int.Parse(User.FindFirst("id")!.Value);
            var response = await _cartService.GetCartItemsAsync(userId);
            return Ok(response);
        }
    }
}
