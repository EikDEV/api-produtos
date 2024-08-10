namespace api_produtos.Services.Dtos;

public class PagedOutputDto<T>
{
    public int TotalRegisters { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public List<T>? Results { get; set; }
}
