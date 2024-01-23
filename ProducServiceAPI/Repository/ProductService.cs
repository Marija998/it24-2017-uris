using AutoMapper;
using ProductServiceAPI.Data;
using ProductServiceAPI.Models.Dtos;
using ProductServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductServiceAPI.Repository
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> CreateProductAsync(ProductCreateRequest createRequest)
        {
            var product = _mapper.Map<Product>(createRequest);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Product> UpdateProductAsync(int id, ProductUpdateRequest updateRequest)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product != null)
            {
                _mapper.Map(updateRequest, product);
                await _context.SaveChangesAsync();
            }
            return product;
        }
    }
}