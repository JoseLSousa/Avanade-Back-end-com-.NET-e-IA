using Application.DTOs;
using MediatR;

namespace Application.UseCases.Commands.UpdateProduct
{
    public record UpdateProductCommand(ProductDto Product, Guid Id) : IRequest<bool>
    {
    }
}
