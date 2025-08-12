namespace Application.DTOs
{
    public record ProductDto(string Name, string Description, int Price, int InStock, string Sku, string Slug);
}
