using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Commands.CreateProduct
{
    public class CreateProductHandler(ProductRepository productRepository, UnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand>
    {
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                name: request.Name,
                description: request.Description,
                price: request.Price,
                inStock: request.InStock,
                sku: request.Sku,
                slug: request.Slug
                );

            productRepository.Create(product);
            await unitOfWork.Commit(cancellationToken);
        }
    }
}
