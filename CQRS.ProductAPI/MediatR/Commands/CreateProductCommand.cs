using CQRS.ProductAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.MediatR.Commands
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
