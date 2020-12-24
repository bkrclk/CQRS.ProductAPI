using CQRS.ProductAPI.MediatR.Commands;
using CQRS.ProductAPI.MediatR.Queries;
using CQRS.ProductAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator Mediator;

        public ProductController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await Mediator.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand(id);
            var result = await Mediator.Send(command);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

    }
}