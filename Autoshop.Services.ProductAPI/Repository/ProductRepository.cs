using AutoMapper;
using Autoshop.Services.ProductAPI.DbContexts;
using Autoshop.Services.ProductAPI.Models;
using Autoshop.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Autoshop.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        private IMapper _mapper;
        
        private readonly ILogger<ProductRepository> logger;

        public ProductRepository(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger<ProductRepository> logger)
        {
            _db = dbContext;
            _mapper = mapper;
            this.logger = logger;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var productList = await _db.Products
                .FirstOrDefaultAsync(x => x.ProductId == productId);
            return _mapper.Map<ProductDto>(productList);
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product == null) throw new KeyNotFoundException("Product with current id not found");
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}
