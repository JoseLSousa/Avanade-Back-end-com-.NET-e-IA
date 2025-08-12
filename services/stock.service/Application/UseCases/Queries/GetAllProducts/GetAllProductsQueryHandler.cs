using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler(ProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetAll(cancellationToken);
        }
    }
}
