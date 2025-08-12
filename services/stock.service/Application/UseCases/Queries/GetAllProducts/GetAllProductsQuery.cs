using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.GetAllProducts
{
    public record GetAllProductsQuery() : IRequest<List<Product>>;

}
