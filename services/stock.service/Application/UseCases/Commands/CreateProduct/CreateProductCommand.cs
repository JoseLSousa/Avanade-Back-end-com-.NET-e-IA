using MediatR;

namespace Application.UseCases.Commands.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, int Price, int InStock, string Sku, string Slug) : IRequest
    {
    }
}
