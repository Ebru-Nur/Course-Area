using CourseApp.Application.Interfaces.Repositories;
using CourseApp.Domain.Entities;
using CourseApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddToCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cart>> GetCartItemsAsync(int userId)
        {
            return await _context.Carts
                .Include(c => c.Course)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task<Cart?> GetCartItemAsync(int userId, int courseId)
        {
            return await _context.Carts
                .FirstOrDefaultAsync(c => c.UserId == userId && c.CourseId == courseId);
        }
    }
}
