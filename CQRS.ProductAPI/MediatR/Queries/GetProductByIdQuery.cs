using CQRS.ProductAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.MediatR.Queries
{
    public class GetProductByIdQuery: IRequest<ProductResponse>
    {
        public int Id { get;  }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
