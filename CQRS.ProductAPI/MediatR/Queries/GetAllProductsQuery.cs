using CQRS.ProductAPI.Models;
using CQRS.ProductAPI.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.MediatR.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductResponse>>
    {

    }
}

