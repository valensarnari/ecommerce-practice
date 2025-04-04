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
    public class CartProductRepository : BaseRepository<CartProduct>, ICartProductRepository
    {
        private readonly ApplicationContext _context;
        public CartProductRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<CartProduct>> GetAllAsync()
            => await _context.CartProducts
                .Include(cp => cp.Product)
                .ThenInclude(p => p.Category)
                .ToListAsync();

        public override async Task<CartProduct?> GetByIdAsync(int id)
            => await _context.CartProducts
                .Include(cp => cp.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(cp => cp.ProductId == id);

        public async Task DeleteProductFromCartAsync(CartProduct entity)
        {
            if (entity != null)
            {
                _context.CartProducts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
