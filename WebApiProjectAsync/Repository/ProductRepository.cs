using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiProjectAsync.Data;
using WebApiProjectAsync.Dto;
using WebApiProjectAsync.Model;

namespace WebApiProjectAsync.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ProductDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllProductAsync()
        {
        //    var records = await _context.Products.Select(x => new ProductDto()
        //    {
        //        Id = x.Id,
        //        ProductName = x.ProductName,
        //        Description = x.Description,
        //        Price = x.Price,
        //        Category = x.Category
        //    }).ToListAsync();
        //    return records;

            var records= await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(records);
        }


        public async Task<int> AddProductAsync(ProductDto productDto)
        {
            var product = new Product()
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                Price = productDto.Price,
                Category = productDto.Category,

            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;

        }


        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            //var records = await _context.Products.Where(x => x.Id == id).Select(x => new ProductDto()
            //{
            //    Id = x.Id,
            //    ProductName = x.ProductName,
            //    Description = x.Description,
            //    Price = x.Price,
            //    Category = x.Category

            //}
            //).FirstOrDefaultAsync();

            //return records;
            var product = await _context.Products.FindAsync(id);
            return _mapper.Map<ProductDto>(product);    
        }

        public async Task UpdateProductAsync(int id, ProductDto productDto)
        {
            //var product = await _context.Products.FindAsync(id);
            //if(product != null) 
            //{
            //  product.ProductName= productDto.ProductName;
            //    product.Description= productDto.Description;
            //    product.Price= productDto.Price;
            //    product.Category= productDto.Category;
            //    await _context.SaveChangesAsync();

            //}
            var product = new Product()
            {
                Id = id,
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                Price = productDto.Price,
                Category = productDto.Category

            };
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var prduct = new Product()
            {
                Id = id,
            };
            _context.Products.Remove(prduct);
            await _context.SaveChangesAsync();
        }

    }
}
