using AutoMapper;
using CQRS.ProductAPI.MediatR.Queries;
using CQRS.ProductAPI.Models;
using CQRS.ProductAPI.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.MediatR.Handlers.QueryHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductRepository ProductRepository;
        private readonly IMapper Mapper;
        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            ProductRepository = productRepository;
            Mapper = mapper;
        }
        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = ProductRepository.GetProductById(request.Id);
            if (product == null) { return null; }
            var getProduct = Mapper.Map<Product, ProductResponse>(product);
            return getProduct;
        }
    }
}
