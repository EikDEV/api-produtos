namespace api_produtos.Domain.Entity;

public class Products
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public int InclusionUserId { get; set; }
    public DateTime InclusionDate { get; set; }
    public int LastChangedUserId { get; set; }
    public DateTime LastChangedDate { get; set; }
    public bool IsDeleted { get; set; }
    public int ExclusionUserId { get; set; }
    public DateTime ExclusionDate { get; set; }
}
