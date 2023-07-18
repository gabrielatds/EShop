using EShop.Application.Commands.Products.AddProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Infrastructure.API.Controllers
{
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost, Route("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult AddProduct([FromBody] AddProductCommand addProductCommand)
        {
            _mediator.Send(addProductCommand);
            return StatusCode(201);
        }
    }
}
