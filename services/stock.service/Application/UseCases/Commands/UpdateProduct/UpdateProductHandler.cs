using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Commands.UpdateProduct
{
    public class UpdateProductHandler(ProductRepository repository, UnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, bool>
    {
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await repository.Get(request.Id, cancellationToken);
            if (product == null) return false;

            product.UpdateProductData(
                request.Product.Name,
                request.Product.Description,
                request.Product.Price,
                request.Product.InStock,
                request.Product.Sku,
                request.Product.Slug
            );
            repository.Update(product);
            await unitOfWork.Commit(cancellationToken);
            return true;
        }
    }
}
