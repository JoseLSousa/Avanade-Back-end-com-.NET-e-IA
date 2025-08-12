using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IRequest<Product>;
}
