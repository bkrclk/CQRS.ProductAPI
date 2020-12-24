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
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
    {
        private readonly IProductRepository ProductRepository;
        private readonly IMapper Mapper;
        public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper = null)
        {
            ProductRepository = productRepository;
            Mapper = mapper;
        }
        public async Task<List<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products =  ProductRepository.GetAllProducts();
            var getAllProduct = Mapper.Map<List<Product>, List<ProductResponse>>(products);
            return getAllProduct;
        }
    }
}

