using EShop.Domain.Interfaces;
using EShop.Domain.Models;
using EShop.Infrastructure.DataAcess.UoW;
using MediatR;

namespace EShop.Application.Commands.Products.AddProduct
{
    public class AddProductCommandHandler : CommandHandler, IRequestHandler<AddProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public AddProductCommandHandler(IProductRepository repository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _repository = repository;
        }

        public Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Category, request.Price);
            _repository.AddAsync(product);

            Commit();
            PublishEvents(product.Events);

            return Task.FromResult(true);
        }
    }
}
