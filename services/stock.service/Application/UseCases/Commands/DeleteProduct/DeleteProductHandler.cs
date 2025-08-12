using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Commands.DeleteProduct
{
    public class DeleteProductHandler(ProductRepository repository, UnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productExist = await repository.ProductExists(request.Id);
            if (!productExist) return false;

            repository.Delete(request.Id);
            await unitOfWork.Commit(cancellationToken);
            return true;
        }
    }
}
