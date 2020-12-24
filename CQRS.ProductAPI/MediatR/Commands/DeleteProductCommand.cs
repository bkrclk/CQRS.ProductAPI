using CQRS.ProductAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.MediatR.Commands
{
    public class DeleteProductCommand : IRequest<ProductResponse>
    {
        public int Id { get; }
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
