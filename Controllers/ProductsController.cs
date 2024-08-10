using api_produtos.Services;
using api_produtos.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api_produtos.Controllers;

[Route("produtos")]
[ApiController]
public class ProductsController(ProductService service) : ControllerBase
{
    private readonly ProductService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        try
        {
            return Ok(await _service.GetAllProducts());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("por-id")]
    public async Task<IActionResult> GetProductById([FromQuery] int id)
    {
        try
        {
            return Ok(await _service.GetProductById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("paginado")]
    public async Task<IActionResult> GetProductsPaged([FromQuery] int page, [FromQuery] int pageSize)
    {
        try
        {
            return Ok(await _service.GetProductsPaged(page, pageSize));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostProduct([FromBody] PostProductInputDto inputDto)
    {
        try
        {
            return Ok(await _service.PostProduct(inputDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("por-id")]
    public async Task<IActionResult> UpdateProductById([FromQuery] int id, [FromBody] PutProductInputDto inputDto)
    {
        try
        {
            return Ok(await _service.UpdateProductById(id, inputDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
