using Prism.Domain.Entities;
using Prism.Infrastructure.Persistence;

namespace Prism.Infrastructure.Seeders
{
    public class ProductSeeders : IProductSeeders
    {
        private readonly PrismDbContext _dbContext;

        public ProductSeeders(PrismDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Kiểm tra xem có sản phẩm nào trong database không nếu không thì chèn dữ liệu mẫu vào
        /// </summary>
        /// <returns></returns>
        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Products.Any())
                {
                    var product = GetProducts();
                    _dbContext.Products.AddRange(product);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Tạo dữ liệu mẫu cho Products
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Product> GetProducts()
        {
            List<Product> products = [
                    new (){
                        Name = "Sập gụ trơn",
                        Price = 38_000_000,
                        Description = "Sập làm bằng gỗ gụ với kiểu dáng đơn giản và hiện đại",
                        Category = new Category() {
                            Name = "Sập nằm",
                        }
                    },

                    new (){
                        Name = "Tủ 3 buồng 4 cánh",
                        Price = 21_200_000,
                        Description = "Tủ 3 buồng 4 cánh hiện đại trang trí cho không gian nhà bạn",
                        Category = new Category() {
                            Name = "Tủ",
                        }
                    },

                    new (){
                        Name = "Vòng tay trầm",
                        Price = 3_500_000,
                        Description = "Vòng trầm hương mang lại hương thơm sâu sắc đến với bạn",
                        Category = new Category() {
                            Name = "Vòng tay",
                        }
                    },

                    new (){
                        Name = "Tượng gỗ tam đa",
                        Price = 15_300_000,
                        Description = "Tượng gỗ đầy đủ 3 ông tam đa phúc, lộc, thọ",
                        Category = new Category() {
                            Name = "Tượng gỗ",
                        }
                    },

                    new (){
                        Name = "Ban thờ gia tiên",
                        Price = 23_100_000,
                        Description = "Ban thờ cúng gia tiên với kiểu dáng đẹp tuyệt vời",
                        Category = new Category() {
                            Name = "Đồ thờ",
                        }
                    },
                ];

            return products;
        }
    }
}