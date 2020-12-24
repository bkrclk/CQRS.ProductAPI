using AutoMapper;
using CQRS.ProductAPI.MediatR.Commands;
using CQRS.ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateProductCommand, ProductResponse>();
            CreateMap<UpdateProductCommand, ProductResponse>();
            CreateMap<ProductResponse, Product>();
            CreateMap<Product, ProductResponse>();
            CreateMap<List<Product>, List<ProductResponse>>();
        }
    }
}
