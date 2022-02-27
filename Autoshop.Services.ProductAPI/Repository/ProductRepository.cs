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

        public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product? productList = await _db.Products
                .FirstOrDefaultAsync(x => x.ProductId == productId)!;
            return _mapper.Map<ProductDto>(productList);
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
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
                Product? product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product != null) _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
