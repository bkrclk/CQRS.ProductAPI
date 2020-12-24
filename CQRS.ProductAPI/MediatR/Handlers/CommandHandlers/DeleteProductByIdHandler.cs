using AutoMapper;
using CQRS.ProductAPI.MediatR.Commands;
using CQRS.ProductAPI.Models;
using CQRS.ProductAPI.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.MediatR.Handlers.CommandHandlers
{
    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductCommand, ProductResponse>
    {
        private readonly IProductRepository ProductRepository;
        private readonly IMapper Mapper;
        public DeleteProductByIdHandler(IProductRepository productRepository,IMapper mapper)
        {
            ProductRepository = productRepository;
            Mapper = mapper;
        }

        public async Task<ProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = ProductRepository.GetProductById(request.Id);

            if (product != null)
            {
                ProductRepository.DeleteProduct(request.Id);
            }
            var deleteProduct = Mapper.Map<Product,ProductResponse>(product);
            return deleteProduct;
        }
    }
}
