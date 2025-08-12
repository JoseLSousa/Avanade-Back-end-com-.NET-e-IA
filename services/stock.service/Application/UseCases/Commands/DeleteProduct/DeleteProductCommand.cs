using MediatR;

namespace Application.UseCases.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : IRequest<bool>;
}
