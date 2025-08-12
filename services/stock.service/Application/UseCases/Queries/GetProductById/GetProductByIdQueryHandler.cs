using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(ProductRepository repository) : IRequestHandler<GetProductByIdQuery, Product>
    {
        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return repository.Get(request.Id, cancellationToken);
        }
    }
}
