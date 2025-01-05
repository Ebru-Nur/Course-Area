using CourseApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task AddToCartAsync(Cart cart);
        Task RemoveFromCartAsync(int cartId);
        Task<IEnumerable<Cart>> GetCartItemsAsync(int userId);
        Task<Cart?> GetCartItemAsync(int userId, int courseId);
    }
}
