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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
    {
        private readonly IProductRepository ProductRepository;
        private readonly ILogger<UpdateProductHandler> Logger;
        private readonly IMapper Mapper;
        public UpdateProductHandler(IProductRepository productRepository, ILogger<UpdateProductHandler> logger,IMapper mapper)
        {
            ProductRepository = productRepository;
            Logger = logger;
            Mapper = mapper;
        }
        public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productResponse = Mapper.Map<UpdateProductCommand, ProductResponse>(request);
            var updateProduct = Mapper.Map<ProductResponse, Product>(productResponse);
            ProductRepository.UpdateProduct(updateProduct);
            Logger.LogInformation("Product Updated..");
            return productResponse;
        }
    }
}
