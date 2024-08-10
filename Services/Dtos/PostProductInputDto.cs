namespace api_produtos.Services.Dtos;

public class PostProductInputDto
{
    public string? Description { get; set; }
    public double Price { get; set; }
    public int UserId { get; set; }
}
