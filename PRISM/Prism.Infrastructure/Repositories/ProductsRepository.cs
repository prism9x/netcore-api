using Microsoft.EntityFrameworkCore;
using Prism.Domain.Entities;
using Prism.Domain.Repositories;
using Prism.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly PrismDbContext _dbContext;

        public ProductsRepository(PrismDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Product entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;

        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
