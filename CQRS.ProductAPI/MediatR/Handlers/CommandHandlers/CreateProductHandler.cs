using AutoMapper;
using CQRS.ProductAPI.MediatR.Commands;
using CQRS.ProductAPI.Models;
using CQRS.ProductAPI.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.MediatR.Handlers.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository ProductRepository;
        private readonly ILogger<CreateProductHandler> Logger;
        private readonly IMapper Mapper;
        public CreateProductHandler(IProductRepository productRepository, ILogger<CreateProductHandler> logger, IMapper mapper)
        {
            ProductRepository = productRepository;
            Logger = logger;
            Mapper = mapper;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productResponse = Mapper.Map<CreateProductCommand, ProductResponse>(request);
            var addProduct = Mapper.Map<ProductResponse, Product>(productResponse);
            ProductRepository.AddProduct(addProduct);
            Logger.LogInformation("Product Created..");
            return productResponse;
        }
    }
}
