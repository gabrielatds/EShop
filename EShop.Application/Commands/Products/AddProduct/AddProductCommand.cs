using MediatR;

namespace EShop.Application.Commands.Products.AddProduct
{
    public class AddProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
