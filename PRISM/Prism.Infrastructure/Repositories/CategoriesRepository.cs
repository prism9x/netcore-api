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
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly PrismDbContext _dbContext;

        public CategoriesRepository(PrismDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public Category? GetById(int? id)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Category?> GetByIdAsync(int? id)
        {
            return await _dbContext.Categories
                .Include(c => c.Products) // Lấy ra cả dữ liệu của bảng Products
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
