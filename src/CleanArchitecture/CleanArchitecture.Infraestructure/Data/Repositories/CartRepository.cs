using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Data.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        private readonly ApplicationContext _context;
        public CartRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Cart>> GetAllAsync()
            => await _context.Carts
                .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
                .ThenInclude(p => p.Category)
                .ToListAsync();

        public override async Task<Cart?> GetByIdAsync(int id)
            => await _context.Carts
                .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Cart?> GetByUserAsync(int userId)
            => await _context.Carts
                .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(c => c.UserId == userId);
    }
}
