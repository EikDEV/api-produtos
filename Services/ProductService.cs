using api_produtos.Domain.Entity;
using api_produtos.Services.Dtos;
using Microsoft.EntityFrameworkCore;

namespace api_produtos.Services;

public class ProductService(Context context)
{
    private readonly Context _context = context;

    public async Task<List<ProductOutputDto>> GetAllProducts()
    {
        try
        {
            _context.Database.EnsureCreated();

            List<Products> productsList = await _context.Products
                .Where(x => x.IsDeleted == false)
                .ToListAsync();

            List<ProductOutputDto> outputDtoList = [];

            foreach (Products product in productsList)
            {
                ProductOutputDto outputDto = new()
                {
                    Id = product.Id,
                    Description = product.Description,
                    Price = product.Price
                };

                outputDtoList.Add(outputDto);
            };

            return outputDtoList;
        }
        catch
        {
            throw;
        }
    }

    public async Task<PagedOutputDto<ProductOutputDto>> GetProductsPaged(int page, int pageSize)
    {
        try
        {
            _context.Database.EnsureCreated();

            List<Products> productsList = await _context.Products
                .Where(x => x.IsDeleted == false)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            int totalRegisters = await _context.Products
                .Where(x => x.IsDeleted == false)
                .CountAsync();

            int totalPages = (int)Math.Ceiling((double)totalRegisters / pageSize);

            List<ProductOutputDto> outputDtoList = [];

            foreach (Products product in productsList)
            {
                ProductOutputDto outputDto = new()
                {
                    Id = product.Id,
                    Description = product.Description,
                    Price = product.Price
                };

                outputDtoList.Add(outputDto);
            };

            PagedOutputDto<ProductOutputDto> pagedOutput = new()
            {
                TotalRegisters = totalRegisters,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Results = outputDtoList
            };

            return pagedOutput;
        }
        catch
        {
            throw;
        }
    }

    public async Task<ProductOutputDto> GetProductById(int id)
    {
        try
        {
            _context.Database.EnsureCreated();

            Products? product = await _context.Products
                .Where(x => x.Id == id && x.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (product == null)
                throw new Exception("Produto não encontrado!");

            ProductOutputDto productOutput = new()
            {
                Id = product.Id,
                Description = product.Description,
                Price = product.Price
            };

            return productOutput;
        }
        catch
        {
            throw;
        }
    }

    public async Task<string> PostProduct(PostProductInputDto inputDto)
    {
        try
        {
            _context.Database.EnsureCreated();

            Products product = new()
            {
                Description = inputDto.Description,
                Price = inputDto.Price,
                InclusionUserId = inputDto.UserId,
                InclusionDate = DateTime.Now
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return $"Produto '{inputDto.Description}' criado com sucesso!";
        }
        catch
        {
            throw;
        }
    }

    public async Task<string> UpdateProductById(int id, PutProductInputDto inputDto)
    {
        try
        {
            _context.Database.EnsureCreated();

            Products? product = await _context.Products
                .Where(x => x.Id == id && x.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (product == null)
                throw new Exception("Produto não encontrado!");

            product.Description = inputDto.Description;
            product.Price = inputDto.Price;

            await _context.SaveChangesAsync();

            return $"Produto {id} atualizado com sucesso!";
        }
        catch
        {
            throw;
        }
    }
}
